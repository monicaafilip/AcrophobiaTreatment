using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManagement : MonoBehaviour
{
    public GameObject nextButton;

    public GameObject panelInitial;
    public GameObject panelDefinire;
    public GameObject panelStudii;
    public GameObject panelIntrebari;
    public GameObject studii_leftCanvas;

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

    public string currentPanel;

    public void Next()
    {
        switch (currentPanel)
        {
            case "Definire":
                xboxController.previousActiveMenus.Add(panelDefinire);
                xboxController.currentActivePanel = panelStudii;

                panelDefinire.SetActive(false);
                panelStudii.SetActive(true);
                studii_leftCanvas.SetActive(true);
                currentPanel = "Studii";
                nextButton.SetActive(false);
                nextButton.SetActive(true);
                break;

            case "Studii":
                xboxController.previousActiveMenus.Add(panelStudii);
                xboxController.currentActivePanel = panelIntrebari;

                panelStudii.SetActive(false);
                studii_leftCanvas.SetActive(false);
                panelIntrebari.SetActive(true);
                currentPanel = "Intrebare_1";
                nextButton.SetActive(false);
                nextButton.SetActive(true);
                break;

            case "Intrebare_1":
                xboxController.previousActiveMenus.Add(intrebare1);
                xboxController.currentActivePanel = intrebare2;

                intrebare1.SetActive(false);
                intrebare2.SetActive(true);
                currentPanel = "Intrebare_2";
                nextButton.SetActive(false);
                nextButton.SetActive(true);
                break;

            case "Intrebare_2":
                xboxController.previousActiveMenus.Add(intrebare2);
                xboxController.currentActivePanel = intrebare3;

                intrebare2.SetActive(false);
                intrebare3.SetActive(true);
                currentPanel = "Intrebare_3";
                nextButton.SetActive(false);
                nextButton.SetActive(true);
                break;

            case "Intrebare_3":
                xboxController.previousActiveMenus.Add(intrebare3);
                xboxController.currentActivePanel = intrebare4;

                intrebare3.SetActive(false);
                intrebare4.SetActive(true);
                currentPanel = "Intrebare_4";
                nextButton.SetActive(false);
                nextButton.SetActive(true);
                break;

            case "Intrebare_4":
                xboxController.previousActiveMenus.Add(intrebare4);
                xboxController.currentActivePanel = intrebare5;

                intrebare4.SetActive(false);
                intrebare5.SetActive(true);
                currentPanel = "Intrebare_5";
                nextButton.SetActive(false);
                nextButton.SetActive(true);
                break;

            case "Intrebare_5":
                xboxController.previousActiveMenus.Add(intrebare5);
                xboxController.currentActivePanel = intr_concluzie;

                intrebare5.SetActive(false);
                intr_concluzie.SetActive(true);
                currentPanel = "Intrebare_concluzie";
                nextButton.SetActive(false);
                nextButton.SetActive(true);
                break;

            case "Intrebare_concluzie":
                xboxController.previousActiveMenus.Add(panelIntrebari);
                xboxController.currentActivePanel = panelImaginatie;

                panelIntrebari.SetActive(false);
                panelImaginatie.SetActive(true);
                currentPanel = "Ex1";
                nextButton.SetActive(false);
                nextButton.SetActive(true);
                break;

            case "Ex1":
                xboxController.previousActiveMenus.Add(ex1);
                xboxController.currentActivePanel = ex2;

                ex1.SetActive(false);
                ex2.SetActive(true);
                currentPanel = "Ex2";
                nextButton.SetActive(false);
                nextButton.SetActive(true);
                break;

            case "Ex2":
                xboxController.previousActiveMenus.Add(ex2);
                xboxController.currentActivePanel = ex3;
                
                ex2.SetActive(false);
                ex3.SetActive(true);
                currentPanel = "Ex3";
                nextButton.SetActive(false);
                nextButton.SetActive(true);
                break;

            case "Ex3":
                xboxController.previousActiveMenus.Add(ex3);
                xboxController.currentActivePanel = ex_concluzie;

                ex3.SetActive(false);
                ex_concluzie.SetActive(true);
                currentPanel = "Ex_concluzie";
                nextButton.SetActive(false);
                nextButton.SetActive(true);
                break;

            case "Ex_concluzie":
                LoadScene();
                break;


        }

    }
    // for initial buttons
    public string nextScene;

    private void Awake()
    {
        nextScene = "menu";
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            LoadScene();
    }
    
    public void LoadScene()
    {
        StartCoroutine(LoadSceneCoroutine());
    }

    public void Curiozitati()
    {
        panelInitial.SetActive(false);
        panelDefinire.SetActive(true);
        nextButton.SetActive(true);
        currentPanel = "Definire";
    }


    IEnumerator LoadSceneCoroutine()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
        async.allowSceneActivation = false;
        while (async.progress < 0.9f)
        {
            //progressText.text = async.progress + "";
            yield return null;
        }
        async.allowSceneActivation = true;
    }




}
