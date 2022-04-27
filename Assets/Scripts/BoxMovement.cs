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
    private Vector2 playerVelocity;


    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag(tagToPush))
        {
            touchingPlayer = true;
            playerVelocity = other.gameObject.GetComponent<Rigidbody2D>().velocity;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.CompareTag(tagToPush))
        {
            touchingPlayer = false;
            _rigidbody.velocity = new Vector2(0, 0);
        }
    }

    void FixedUpdate()
    {
        if (touchingPlayer)
        {
            _rigidbody.velocity = playerVelocity * pushSpeed;
        }
    }
}
