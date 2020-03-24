using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    public Vector3 floorDist = Vector3.up;
    public float speed = 1.0f;
    public int floor = 0;
    public int maxFloor = 1;
    public Rigidbody movePlatform;

    private float tTotal;
    private bool isMoving;
    private float moveDirection;


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
        var v = moveDirection * floorDist.normalized * speed;
        var t = Time.deltaTime;
        var tMax = floorDist.magnitude / speed;
        t = Mathf.Min(t, tMax - tTotal);
        movePlatform.MovePosition(v * t + movePlatform.gameObject.transform.position);
        tTotal += t;

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
    //public GameObject movePlatform;
    //public Rigidbody playerRb;
    //
    //private void OnTriggerStay(Collision other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        movePlatform.transform.position += movePlatform.transform.up * Time.deltaTime;
    //        playerRb.MovePosition(transform.position + playerRb.transform.up * Time.deltaTime);
    //    }
    //}
}
