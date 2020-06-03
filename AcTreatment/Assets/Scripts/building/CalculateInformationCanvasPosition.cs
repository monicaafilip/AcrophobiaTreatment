using UnityEngine;

public class CalculateInformationCanvasPosition : MonoBehaviour
{
    public GameObject canvasGO;
    public GameObject player;

    public static CalculateInformationCanvasPosition calculate;

    private static float distance;

    public void Start()
    {
        distance  = 27.0f;
        calculate = this;
    }

    public void Update()
    {
        player = GameObject.Find("OVRPlayerController");
    }

  
}
