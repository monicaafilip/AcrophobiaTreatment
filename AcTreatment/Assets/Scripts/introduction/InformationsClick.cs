using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationsClick : MonoBehaviour
{
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
       
    }

    public void ShowAdvices()
    {
        StartCoroutine(ShowAdvicesCoroutine());
    }

    IEnumerator ShowAdvicesCoroutine()
    {
        Reset();

        yield return new WaitForSeconds(10);
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
