using UnityEngine;

namespace _Practice.SOLID.OwnMethod
{
    public class HxnOutlineSelectionResponse : MonoBehaviour, IHxnSelectionResponse
    {
        public void Select(Transform selectedObject, bool isSelect)
        {
            selectedObject.TryGetComponent(out Outline selectedObjectOutline);
            selectedObjectOutline.OutlineWidth = isSelect ? 10 : 0;
        }
    }
}