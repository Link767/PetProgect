using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private bool _faseRight = true;
    private Rigidbody2D _rb;
    private Animator _anim;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        MoveLogick();
        HorizontalRot();
    }

    private void MoveLogick()
    {
        float hor = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(hor,0);
        _rb.velocity = move * _speed;

        if (hor > 0)
        {
            _anim.SetBool("PlayerRun", true);
        }
        else 
        {
            _anim.SetBool("PlayerRun", false);
        }
    }

    private void HorizontalRot()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            _faseRight = true;
            Quaternion rot = transform.rotation;
            rot.y = 0;
            transform.rotation = rot;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            _faseRight = false;
            Quaternion rot = transform.rotation;
            rot.y = 180;
            transform.rotation = rot;
            _anim.SetBool("PlayerRun", true);
        }
    }
}
