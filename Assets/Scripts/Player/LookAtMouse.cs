using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookAtMouse : MonoBehaviour
{
    
    private GameInputActions _inputActions;
    private bool usingMouse = false;
    
    void Start()
    {
        _inputActions = new GameInputActions();
        _inputActions.Player.Enable();
    }
    void Update()
    {
        InputSystem.onDeviceChange +=
            (device, change) =>
            {
                switch (change)
                {
                    case InputDeviceChange.Added:
                        Debug.Log("New device added: " + device);
                        break;

                    case InputDeviceChange.Removed:
                        Debug.Log("Device removed: " + device);
                        break;
                }
            };
        
        Vector2 dirMouse = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var dirStick = _inputActions.Player.Look.ReadValue<Vector2>();

        var dir = (dirStick != Vector2.zero) ? dirStick : dirMouse;
        
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (dir != Vector2.zero)
        {
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
