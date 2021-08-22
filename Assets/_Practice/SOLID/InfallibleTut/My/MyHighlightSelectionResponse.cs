using UnityEngine;

public class MyHighlightSelectionResponse : MonoBehaviour, MyISelectionResponse
{
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material highlightMaterial;
    
    public void OnSelection(Transform selectedTransform)
    {
        var selectionRenderer = selectedTransform.GetComponent<Renderer>();
        if(selectionRenderer != null)
        {
            selectionRenderer.material = highlightMaterial;
        }
    }
    
    public void OnDeselection(Transform selectedTransform)
    {
        var selectionRenderer = selectedTransform.GetComponent<Renderer>();
        if(selectionRenderer != null)
        {
            selectionRenderer.material = defaultMaterial;
        }
    }
}