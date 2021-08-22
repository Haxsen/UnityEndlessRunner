using UnityEngine;

namespace _Practice.SOLID.OwnMethod
{
    public class HxnRayProvider
    {
        public Ray CreateRayFromMousePosition()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}