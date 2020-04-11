using UnityEngine;

public class gazeAppears : MonoBehaviour
{
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "UI")
            GetComponent<SpriteRenderer>().enabled = true;
    }
    void OnTriggerExit(Collider other)
    {
        // /if(other.tag == "UI")
            GetComponent<SpriteRenderer>().enabled = false;
    }
    
}
