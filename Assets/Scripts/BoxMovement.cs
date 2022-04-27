using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    [SerializeField] private int pushSpeed = 5;
    [SerializeField] private bool touchingPlayer;
    [SerializeField] private string tagToPush;
    private Rigidbody2D _rigidbody;


    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision other)
    {
        if (other.transform.CompareTag(tagToPush))
        {
            touchingPlayer = true;
            _rigidbody.velocity = new Vector2(500, 500);
        }
    }

    private void OnCollisionExit2D(Collision other)
    {
        if (other.transform.CompareTag(tagToPush))
        {
            touchingPlayer = false;
        }
    }

    void FixedUpdate()
    {
        
    }
}
