using UnityEngine;

public class MyOutlineSelectionResponse : MonoBehaviour, MyISelectionResponse
{
    public void OnSelection(Transform selectedTransform)
    {
        var outlineComponent = selectedTransform.GetComponent<Outline>();
        if(outlineComponent != null)
        {
            outlineComponent.OutlineWidth = 10;
        }
    }
    
    public void OnDeselection(Transform selectedTransform)
    {
        selectedTransform.TryGetComponent<Outline>(out var outlineComponent);
        if(outlineComponent != null)
        {
            outlineComponent.OutlineWidth = 0;
        }
    }
}