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
        StartCoroutine(loadScene("city"));
    }

    public void LoadBuilding()
    {
        StartCoroutine(loadScene("glassFloorBuilding"));
    }
   
    IEnumerator loadScene(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        async.allowSceneActivation = false;
        while (async.progress < 0.9f)
        {
            //progressText.text = async.progress + "";
            yield return null;
        }
        async.allowSceneActivation = true;
    }


}
