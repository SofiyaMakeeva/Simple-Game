using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask _groundLayer;

    private float _groundRadius = 0.5f;
    private int _angle = 180;

    private bool _isGrounded;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundChecker.position, _groundRadius, _groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == true) 
        {
            _animator.SetTrigger("Jump");
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Walk(0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Walk(_angle);
        }
        else
        {
            _animator.SetBool("Walk", false);
        }
    }

    private void Walk(int angle)
    {
        _animator.SetBool("Walk", true);
        transform.Translate(_speed * Time.deltaTime, 0, 0);
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
