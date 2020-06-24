using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseController : MonoBehaviour
{
    public SelectionManager selectionManager;
    public UIController UI;
    public GameObject player;
    private GameObject tmp;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (!UI.IsOpen())
            {
                if (selectionManager._selection != null)
                {
                    Debug.Log(selectionManager._selection.parent.parent.parent.name);
                    var t = selectionManager._selection.parent.parent.parent.GetComponent<Transform>();
                    var p = player.GetComponent<Transform>();
                    var c = p.GetChild(0).GetComponent<Transform>();

                    c.localRotation = Quaternion.Euler(0f, 0f, 0f);


                    p.SetPositionAndRotation(t.position - new Vector3(-1.395f, -1*p.position.y, 0), new Quaternion(0,-90,0,90));
                    UI.OpenBrowser(selectionManager._selection.parent.parent.gameObject, selectionManager._selection.parent.parent.GetChild(1).gameObject);
                }
            }
        }
        if (UI.IsOpen())
        {
            if (Input.GetButtonDown("ExitGame"))
                UI.CloseBrowser();
        }
    }
}
