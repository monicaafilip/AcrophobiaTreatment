using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManagement : MonoBehaviour
{
    public GameObject panelInitial;

    public GameObject panelDefinire;
    public GameObject fobiaDef;
    public GameObject acrofobiaDef;

    public GameObject panelStudii;
    public GameObject panelIntrebari;

    public GameObject intrebare1;
    public GameObject intrebare2;
    public GameObject intrebare3;
    public GameObject intrebare4;
    public GameObject intrebare5;
    public GameObject intr_concluzie;

    public GameObject panelImaginatie;
    public GameObject ex1;
    public GameObject ex2;
    public GameObject ex3;
    public GameObject ex_concluzie;

    public static string currentPanel;

    public void Start()
    {
        Debug.Log("[PanelManagement] Start()");

        XBoxController.xbox.inputCtrl.gameplay.A.performed += x => Next();
        nextScene = "menu";
    }


    public void Next()
    {
        Debug.Log("[PanelManagement] Next() currentPanel = " + currentPanel);

        // when the information panel is active, 
        // Next() function will return
        GameObject currActive = XBoxController.xbox.FindCurrentActiveObject(XBoxController.xbox.canvas.gameObject);
        if (currActive.name == "informations")
            return;

        switch (currentPanel)
        {
            case "Definire":
            case "Fobia_general":
                XBoxController.xbox.previousActiveMenus.Add(fobiaDef);
                XBoxController.xbox.currentActivePanel = acrofobiaDef;

                fobiaDef.SetActive(false);
                acrofobiaDef.SetActive(true);
                currentPanel = "Acrofobia";
                break;

            case "Acrofobia":
                XBoxController.xbox.previousActiveMenus.Add(acrofobiaDef);
                XBoxController.xbox.currentActivePanel = panelStudii;

                // set the initial state of this panel
                acrofobiaDef.SetActive(false);
                fobiaDef.SetActive(true);
                panelDefinire.SetActive(false);

                panelStudii.SetActive(true);
                currentPanel = "Studii";
                break;

            case "Studii":
                XBoxController.xbox.previousActiveMenus.Add(panelStudii);
                XBoxController.xbox.currentActivePanel = panelIntrebari;

                panelStudii.SetActive(false);
                panelIntrebari.SetActive(true);
                currentPanel = "Intrebare_1";
                break;

            case "Intrebare_1":
                XBoxController.xbox.previousActiveMenus.Add(intrebare1);
                XBoxController.xbox.currentActivePanel = intrebare2;

                intrebare1.SetActive(false);
                intrebare2.SetActive(true);
                currentPanel = "Intrebare_2";
                break;

            case "Intrebare_2":
                XBoxController.xbox.previousActiveMenus.Add(intrebare2);
                XBoxController.xbox.currentActivePanel = intrebare3;

                intrebare2.SetActive(false);
                intrebare3.SetActive(true);
                currentPanel = "Intrebare_3";
                break;

            case "Intrebare_3":
                XBoxController.xbox.previousActiveMenus.Add(intrebare3);
                XBoxController.xbox.currentActivePanel = intrebare4;

                intrebare3.SetActive(false);
                intrebare4.SetActive(true);
                currentPanel = "Intrebare_4";
                break;

            case "Intrebare_4":
                XBoxController.xbox.previousActiveMenus.Add(intrebare4);
                XBoxController.xbox.currentActivePanel = intrebare5;

                intrebare4.SetActive(false);
                intrebare5.SetActive(true);
                currentPanel = "Intrebare_5";
                break;

            case "Intrebare_5":
                XBoxController.xbox.previousActiveMenus.Add(intrebare5);
                XBoxController.xbox.currentActivePanel = intr_concluzie;

                intrebare5.SetActive(false);
                intr_concluzie.SetActive(true);
                currentPanel = "Intrebare_concluzie";
                break;

            case "Intrebare_concluzie":
                XBoxController.xbox.previousActiveMenus.Add(intr_concluzie);
                XBoxController.xbox.currentActivePanel = panelImaginatie;

                // set the initial state of this panel
                panelIntrebari.SetActive(false);
                intr_concluzie.SetActive(false);
                intrebare1.SetActive(true);

                panelImaginatie.SetActive(true);
                currentPanel = "Ex1";
                break;

            case "Ex1":
                XBoxController.xbox.previousActiveMenus.Add(ex1);
                XBoxController.xbox.currentActivePanel = ex2;

                ex1.SetActive(false);
                ex2.SetActive(true);
                currentPanel = "Ex2";
                break;

            case "Ex2":
                XBoxController.xbox.previousActiveMenus.Add(ex2);
                XBoxController.xbox.currentActivePanel = ex3;
                
                ex2.SetActive(false);
                ex3.SetActive(true);
                currentPanel = "Ex3";
                break;

            case "Ex3":
                XBoxController.xbox.previousActiveMenus.Add(ex3);
                XBoxController.xbox.currentActivePanel = ex_concluzie;

                ex3.SetActive(false);
                ex_concluzie.SetActive(true);
                currentPanel = "Ex_concluzie";
                break;

            case "Ex_concluzie":
                // set the initial state of this panel
                panelImaginatie.SetActive(false);
                ex_concluzie.SetActive(false);
                ex1.SetActive(true);

                XBoxController.xbox.canvas.transform.Find("UserManual").gameObject.SetActive(true);
                
                LoadScene();
                break;


        }

    }
    // for initial buttons
    public string nextScene;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            LoadScene();
    }
    
    public void LoadScene()
    {
        GetComponent<AudioSource>().Play();
        StartCoroutine(LoadSceneCoroutine());
    }

    public void Curiozitati()
    {
        Debug.Log("[PanelManagement] Curiozitati()");
        panelInitial.SetActive(false);
        panelDefinire.SetActive(true);
        currentPanel = "Definire";
        XBoxController.xbox.currentActivePanel = panelDefinire;
        XBoxController.xbox.previousActiveMenus.Add(panelInitial);
    }


    IEnumerator LoadSceneCoroutine()
    {
        // first wait the audio to finish
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);

        AsyncOperation async = SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Single);
        async.allowSceneActivation = false;
        while (async.progress < 0.9f)
        {
            Debug.Log("[ClickButtons] LoadScene(" + nextScene + ") : async.progress= " + async.progress.ToString());
            yield return null;
        }
        async.allowSceneActivation = true;
    }
}
