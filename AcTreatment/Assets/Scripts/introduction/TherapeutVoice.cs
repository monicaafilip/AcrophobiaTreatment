using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TherapeutVoice : MonoBehaviour
{
    public AudioSource cybersickness;
    
    void Start()
    {
        Debug.Log("[TherapeutVoice] Start()");
        StartCoroutine(takeCareOfCyberSickness());
    }
    
    IEnumerator takeCareOfCyberSickness()
    {
        Debug.Log("[TherapeutVoice] cybersickness audio source play");
        yield return new WaitForSeconds(10);
        cybersickness.Play();
    }
}
