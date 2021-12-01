Shader "Custom/CurvedShader" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
//        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _MainTex("Texture", 2D) = "white" {}
        _BendAmount("Bend Amount", Vector) = (1,1,1,1)
        _BendOrigin("Bend Origin", Vector) = (0,0,0,0)
        _BendFallOff("Bend Falloff", float) = 1.0
        _BendFallOffStr("Falloff strength", Range(0.00001,10)) = 1.0
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 200
        
        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        float3 _BendAmount;
        float3 _BendOrigin;
        float _BendFallOff;
        float _BendFallOffStr;

        struct Input {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o) {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }

        #include "UnityCG.cginc"
        
        struct appdata
        {
            float4 vertex : POSITION;
            float2 uv : TEXCOORD0;
            float4 color : COLOR;
        };

        struct v2f
        {
            float2 uv : TEXCOORD0;
            UNITY_FOG_COORDS(1)
            float4 color : TEXCOORD2;
            float4 vertex : SV_POSITION;
        };
        
        float4 curveIt(float4 v)
        {
         /*1*/float4 world = mul(unity_ObjectToWorld, v);
         /*2*/float dist = length(world.xyz - _BendOrigin.xyz);
         /*3*/dist = max(0, dist - _BendFallOff);

         /*4*/dist = pow(dist, _BendFallOffStr);
         /*5*/world.xyz += dist * _BendAmount;
         /*6*/return mul(unity_WorldToObject, world);
        }

        v2f vert(appdata v)
        {
            v2f o;
            o.vertex = UnityObjectToClipPos(curveIt(v.vertex));
            o.uv = v.uv;
            UNITY_TRANSFER_FOG(o,o.vertex);
            return o;
        }
        
        ENDCG
        
    }
    FallBack "Diffuse"
}