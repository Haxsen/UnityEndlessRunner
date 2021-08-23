using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Input
{
    public static class TouchInputHelper
    {
        public static Vector2 GetPrimaryPosition(Camera camera, Vector3 touchPosition)
        {
            touchPosition.z = camera.nearClipPlane;
            return camera.ScreenToWorldPoint(touchPosition);
        }
    }
}