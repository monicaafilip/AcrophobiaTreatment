using System.Collections.Generic;
using UnityEngine;

public class XBoxController : MonoBehaviour
{
    public Canvas canvas;
    public GameObject informations;
    public GameObject initialPanel;

    public GameObject currentActivePanel;
    public List<GameObject> previousActiveMenus;

    public InputController inputCtrl;

    public static XBoxController xbox;

    private bool first;

    public void Awake()
    {
        Debug.Log("[XBoxController] Awake()");

        xbox = this;
        first = true;

        if (inputCtrl == null)
            inputCtrl = new InputController();

        inputCtrl.gameplay.Y.performed += x => ShowInformations();
        inputCtrl.gameplay.B.performed += x => GoBack();
        inputCtrl.gameplay.A.performed += x => Next();

    }

    public void ShowInformations()
    {
        currentActivePanel = FindCurrentActiveObject(canvas.gameObject);

        if (currentActivePanel == null)
            return;

        currentActivePanel.SetActive(false);
        previousActiveMenus.Add(currentActivePanel);
        currentActivePanel = informations;
        informations.SetActive(true);
    }

    public void GoBack()
    {
        Debug.Log("[XBoxController] GoBack()");
        if (previousActiveMenus.Count == 0)
            return;

        currentActivePanel.SetActive(false);
        CheckIfParentShouldBeInactive();
        SetPreviousPanelActive();
        previousActiveMenus.RemoveAt(previousActiveMenus.Count - 1);
    }

    private void Next()
    {
        Debug.Log("[XBoxController] Next()");

        // when the information panel is active, 
        // Next() function will return
        GameObject currActive = FindCurrentActiveObject(canvas.gameObject);
        if (currActive.name == "informations")
            return;

        if (first)
        {
            currentActivePanel =  FindCurrentActiveObject(canvas.gameObject);

            if (currentActivePanel == null)
                return;

            currentActivePanel.SetActive(false);
            initialPanel.SetActive(true);
            currentActivePanel = initialPanel;
            first = false;
        }
    }

    // find the first child active of the gameobject given as parameter
    // return the found child or null if there is no active child
    public GameObject FindCurrentActiveObject(GameObject parent)
    {
        GameObject childActive;
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            if (parent.transform.GetChild(i).gameObject.activeSelf == true)
            {
                childActive = parent.transform.GetChild(i).gameObject;
                return childActive;
            }
        }
        return null;
    }

    // set the previous panel active
    // if the previous panel has its parent inactive, sets this active too
    private void SetPreviousPanelActive()
    {
        GameObject prev = previousActiveMenus[previousActiveMenus.Count - 1];
        prev.SetActive(true);
        GameObject parent = prev.transform.parent.gameObject;

        // if the parent's name is Panel, then it isn't the desired parent
        // the desired one is the 'grandParent'
        if (parent.name == "Panel")
            parent = parent.transform.parent.gameObject;

        if (parent.activeSelf == false)
            parent.SetActive(true);

        // set the panelManagement currentPanel too
        PanelManagement.currentPanel = prev.name;
        currentActivePanel = prev;

    }

    // check if the currentPanel's parent is active
    // and if there is no other child gameobject active
    // if those characteristics happens the parent gameobject will be set as inactive
    private void CheckIfParentShouldBeInactive()
    {
        GameObject parent = currentActivePanel.transform.parent.gameObject;
        
        // if the parent's name is Panel, then it isn't the desired parent
        // the desired one is the 'grandParent'
        GameObject child = FindCurrentActiveObject(parent);
        if (child == null || child.name.Contains("title"))
        {
            if (parent.name == "Panel")
                parent = parent.transform.parent.gameObject;
            parent.SetActive(false);
        }
        
    }

    private void OnEnable()
    {
        inputCtrl.gameplay.Enable();
    }
    private void OnDisable()
    {
        inputCtrl.gameplay.Disable();
    }


}
