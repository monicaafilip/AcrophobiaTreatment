using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class clickButtons : MonoBehaviour
{
    public GameObject welcomeMenuColliders;
    public GameObject welcomeTextUI;
    public GameObject startButtonUI;
    public GameObject exitButtonUI;
    public GameObject chooseLevelMenuColliders;
    public GameObject level1Button;

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

        chooseLevelMenuColliders.SetActive(true);
        level1Button.SetActive(true);

        welcomeMenuColliders.SetActive(false);
        welcomeTextUI.SetActive(false);
        startButtonUI.SetActive(false);
        exitButtonUI.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
    
    public void Level1Button()
    {
        StartCoroutine(LoadLevel1Coroutine());
    }


    IEnumerator LoadLevel1Coroutine()
    {
        Debug.Log("loadSceneCoroutine");
        transitionAnimator.enabled = true;
        transitionAnimator.SetTrigger("end");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("city");
    }

}
