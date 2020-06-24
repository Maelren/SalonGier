using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleWebBrowser;

public class UIController : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject InGameUI;
    public GameObject InfoUI;

    public GameObject browser;
    public GameObject selected;

    public void OpenBrowser(GameObject Selected, GameObject Browser)
    {
        selected = Selected;
        browser = Browser;
        playerMovement.OnOpenUI();
        InGameUI.SetActive(false);
        InfoUI.SetActive(true);
        browser.GetComponent<Transform>().localPosition = new Vector3(-1, 1.9f, 0);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseBrowser()
    {
        playerMovement.OnCloseUI();
        InGameUI.SetActive(true);
        browser.GetComponent<Transform>().localPosition = new Vector3(-1, -1.9f, 0);
        InfoUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public bool IsOpen()
    {
        return playerMovement.inUI;
    }
}
