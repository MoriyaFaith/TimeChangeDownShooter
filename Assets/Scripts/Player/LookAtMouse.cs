using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    
    private GameInputActions _inputActions;
    
    void Start()
    {
        _inputActions = new GameInputActions();
        _inputActions.Player.Enable();
    }
    void Update()
    {
        //var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var dir = _inputActions.Player.Look.ReadValue<Vector2>();
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (dir != Vector2.zero)
        {
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
