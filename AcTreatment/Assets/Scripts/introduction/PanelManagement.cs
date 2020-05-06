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
                panelDefinire.SetActive(false);
                panelStudii.SetActive(true);
                studii_leftCanvas.SetActive(true);
                currentPanel = "Studii";
                nextButton.SetActive(false);
                nextButton.SetActive(true);
                break;
            case "Studii":
                panelStudii.SetActive(false);
                studii_leftCanvas.SetActive(false);
                panelIntrebari.SetActive(true);
                currentPanel = "Intrebare_1";
                nextButton.SetActive(false);
                nextButton.SetActive(true);
                break;
            case "Intrebare_1":
                intrebare1.SetActive(false);
                intrebare2.SetActive(true);
                currentPanel = "Intrebare_2";
                nextButton.SetActive(false);
                nextButton.SetActive(true);
                break;
            case "Intrebare_2":
                intrebare2.SetActive(false);
                intrebare3.SetActive(true);
                currentPanel = "Intrebare_3";
                nextButton.SetActive(false);
                nextButton.SetActive(true);
                break;
            case "Intrebare_3":
                intrebare3.SetActive(false);
                intrebare4.SetActive(true);
                currentPanel = "Intrebare_4";
                nextButton.SetActive(false);
                nextButton.SetActive(true);
                break;
            case "Intrebare_4":
                intrebare4.SetActive(false);
                intrebare5.SetActive(true);
                nextButton.SetActive(false);
                nextButton.SetActive(true);
                break;
            case "Intrebare_5":
                intrebare5.SetActive(false);
                intr_concluzie.SetActive(true);
                currentPanel = "Intrebare_concluzie";
                nextButton.SetActive(false);
                nextButton.SetActive(true);
                break;
            case "Intrebare_concluzie":
                panelIntrebari.SetActive(false);
                panelImaginatie.SetActive(true);
                currentPanel = "Ex1";
                nextButton.SetActive(false);
                nextButton.SetActive(true);
                break;
            case "Ex1":
                ex2.SetActive(false);
                ex2.SetActive(true);
                currentPanel = "Ex2";
                nextButton.SetActive(false);
                nextButton.SetActive(true);
                break;
            case "Ex2":
                ex2.SetActive(false);
                ex3.SetActive(true);
                currentPanel = "Ex3";
                nextButton.SetActive(false);
                nextButton.SetActive(true);
                break;
            case "Ex3":
                ex3.SetActive(false);
                ex_concluzie.SetActive(true);
                currentPanel = "Ex_concluzie";
                nextButton.SetActive(false);
                nextButton.SetActive(true);
                break;


        }

    }
    // for initial buttons
    public string nextScene;

    private void Awake()
    {
        nextScene = "menu";
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
        Debug.Log("loadSceneCoroutine");
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadSceneAsync(nextScene);
    }




}
