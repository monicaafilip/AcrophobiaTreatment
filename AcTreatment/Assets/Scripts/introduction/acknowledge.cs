using UnityEngine;

public class Acknowledge : MonoBehaviour
{
    public GameObject userManual;
    public GameObject initialPanel;

    public InputController input;

    private bool anyButtonPressed;

    private void Awake()
    {
        Debug.Log("awake");
        input = new InputController();
        
        // if any button was pressed
        input.gameplay.left_bumper.performed += x => anyButtonPressed = true;
        input.gameplay.right_bumper.performed += x => anyButtonPressed = true;
        input.gameplay.lefttrigger.performed += x => anyButtonPressed = true;
        input.gameplay.righttrigger.performed += x => anyButtonPressed = true;
        input.gameplay.anyButton_left.performed += x => anyButtonPressed = true;
        input.gameplay.X.performed += x => anyButtonPressed = true;
        input.gameplay.Y.performed += x => anyButtonPressed = true;
        input.gameplay.B.performed += x => anyButtonPressed = true;
        input.gameplay.A.performed += x => anyButtonPressed = true;
        input.gameplay.Menu.performed += x => anyButtonPressed = true;
        input.gameplay.View.performed += x => anyButtonPressed = true;
        input.gameplay.Move.performed += x => anyButtonPressed = true;
        input.gameplay.Up.performed += x => anyButtonPressed = true;
        input.gameplay.Down.performed += x => anyButtonPressed = true;
    }
    private void Start()
    {
        anyButtonPressed = false;
    }

    private void Update()
    {
        if (anyButtonPressed)
        {
            userManual.SetActive(false);
            initialPanel.SetActive(true);
        }

    }
    private void OnEnable()
    {
        Debug.Log("enable");
        input.gameplay.Enable();
    }
    private void OnDisable()
    {
        input.gameplay.Disable();
    }
}
