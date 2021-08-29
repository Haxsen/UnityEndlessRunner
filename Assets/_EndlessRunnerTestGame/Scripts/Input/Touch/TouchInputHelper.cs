using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Input
{
    /// <summary>
    /// Provides utils for touch input.
    /// </summary>
    public static class TouchInputHelper
    {
        /// <summary>
        /// Converts the touch position to world position.
        /// </summary>
        /// <param name="camera">The camera casting the world.</param>
        /// <param name="touchPosition">The position of touch.</param>
        /// <returns>The 2D Vector containing X and Y coords.</returns>
        public static Vector2 GetTouchPosition(Camera camera, Vector3 touchPosition)
        {
            touchPosition.z = camera.nearClipPlane;
            return camera.ScreenToWorldPoint(touchPosition);
        }
    }
}