using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class ChooseScene : MonoBehaviour
{
    public GameObject firstPanel;
    public GameObject secondPanel;
    public GameObject closePanel;

    public GameObject cityAudio;
    public GameObject buildingAudio;

    public Animator  transitionAnimator;

    private AsyncOperation async;
    private string loadedScene;
    private bool sceneDoneLoading;

    public void Start()
    {
        async = null;
        sceneDoneLoading = false;
        XBoxController.xbox.currentActivePanel = firstPanel;
    }

    public void StartButton()
    {
        StartCoroutine(StartButtonCoroutine());
    }

    IEnumerator StartButtonCoroutine()
    {
        transitionAnimator.enabled = true;
        transitionAnimator.SetTrigger("end");
        yield return null;

        XBoxController.xbox.previousActiveMenus.Add(firstPanel);
        XBoxController.xbox.currentActivePanel = secondPanel;

        secondPanel.SetActive(true);
        firstPanel.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void LoadCity()
    {
        cityAudio.GetComponent<AudioSource>().Play();
        StartCoroutine(LoadScene("city"));
    }

    public void LoadBuilding()
    {
        buildingAudio.GetComponent<AudioSource>().Play();
        StartCoroutine(LoadScene("glassFloorBuilding"));
    }

    IEnumerator LoadScene(string sceneName)
    {
        // first wait the audio to finish
        if (sceneName ==  "city")
        {
            yield return new WaitForSeconds(cityAudio.GetComponent<AudioSource>().clip.length);
        }
        if (sceneName == "glassFloorBuilding")
        {
            yield return new WaitForSeconds(buildingAudio.GetComponent<AudioSource>().clip.length);
        }

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        async.allowSceneActivation = false;
        while (async.progress < 0.9f)
        {
            Debug.Log("[ClickButtons] LoadScene("+sceneName+") : async.progress= "+ async.progress.ToString());
            yield return null;
        }
        async.allowSceneActivation = true;
    }

    public void HideClosePanel()
    {
        closePanel.SetActive(false);
        secondPanel.SetActive(true);
    }

}
