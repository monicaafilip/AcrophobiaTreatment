using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class XBoxController : MonoBehaviour
{
    public Canvas canvas;
    public GameObject informations;
    public GameObject initialPanel;

    public GameObject currentActivePanel;
    public List<GameObject> previousActiveMenus;

    public InputController inputCtrl;
    public static XBoxController xbox;

    public GameObject cybersickness;
    private bool first;

    //second scene (glassFloorBuilding) needed
    private GameObject player;
    public GameObject canvasGO;

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

        //second scene (glassFloorBuilding) needed
        player = GameObject.Find("OVRPlayerController");

    }

    public void Update()
    {
        //second scene (glassFloorBuilding) needed
        player = GameObject.Find("OVRPlayerController");
    }
    public void ShowInformations()
    {
        if (SceneManager.GetActiveScene().name == "menu")
        {
            // remove the background images, else where the informations will not be seen
            canvas.transform.Find("CityBackground").gameObject.SetActive(false);
            canvas.transform.Find("BlackImage").gameObject.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name == "introduction")
        {
            CloseCybersicknessAudio();
        }

        if (SceneManager.GetActiveScene().name == "glassFloorBuilding")
        {
            ChangeCanvasPosition();
            canvas.transform.Find("informations").gameObject.SetActive(true);
        }

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

        // GoBack() in city scene && glassFloorBuilding scenes means just removing informations gameObject
        if(SceneManager.GetActiveScene().name == "city" || SceneManager.GetActiveScene().name == "glassFloorBuilding")
        {
            informations.SetActive(false);
            return;
        }

        if (previousActiveMenus.Count == 0)
            return;

        if (SceneManager.GetActiveScene().name == "introduction")
            CloseCybersicknessAudio();

        if (SceneManager.GetActiveScene().name == "menu")
        {
            GameObject canvas = FindObjectOfType<Canvas>().gameObject;
            
            if ( informations.activeSelf == true )
            {
                informations.SetActive(false);
                canvas.transform.Find("CityBackground").gameObject.SetActive(true);
                canvas.transform.Find("BlackImage").gameObject.SetActive(true);
            }
        }

        currentActivePanel.SetActive(false);
        CheckIfParentShouldBeInactive();
        SetPreviousPanelActive();
        previousActiveMenus.RemoveAt(previousActiveMenus.Count - 1);
    }

    private void Next()
    {
        Debug.Log("[XBoxController] Next()");

        CloseCybersicknessAudio();
        // when the information panel is active, 
        // Next() function will return
        GameObject currActive = FindCurrentActiveObject(canvas.gameObject);
        if (currActive.name == "informations")
            return;

        if (first && SceneManager.GetActiveScene().name == "introduction" )
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

    // calculate the canvas position for the glassFloorBuilding scene
    // the canvas will be set in front of the player with a predefined distance
    private void ChangeCanvasPosition()
    {
        float distance      = 32f;
        // GameObject canvasGO = GameObject.Find("canvasGameObject").gameObject;

        float eulerAnglesY = player.transform.eulerAngles.y;

        if (eulerAnglesY > 270 && eulerAnglesY < 360)
        {
            // front direction is on +z
            canvasGO.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + distance);
            canvasGO.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, 0, player.transform.eulerAngles.z);

        }
        if (eulerAnglesY < 270 && eulerAnglesY > 180)
        {
            // left direction is on -x
            canvasGO.transform.position = new Vector3(player.transform.position.x - distance, player.transform.position.y, player.transform.position.z);
            canvasGO.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, 270, player.transform.eulerAngles.z);

        }
        if (eulerAnglesY > 0 && eulerAnglesY < 90)
        {
            // right direction is on +x
            canvasGO.transform.position = new Vector3(player.transform.position.x + distance, player.transform.position.y, player.transform.position.z);
            canvasGO.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, 90, player.transform.eulerAngles.z);

        }
        if (eulerAnglesY < 180 && eulerAnglesY > 90)
        {
            // back direction is on -z
            canvasGO.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - distance);
            canvasGO.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, 180, player.transform.eulerAngles.z);

        }

    }

    private void CloseCybersicknessAudio()
    {
        if(cybersickness != null && cybersickness.activeSelf == true)
            cybersickness.SetActive(false);
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
