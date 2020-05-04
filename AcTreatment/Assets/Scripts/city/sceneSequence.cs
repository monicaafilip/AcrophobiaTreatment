using System.Collections;
using UnityEngine;

public class sceneSequence : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;

    private void Start()
    {
        StartCoroutine(TheSequence());
    }

    IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(9.7f);
        cam2.SetActive(true);
        cam1.SetActive(false);

        yield return new WaitForSeconds(9.7f);
        cam3.SetActive(true);
        cam2.SetActive(false);
    }
}
