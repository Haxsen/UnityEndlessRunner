using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";

    private Transform _selection;
    private MyISelectionResponse _selectionResponse;
    private MyRayCastHitProvider _rayCastHitProvider;

    private void Awake()
    {
        _selectionResponse = GetComponent<MyISelectionResponse>();
        _rayCastHitProvider = GetComponent<MyRayCastHitProvider>();
    }

    void Update()
    {
        // Desel / Sel response
        if(_selection != null)
        {
            _selectionResponse.OnDeselection(_selection);
        }

        _selection = _rayCastHitProvider.GetRayCastHitTransform(selectableTag);

        // Desel / Sel response
        if(_selection != null)
        {
            _selectionResponse.OnSelection(_selection);
        }
    }

}
