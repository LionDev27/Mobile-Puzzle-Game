using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowFinger : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rB;
    private Vector2 _dir;
    private Camera _mainCam;

    private void Awake()
    {
        _rB = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        _mainCam = Camera.main;
    }

    private void Update()
    {
        //Calculate
        if (Input.touchCount > 0)
        {
            _dir = _mainCam.ScreenToWorldPoint(Input.touches[0].position) - transform.position;
            _dir.Normalize();

            if(Vector2.Distance(transform.position, _mainCam.ScreenToWorldPoint(Input.touches[0].position)) < 0.05f)
            {
                _dir = Vector2.zero;
            }
        }
        else
        {
            _dir = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        _rB.velocity = _dir * _speed * Time.fixedDeltaTime;
    }
}
