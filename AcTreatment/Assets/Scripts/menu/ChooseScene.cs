using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class ChooseScene : MonoBehaviour
{
    public GameObject firstPanel;
    public GameObject secondPanel;
    public TextMeshProUGUI progressText;

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
        StartCoroutine(LoadScene("city"));
    }

    public void LoadBuilding()
    {
        StartCoroutine(LoadScene("glassFloorBuilding"));
    }

    IEnumerator LoadScene(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        async.allowSceneActivation = false;
        while (async.progress < 0.9f)
        {
            Debug.Log("[ClickButtons] LoadScene("+sceneName+") : async.progress= "+ async.progress.ToString());
            yield return null;
        }
        async.allowSceneActivation = true;
    }

}
