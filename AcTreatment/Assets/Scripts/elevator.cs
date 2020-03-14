using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    public GameObject movePlatform;
    public GameObject player;

    private void OnTriggerStay()
    {
        movePlatform.transform.position += movePlatform.transform.up * Time.deltaTime;
        player.transform.position += player.transform.up * Time.deltaTime;
    }
}
