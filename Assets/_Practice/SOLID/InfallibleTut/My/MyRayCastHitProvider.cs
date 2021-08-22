using UnityEngine;

public class MyRayCastHitProvider : MonoBehaviour
{
    public Transform GetRayCastHitTransform(string selectableTag)
    {
        // Creating ray
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Sel Determination
        if (!Physics.Raycast(ray, out var hit)) return null;
        var selection = hit.transform;
        return selection.CompareTag(selectableTag) ? selection : null;
    }
}