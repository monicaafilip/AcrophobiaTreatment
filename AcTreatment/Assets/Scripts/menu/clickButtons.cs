using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class clickButtons : MonoBehaviour
{   
    public GameObject welcomeTextUI;
    public GameObject startButtonUI;
    public GameObject exitButtonUI;
    public GameObject cityButton;
    public GameObject buildingButton;
    public TextMeshProUGUI progressText;

    public Animator  transitionAnimator;

    private AsyncOperation async;
    private string loadedScene;

    public void Start()
    {
        async = null;
    }
    public void Update()
    {
        if(async != null)
        {
            progressText.text = async.progress + "";
            if (async.progress >= 0.85)
            {
                async.allowSceneActivation = true;
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(loadedScene));
            }
        }
        
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
        async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        async.allowSceneActivation = false;
        loadedScene = sceneName;
        yield return async;
       
    }

}
