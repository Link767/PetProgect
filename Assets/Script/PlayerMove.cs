using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed = 6f;
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
}
