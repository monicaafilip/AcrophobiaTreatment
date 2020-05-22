using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvicesScroll : MonoBehaviour
{
    public GameObject advices;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;

    public void Start()
    {
        StartCoroutine(showAdvices());
    }

    IEnumerator showAdvices()
    {
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
}
