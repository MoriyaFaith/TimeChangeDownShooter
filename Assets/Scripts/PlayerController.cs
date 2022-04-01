using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject crewmatePrefab;
    private GameInputActions _inputActions;
    private Rigidbody2D _rigidbody;
    [SerializeField] private float jumpHeight;
    private Animator _animator;
    
 
 
    
    
    private Vector2 _facingVector = Vector2.right;
    
    // Start is called before the first frame update
    void Start()
    {
        _inputActions = new GameInputActions();
        _inputActions.Player.Enable();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        //transform.position = new Vector2(3, -1);
        //Invoke(nameof(AcceptDefeat), 10);
    }
    // Update is called once per frame
    void Update()
    {
        if (_inputActions.Player.Fire.WasPerformedThisFrame())
        {
           
           
        }
    }


    private void FixedUpdate()
    {

        var dir = _inputActions.Player.Move.ReadValue<Vector2>();
        _rigidbody.velocity = dir * 6;

        if (dir.magnitude > 0.5)
        {
            _facingVector = dir;
            _animator.Play("Player Run");
        }

        else

        {
            
            _animator.Play("Player Idle");
        }
    }


    private void AcceptDefeat()
            {
                 Destroy(gameObject);
            }
    }