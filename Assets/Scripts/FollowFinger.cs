using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowFinger : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rB;

    private void Awake()
    {
        _rB = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
            pos.z = 0f;

            _rB.position = Vector2.Lerp(transform.position, pos, _speed * Time.fixedDeltaTime);
        }
    }
}
