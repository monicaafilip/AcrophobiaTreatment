using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InformationsClick : MonoBehaviour
{
    // buttons
    public Button breathingButton;
    public Button advicesButton;
    public Button otherInfoButton;

    //all info
    public GameObject breathing_info;
    public GameObject advices_info;
    public GameObject other_info;

    //sounds
    public AudioSource breathingExercises_audio;

    //advices
    public GameObject advices;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;


    public void Start()
    {
        breathingButton.animator.keepAnimatorControllerStateOnDisable = true;
        advicesButton.animator.keepAnimatorControllerStateOnDisable = true;
        otherInfoButton.animator.keepAnimatorControllerStateOnDisable = true;
        
        if(SceneManager.GetActiveScene().name == "menu")
        {
            // remove the background images, else where the informations will not be seen
            GameObject canvas = FindObjectOfType<Canvas>().gameObject;
            canvas.transform.Find("CityBackground").gameObject.SetActive(false);
            canvas.transform.Find("BlackImage").gameObject.SetActive(false);
        }
    }

     public void OnDisable()
     {
        Debug.Log("[InformationsClick] OnDisable()");

        // reset info opened 
        breathing_info.SetActive(false);
        advices_info.SetActive(false);
        other_info.SetActive(false);

        // set normal state to every button
        breathingButton.animator.Play("Normal");
        advicesButton.animator.Play("Normal");
        otherInfoButton.animator.Play("Normal");
     }

    public void ShowAdvices()
    {
        StartCoroutine(ShowAdvicesCoroutine());
    }

    IEnumerator ShowAdvicesCoroutine()
    {
        Reset();

        advices_info.SetActive(true);
        text1.SetActive(true);

        yield return new WaitForSeconds(5);
        text1.SetActive(false);
        text2.SetActive(true);
 
        yield return new WaitForSeconds(8);
        text2.SetActive(false);
        text3.SetActive(true);

        yield return new WaitForSeconds(8);
        text3.SetActive(false);
        text4.SetActive(true);

        yield return new WaitForSeconds(5);
        advices.SetActive(false);
        text4.SetActive(false);
        text1.SetActive(true);
    }

    public void ShowBreathingExercises()
    {
        Reset();
        breathing_info.SetActive(true);
        breathingExercises_audio.Play();
    }

    public void ShowOtherInformations()
    {
        Reset();
        other_info.SetActive(true);
    }

    private void Reset()
    {
        breathing_info.SetActive(false);
        advices_info.SetActive(false);
        other_info.SetActive(false);
    }
}
