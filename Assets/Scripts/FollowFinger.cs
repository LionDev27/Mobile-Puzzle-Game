using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowFinger : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rB;
    Vector2 dir;

    private void Awake()
    {
        _rB = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
    }

    private void Update()
    {
        //Calculate
        if (Input.touchCount > 0)
        {
            dir = Camera.main.ScreenToWorldPoint(Input.touches[0].position) - transform.position;
            dir.Normalize();
        }
    }

    private void FixedUpdate()
    {
        _rB.velocity = dir * _speed * Time.fixedDeltaTime;
    }
}
