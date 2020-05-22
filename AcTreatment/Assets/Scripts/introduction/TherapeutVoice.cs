using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class therapeutVoice : MonoBehaviour
{
    public AudioSource cybersickness;
    
    void Start()
    {
        StartCoroutine(takeCareOfCyberSickness());
    }
    
    IEnumerator takeCareOfCyberSickness()
    {
        yield return new WaitForSeconds(2);
        cybersickness.Play();
    }
}
