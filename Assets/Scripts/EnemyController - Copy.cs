using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float patrolDelay = 1.5f;
    [SerializeField] private float patrolSpeed = 3;
    [SerializeField] private int contactDamage = 3;
    private Rigidbody2D _rigidbody;
    private Vector2 _direction = Vector2.right;
    private Vector2 _patrolTargetPosition;
    private WaypointPath _waypointPath;
    

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _waypointPath = GetComponentInChildren<WaypointPath>();

    }
    void Start()
    {
        StartCoroutine(nameof(Patrol));
    }

    

    IEnumerator Patrol()
    {
        if (_waypointPath)
        {
            _patrolTargetPosition = _waypointPath.GetNextWaypointPosition();
        }
        else 
        {

        while (true)
        
            _direction = new Vector2(1, -1);
            yield return new WaitForSeconds(patrolDelay);
            _direction = new Vector2(-1, 1);
            yield return new WaitForSeconds(patrolDelay);
        }

        yield break;
    }
    
    void Update()
    {
        var dir = _rigidbody.velocity;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    
    private void FixedUpdate()
    {
        if (!_waypointPath) return;
            Vector2 dir = _patrolTargetPosition - (Vector2)transform.position;
    
            if (dir.magnitude <= 0.1)
            {
                _patrolTargetPosition = _waypointPath.GetNextWaypointPosition();
                dir = _patrolTargetPosition - (Vector2)transform.position;
            }
    
            _rigidbody.velocity = dir.normalized * patrolSpeed;
        }
    public void AcceptDefeat()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.transform.CompareTag("Player"))
        {
            other.transform.GetComponent<HealthSystem>()?.Damage(contactDamage);
        }
    }
    
}
