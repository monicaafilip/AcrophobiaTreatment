using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class clickButtons : MonoBehaviour
{   
    public GameObject welcomeTextUI;
    public GameObject startButtonUI;
    public GameObject exitButtonUI;
    public GameObject cityButton;
    public GameObject buildingButton;

    public Animator  transitionAnimator;

    public void StartButton()
    {
        StartCoroutine(StartButtonCoroutine());
    }
    IEnumerator StartButtonCoroutine()
    {
        transitionAnimator.enabled = true;
        transitionAnimator.SetTrigger("end");
        yield return null;

        cityButton.SetActive(true);
        buildingButton.SetActive(true);

        welcomeTextUI.SetActive(false);
        startButtonUI.SetActive(false);
        exitButtonUI.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
    
    public void LoadCity()
    {
        StartCoroutine(waitForProgram("city"));
    }

    public void LoadBuilding()
    {
        StartCoroutine(loadScene("glassFloorBuilding"));
    }

    IEnumerator waitForProgram(string sceneName)
    {
        yield return null;
        StartCoroutine(loadScene(sceneName));
    }

    IEnumerator LoadAsyncScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;
        yield return (asyncLoad.progress > 0.9f);
        transitionAnimator.enabled = true;
        transitionAnimator.SetTrigger("end");
        StartCoroutine(loaded(asyncLoad));
    }

    IEnumerator loaded(AsyncOperation sync)
    {
        yield return null;
        sync.allowSceneActivation = true;
    }
    IEnumerator loadScene(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        async.allowSceneActivation = false;
        while (async.progress < 0.9f)
        {
            //progressText.text = async.progress + "";
            yield return null;
        }
       // while (!async.isDone)
       // {
       //     yield return null;
       // }
        async.allowSceneActivation = true;
    }


}
