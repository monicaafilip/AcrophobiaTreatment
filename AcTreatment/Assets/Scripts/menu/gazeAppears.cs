using UnityEngine;

public class gazeAppears : MonoBehaviour
{
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = true;
    }    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "UI")
            GetComponent<SpriteRenderer>().enabled = true;
        if(other.tag == "Buttons")
        {
            Debug.Log("buttons collider");
            GetComponent<BoxCollider>().enabled = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        
        GetComponent<SpriteRenderer>().enabled = false;
        if(other.tag == "Buttons")
            GetComponent<BoxCollider>().enabled = true;
    }
    
}
