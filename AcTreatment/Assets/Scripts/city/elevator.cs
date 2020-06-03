using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Vector3 floorDist;
    public float speed = 1.0f;
    public int floor = 0;
    public int maxFloor = 1;
    public Rigidbody movePlatform;
    private float tTotal;
    private bool isMoving;
    private float moveDirection;

    InputController inputCtrl;

    private void Awake()
    {
        Debug.Log("elevator awake() -> input controlls set up");
        inputCtrl = new InputController();
        inputCtrl.gameplay.Up.performed += x => StartMoveUp();
        inputCtrl.gameplay.Down.performed += x => StartMoveDown();
    }
    private void Start()
    {
        floorDist = new Vector3(0, 2.1f, 0);
        Debug.Log(floorDist);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.U))
            StartMoveUp();

        if (Input.GetKey(KeyCode.I))
            StartMoveDown();

        if (isMoving)
            MoveElevator();
    }
    void MoveElevator()
    {
        var v = moveDirection * floorDist * speed;
        var t = Time.deltaTime;
        var tMax = floorDist.magnitude / speed;
        t = Mathf.Min(t, tMax - tTotal);
        movePlatform.MovePosition(v * t + movePlatform.gameObject.transform.position);
        tTotal += t;
        //Debug.Log(floor.ToString() + ":" + (v * t + movePlatform.gameObject.transform.position).ToString());
        if(tTotal >= tMax)
        {
            //we are at floor
            isMoving = false;
            tTotal = 0;
            floor += (int)moveDirection;
        }
    }

    //start moving up one floor
    public void StartMoveUp()
    {
        if (isMoving)
            return;
        isMoving = true;
        moveDirection = 1;
    }
    //start moving down one floor
    public void StartMoveDown()
    {
        if (isMoving)
            return;
        isMoving = true;
        moveDirection = -1;
    }

    public void CallElevator()
    {
        if (isMoving)
            return;
        //start moving
        if (floor < maxFloor)
            StartMoveUp();
        else
            StartMoveDown();
    }

    private void OnEnable()
    {
        inputCtrl.Enable();
    }
    private void OnDisable()
    {
        inputCtrl.Disable();
    }
}
