using System.Collections.Generic;
using UnityEngine;

public class xboxController : MonoBehaviour
{
    public GameObject canvas;
    public GameObject informations;

    public static GameObject currentActivePanel;
    public static List<GameObject> previousActiveMenus;

    private InputController ctrl;

    private void Awake()
    {
        Debug.Log("awake");
        ctrl = new InputController();

        ctrl.gameplay.Y.performed += x => ShowInformations();
        ctrl.gameplay.B.performed += x => GoToPrevious();

    }

    void Update()
    {
    }

    private void ShowInformations()
    {
        for (int i = 0; i < canvas.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).gameObject.activeSelf == true)
            {
                currentActivePanel = gameObject.transform.GetChild(i).gameObject;
            }
        }
        currentActivePanel.SetActive(false);
        previousActiveMenus.Add(currentActivePanel);
        currentActivePanel = informations;
        informations.SetActive(true);
    }

    private void GoToPrevious()
    {
        currentActivePanel.SetActive(false);
        GameObject previous = previousActiveMenus[previousActiveMenus.Count - 1];
        previous.SetActive(true);
        currentActivePanel = previous;
        previousActiveMenus.RemoveAt(previousActiveMenus.Count - 1);
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
