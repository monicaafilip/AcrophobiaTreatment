using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidingDoor : MonoBehaviour
{
    public GameObject trigger;
    public GameObject door;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = door.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            SlideDoor(true);
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            SlideDoor(false);
    }
    void SlideDoor(bool state)
    {
        animator.SetBool("slide", state);
    }
}
