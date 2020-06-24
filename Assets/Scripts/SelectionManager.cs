using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string SelectableTag = "selectable";
    [Range(1.0f, 5.0f)]
    public float selectionDistance;

    [HideInInspector]
    public Transform _selection;

    void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetChild(0).GetChild(0).GetComponent<MeshRenderer>();
            selectionRenderer.enabled = false;
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, selectionDistance))
        {
            var selection = hit.transform;
            if (selection.CompareTag(SelectableTag))
            {
                var selectionRenderer = selection.GetChild(0).GetChild(0).GetComponent<MeshRenderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.enabled = true;
                }
                _selection = selection;
            }
        }
    }
}
