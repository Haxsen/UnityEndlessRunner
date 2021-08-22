using UnityEngine;

namespace _Practice.SOLID.OwnMethod
{
    public class HxnSelectionManager : MonoBehaviour
    {
        private Transform _selectedTransform;
        private IHxnSelectionResponse _hxnSelectionResponse;
        private HxnRaySelector _hxnRaySelector;

        private void Awake()
        {
            _hxnSelectionResponse = GetComponent<IHxnSelectionResponse>();
            _hxnRaySelector = GetComponent<HxnRaySelector>();
        }

        private void Update()
        {
            Transform selectedTransformNew = _hxnRaySelector.GetRayHitTransform();
            if (selectedTransformNew)
            {
                _hxnSelectionResponse.Select(selectedTransformNew, true);
            }
            else if (_selectedTransform)
            {
                _hxnSelectionResponse.Select(_selectedTransform, false);
            }
            _selectedTransform = selectedTransformNew;
        }

    }
}