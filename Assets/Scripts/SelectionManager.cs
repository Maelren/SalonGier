using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string SelectableTag = "selectable";
    private Transform _selection;

    void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetChild(0).GetComponent<MeshRenderer>();
            selectionRenderer.enabled = false;
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(SelectableTag))
            {
                //Debug.Log(selection.name);

                var selectionRenderer = selection.GetChild(0).GetComponent<MeshRenderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.enabled = true;
                }
                _selection = selection;
            }
        }
    }
}
