using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] float _speed = 15f;
    [SerializeField] float _lifeTime = 3;
    [SerializeField] private int damage = 5;
    [SerializeField] private string tagToDamage;
    [SerializeField] private Transform firepoint;
    private float dir;

    public void SetDirection(Vector2 unused)
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir = dir.normalized;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        GetComponent<Rigidbody2D>().velocity = dir * _speed;
        Invoke(nameof(Vanish), _lifeTime);
    }

    private void Vanish()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag(tagToDamage))
        {
            other.transform.GetComponent<HealthSystem>()?.Damage(damage);
        }
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        //create a smoke puff to signify the object being destroyed
        throw new NotImplementedException();
    }
}
