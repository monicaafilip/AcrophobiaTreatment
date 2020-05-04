using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator transitionAnimator;
    public string sceneName;

    public void LoadScene()
    {
        StartCoroutine(LoadSceneCoroutine());
    }

    IEnumerator LoadSceneCoroutine()
    {
        Debug.Log("loadSceneCoroutine");
        transitionAnimator.enabled = true;
        transitionAnimator.SetTrigger("end");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }

}
