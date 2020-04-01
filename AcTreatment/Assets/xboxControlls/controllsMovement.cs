using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllsMovement : MonoBehaviour
{
    InputController ctrl;

    Vector2 move;
    Vector2 rotate;
    private void Awake()
    {
        Debug.Log("awake");
        ctrl = new InputController();
        ctrl.gameplay.Move.performed += x => move = x.ReadValue<Vector2>();
        ctrl.gameplay.Move.canceled += x => move = Vector2.zero;
    }

    void Update()
    {
        Vector3 m = new Vector3(move.x, 0, move.y) * Time.deltaTime;
        transform.Translate(m, Space.World);
    }

    private void OnEnable()
    {
        Debug.Log("enable");
        ctrl.gameplay.Enable();
    }
    private void OnDisable()
    {
        ctrl.gameplay.Disable();
    }
}
