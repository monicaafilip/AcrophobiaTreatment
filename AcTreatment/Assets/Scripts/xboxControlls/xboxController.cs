using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class XBoxController : MonoBehaviour
{
    public Canvas canvas;
    public GameObject informations;

    public GameObject takeTheTest;
    public GameObject initialPanel;

    public GameObject currentActivePanel;
    public List<GameObject> previousActiveMenus;

    public InputController inputCtrl;
    public static XBoxController xbox;

    public GameObject cybersickness;
    private bool first;   // to activate takeTheScene panel
    private bool second;  // to activate initial panel

    // second scene (glassFloorBuilding) needed
    private GameObject player;
    public GameObject canvasGO;

    // city scene needed
    public static bool stopElevator = false;

    public void Awake()
    {
        Debug.Log("[XBoxController] Awake()");

        xbox = this;
        first = true;
        second = false;

        if (inputCtrl == null)
            inputCtrl = new InputController();

        inputCtrl.gameplay.Y.performed += x => ShowInformations();
        inputCtrl.gameplay.B.performed += x => GoBack();
        inputCtrl.gameplay.A.performed += x => Next();
        inputCtrl.gameplay.X.performed += x => CloseCurrentScene();

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

        if (SceneManager.GetActiveScene().name == "city")
        {
            // close exit panels, if they're actives
            GameObject closePanel_l = canvas.transform.Find("closePanel_left").gameObject;
            GameObject closePanel_r = canvas.transform.Find("closePanel_right").gameObject;
            if (closePanel_l != null)
                closePanel_l.SetActive(false);
            if (closePanel_r != null)
                closePanel_r.SetActive(false);

            float eulerAnglesY = player.transform.eulerAngles.y;
            if (eulerAnglesY > -90 && eulerAnglesY < 90)
            {
                canvas.transform.Find("informations_left").gameObject.SetActive(true);
            }
            if (eulerAnglesY > 90 && eulerAnglesY < 270)
            {
                canvas.transform.Find("informations_right").gameObject.SetActive(true);
            }
            return;

        }

        if (SceneManager.GetActiveScene().name == "glassFloorBuilding")
        {
            ChangeCanvasPosition();
            canvas.transform.Find("informations").gameObject.SetActive(true);
            return;
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
            if (SceneManager.GetActiveScene().name == "city")
            {
                GameObject closePanel_left = canvas.transform.Find("closePanel_left").gameObject;
                GameObject closePanel_right = canvas.transform.Find("closePanel_right").gameObject;
                if (closePanel_left != null || closePanel_right != null)
                {
                    closePanel_left.SetActive(false);
                    closePanel_right.SetActive(false);
                }
                canvas.transform.Find("informations_left").gameObject.SetActive(false);
                canvas.transform.Find("informations_right").gameObject.SetActive(false);
            }
            else
            {
                canvas.transform.Find("ClosePanel").gameObject.SetActive(false);
                informations.SetActive(false);
            }
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

        if (first && SceneManager.GetActiveScene().name == "introduction")
        {
            currentActivePanel = FindCurrentActiveObject(canvas.gameObject);

            if (currentActivePanel == null)
                return;

            currentActivePanel.SetActive(false);
            takeTheTest.SetActive(true);
            currentActivePanel = takeTheTest;
            first = false;
            second = true;
        }
        else if (second && SceneManager.GetActiveScene().name == "introduction" )
        {
            currentActivePanel =  FindCurrentActiveObject(canvas.gameObject);

            if (currentActivePanel == null)
                return;

            currentActivePanel.SetActive(false);
            initialPanel.SetActive(true);
            currentActivePanel = initialPanel;
            second = false;
        }
    }

    // close the current active scene 
    // load menu scene
    // ask the user if he really wants to close the current scene
    public void CloseCurrentScene()
    {
        Debug.Log("[XBoxController] CloseCurrentScene()");

        if (SceneManager.GetActiveScene().name == "city")
        {
            // firstly, stop the elevator
            stopElevator = true;

            // close informations panel first, if it is active
            GameObject informations_l = canvas.transform.Find("informations_left").gameObject;
            GameObject informations_r = canvas.transform.Find("informations_right").gameObject;
            if (informations_l != null)
                informations_l.SetActive(false);
            if (informations_r != null)
                informations_r.SetActive(false);

            float eulerAnglesY = player.transform.eulerAngles.y;
            if (eulerAnglesY > -90 && eulerAnglesY < 90)
            {
                canvas.transform.Find("closePanel_left").gameObject.SetActive(true);
            }
            if (eulerAnglesY > 90 && eulerAnglesY < 270)
            {
                canvas.transform.Find("closePanel_right").gameObject.SetActive(true);
            }
        }

        if (SceneManager.GetActiveScene().name == "glassFloorBuilding")
        {
            ChangeCanvasPosition();
            informations.SetActive(false);
            canvas.transform.Find("ClosePanel").gameObject.SetActive(true);
        }

        if (SceneManager.GetActiveScene().name == "menu")
        {
            canvas.transform.Find("firstPanel").gameObject.SetActive(false);
            canvas.transform.Find("secondPanel").gameObject.SetActive(false);
            canvas.transform.Find("closePanel").gameObject.SetActive(true);
        }
    }

    // load menu scene, if the user choose so
    public void LoadMenu()
    {
        StartCoroutine(LoadScene("menu"));
    }

    // hide close informations if the user wants to continue in this scene
    public void HideCloseInformations()
    {
        if (SceneManager.GetActiveScene().name == "city")
        {
            stopElevator = false;
            canvas.transform.Find("closePanel_left").gameObject.SetActive(false);
            canvas.transform.Find("closePanel_right").gameObject.SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "glassFloorBuilding")
        {
            canvas.transform.Find("ClosePanel").gameObject.SetActive(false);
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


    IEnumerator LoadScene(string sceneName)
    {
        AudioSource toMenu = canvas.transform.Find("toMenu_audio").GetComponent<AudioSource>();
        toMenu.Play();

        if (SceneManager.GetActiveScene().name == "city" || SceneManager.GetActiveScene().name == "glassFloorBuilding")
        {
            yield return new WaitForSeconds(toMenu.clip.length);
        }

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        async.allowSceneActivation = false;
        while (async.progress < 0.9f)
        {
            Debug.Log("[ClickButtons] LoadScene(" + sceneName + ") : async.progress= " + async.progress.ToString());
            yield return null;
        }
        async.allowSceneActivation = true;
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
