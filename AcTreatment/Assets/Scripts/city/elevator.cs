using UnityEngine;
using UnityEngine.UI;

public class Elevator : MonoBehaviour
{
    public Rigidbody movePlatform;
    public GameObject elevatorPanel;

    private Vector3 floorDist;
    private float speed = 0.5f;
    private int currentFloor = 0;
    private int maxFloor;

    private float tTotal;
    private bool isMoving;
    private int moveDirection;
    private Vector3 keepPosition;
    private int m_floorToGo;
    
    private bool colorSetToFinalFloor;
    private bool floorChanged;
    private bool firstFloor;
  

    private void Awake()
    {
        Debug.Log("[Elevator] Awake()");

        floorDist            = new Vector3(0, 2.1f, 0);
        maxFloor             = 54;
        colorSetToFinalFloor = false;
        firstFloor           = true;

        m_floorToGo  = currentFloor;
        keepPosition = movePlatform.transform.position;

    }

    public void MoveTo(int floorToGo)
    {
        m_floorToGo = floorToGo;
        floorChanged = true;

        if (firstFloor)
        {
            // set the first floor available with cyan, else it will be passed
            ButtonSetColor(currentFloor, Color.cyan);
            firstFloor = false;
        }

        if (!colorSetToFinalFloor)
        {
            if (m_floorToGo == 0)
                elevatorPanel.transform.Find("ChooseFloorButton").GetComponent<Image>().color = Color.blue;
            else
                elevatorPanel.transform.Find("ChooseFloorButton (" + (m_floorToGo-1).ToString() + ")").GetComponent<Image>().color = Color.blue;
            colorSetToFinalFloor = true;
        }

        if (floorToGo > currentFloor)
            moveDirection = 1;
        else if (floorToGo < currentFloor)
            moveDirection = -1;

        if (moveDirection == -1)
        {
            if (currentFloor < 0 || floorToGo < 0)
                return;

            var v = moveDirection * floorDist * speed;
            var t = Time.deltaTime;
            var tMax = floorDist.magnitude / speed;
            t = Mathf.Min(t, tMax - tTotal);
            movePlatform.MovePosition(v * t + movePlatform.gameObject.transform.position);
            if (keepPosition.y - floorDist.y >= movePlatform.transform.position.y)
            {
                //sets the previous of currentFloor button color back to white
                ButtonSetColor(currentFloor <= 0 ? 0 : currentFloor - moveDirection, Color.white);
                ButtonSetColor(currentFloor, Color.cyan);   // to see the current floor
                currentFloor += moveDirection;
                keepPosition = new Vector3(keepPosition.x, keepPosition.y - floorDist.y, keepPosition.z);
                firstFloor = false;
            }
        }

        if (moveDirection == 1)
        {
            if (floorToGo > maxFloor)
                floorToGo = maxFloor;

            var v = moveDirection * floorDist * speed;
            var t = Time.deltaTime;
            var tMax = floorDist.magnitude / speed;
            t = Mathf.Min(t, tMax - tTotal);
            movePlatform.MovePosition(v * t + movePlatform.gameObject.transform.position);
            if (keepPosition.y + floorDist.y <= movePlatform.transform.position.y)
            {
                //sets the previous of currentFloor button color back to white
                ButtonSetColor(currentFloor <= 0 ? 0 : currentFloor - 1, Color.white);
                ButtonSetColor(currentFloor, Color.cyan);   // to see the current floor
                currentFloor += moveDirection;
                keepPosition = new Vector3(keepPosition.x, keepPosition.y + floorDist.y, keepPosition.z);
                firstFloor = false;
            }
        }
    }

    // change color of buttonIndex with color given as parameter
    private void ButtonSetColor(int buttonIndex, Color color)
    {
        if (buttonIndex == 0)
            elevatorPanel.transform.Find("ChooseFloorButton").gameObject.GetComponent<Button>().GetComponent<Image>().color = color;
        else
            elevatorPanel.transform.Find("ChooseFloorButton (" + (buttonIndex-1).ToString() + ")").gameObject.GetComponent<Button>().GetComponent<Image>().color = color;
    }


    // activates or deactivates all bttons, depending on the given parameter
    private void InteractiveButtons(bool activate)
    {
        Button but = elevatorPanel.transform.Find("ChooseFloorButton").gameObject.GetComponent<Button>();
        but.interactable = activate;
        if (activate == false)
            but.animator.enabled = false;

        if (activate == true && but.animator.enabled == false)
            but.animator.enabled = true;

        for (int i=0;i<maxFloor;i++)
        {
            string name = "ChooseFloorButton (" + i.ToString() + ")";
            Button button = elevatorPanel.transform.Find(name).gameObject.GetComponent<Button>();
            button.interactable = activate;

            if (activate == false)
                button.animator.enabled = false;
            
            if (activate == true && button.animator.enabled == false)
                button.animator.enabled = true;
        }
    }

    // UPDATE FUNCTION
    private void Update()
    {
        if (floorChanged)
        {
            if (m_floorToGo != currentFloor)
            {
                InteractiveButtons(false);
                MoveTo(m_floorToGo);
            }
            else
            {
                InteractiveButtons(true);
                elevatorPanel.transform.Find("ChooseFloorButton (" + m_floorToGo.ToString() + ")").GetComponent<Image>().color = Color.white;
                floorChanged = false;
                firstFloor = true;
                colorSetToFinalFloor = false;
            }
        }
    }
}
