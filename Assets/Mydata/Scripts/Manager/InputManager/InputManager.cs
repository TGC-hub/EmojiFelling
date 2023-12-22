
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance => instance;

    private bool enableZoom = false;
    public bool EnableZoom => enableZoom;

    public bool lockInput = false;

    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    private void Update()
    {
        if (lockInput == true) return;
        if (IsPointerOverUIObjects()) return;
        GetKeyZoom();
    }

    protected virtual void GetKeyZoom()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            enableZoom = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            enableZoom = false;
        }
    }

    public bool IsPointerOverUIObjects()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }
}
