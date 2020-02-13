using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class RelativeMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    public float jumpSpeed = 15f;
    public float gravity = -9.8f;
    public float terminalVelocity = -10f;
    public float minFall = -1.5f;
    public float rotSpeed;
    public float moveSpeed = 6.0f;

    private CharacterController _charController;
    private float _vertSpeed;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _vertSpeed = minFall;
        _charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;

        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        if (horInput != 0 || vertInput != 0)
        {
            _animator.SetBool("run", true);
            print("-");
            movement.x = horInput * moveSpeed;
            movement.z = vertInput * moveSpeed;
            movement = Vector3.ClampMagnitude(movement, moveSpeed);

            Quaternion tmp = target.rotation;
            target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
            movement = target.TransformDirection(movement);
            target.rotation = tmp;

            Quaternion direction = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotSpeed * Time.deltaTime);

        }
        else
        {
            _animator.SetBool("run", false);
            print("+");
        }
        if (_charController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                _vertSpeed = jumpSpeed;
                _animator.SetBool("jump", true);
            }
            else
            {
                _vertSpeed = minFall;
                _animator.SetBool("jump", false);
            }
        }
        else
        {
            _vertSpeed += gravity * 5 * Time.deltaTime;
            _animator.SetBool("falling", true);
            if (_vertSpeed < terminalVelocity)
            {
                _vertSpeed = terminalVelocity;
                _animator.SetBool("falling", false);
            }
        }
        movement.y = _vertSpeed;

        movement *= Time.deltaTime;
        _charController.Move(movement);
    }
}
