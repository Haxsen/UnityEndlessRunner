using UnityEngine;

namespace _Practice.SOLID.OwnMethod
{
    public class HxnHighlightSelectionResponse : MonoBehaviour, IHxnSelectionResponse
    {
        [SerializeField] private Material defaultMaterial;
        [SerializeField] private Material highlightMaterial;
        
        public void Select(Transform selectedObject, bool isSelect)
        {
            selectedObject.TryGetComponent(out Renderer selectedObjectRenderer);
            selectedObjectRenderer.material = isSelect ? highlightMaterial : defaultMaterial;
        }
    }
}