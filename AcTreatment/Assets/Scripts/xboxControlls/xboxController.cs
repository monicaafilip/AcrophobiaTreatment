using UnityEngine;

public class xboxController : MonoBehaviour
{
    InputController ctrl;

    private void Awake()
    {
        Debug.Log("awake");
        ctrl = new InputController();
    }

    void Update()
    {
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
