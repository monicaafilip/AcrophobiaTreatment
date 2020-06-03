using UnityEngine;

public class ObjectAppearing : MonoBehaviour
{
    public GameObject groundFloor;
    public GameObject firstFloor;
    public GameObject secondFloor;
    public GameObject exposition;

    void Start()
    {
        groundFloor.SetActive(true);
        firstFloor.SetActive(true);
        secondFloor.SetActive(true);
        exposition.SetActive(true);
    }

    void Update()
    {
        
    }
}
