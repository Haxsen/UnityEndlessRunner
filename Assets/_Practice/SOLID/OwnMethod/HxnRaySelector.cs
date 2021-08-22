using UnityEngine;

namespace _Practice.SOLID.OwnMethod
{
    public class HxnRaySelector : MonoBehaviour
    {
        [SerializeField] private string selectableTag = "Selectable";

        private HxnRayProvider _hxnRayProvider = new HxnRayProvider();

        public Transform GetRayHitTransform()
        {
            Ray ray = _hxnRayProvider.CreateRayFromMousePosition();
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.CompareTag(selectableTag)) return hit.transform;
            }

            return null;
        }
    }
}