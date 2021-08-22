using UnityEngine;

public interface MyISelectionResponse
{
    void OnSelection(Transform t);
    void OnDeselection(Transform t);
}