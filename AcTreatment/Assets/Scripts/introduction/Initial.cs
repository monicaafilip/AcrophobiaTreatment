using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class Initial : MonoBehaviour
{
    public string nextScene;
    public GameObject initialPanel;
    public GameObject panelDefinire;

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
        initialPanel.SetActive(false);
        panelDefinire.SetActive(true);
    }


    IEnumerator LoadSceneCoroutine()
    {
        Debug.Log("loadSceneCoroutine");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(nextScene);
    }
}
