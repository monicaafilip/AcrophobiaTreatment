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
        yield return new WaitForSeconds(0.5f);

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
        StartCoroutine(LoadCoroutine("city"));
    }

    public void LoadBuilding()
    {
        StartCoroutine(LoadCoroutine("glassFloorBuilding"));
    }

    IEnumerator LoadCoroutine(string sceneName)
    {
        Debug.Log("loadSceneCoroutine");
        transitionAnimator.enabled = true;
        transitionAnimator.SetTrigger("end");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadSceneAsync(sceneName);
    }

}
