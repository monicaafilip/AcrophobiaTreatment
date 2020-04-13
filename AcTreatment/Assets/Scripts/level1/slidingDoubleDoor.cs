using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidingDoubleDoor : MonoBehaviour
{
    public GameObject trigger;
    public GameObject left_door;
    public GameObject right_door;

    Animator l_animator;
    Animator r_animator;

    // Start is called before the first frame update
    void Start()
    {
        l_animator = left_door.GetComponent<Animator>();
        r_animator = right_door.GetComponent<Animator>(); 
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
        l_animator.SetBool("slide", state);
        r_animator.SetBool("slide", state);
    }
}
