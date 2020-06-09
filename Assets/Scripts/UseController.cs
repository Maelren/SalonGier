using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseController : MonoBehaviour
{
    public SelectionManager selectionManager;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(selectionManager._selection != null)
                Debug.Log(selectionManager._selection.parent.parent.parent.name);
        }
    }
}
