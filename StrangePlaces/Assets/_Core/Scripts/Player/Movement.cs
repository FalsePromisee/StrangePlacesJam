using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _gravity = 9f;

    [SerializeField] private float _sensetivity;

    private Transform _playerCamer;
    private CharacterController _playerController;

    private Vector3 moveDirection;
    private void Awake()
    {
        _playerController = GetComponent<CharacterController>();
        _playerCamer = GetComponentInChildren<Camera>().transform;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        CameraRotation();
        PlayerMovement();

    }

    private void PlayerMovement()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * _moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * _moveSpeed);
        moveDirection = transform.TransformDirection(moveDirection);

        if (_playerController.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection.y = _jumpForce;
            }
            else
            {
                moveDirection.y = 0;
            }
        }

        moveDirection.y -= _gravity * Time.deltaTime;
        _playerController.Move(moveDirection * Time.deltaTime);
    }

    private void CameraRotation()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * _sensetivity, 0);

        _playerCamer.Rotate(-Input.GetAxis("Mouse Y") * _sensetivity, 0, 0);

        if (_playerCamer.localRotation.eulerAngles.y != 0)
        {
            _playerCamer.Rotate(Input.GetAxis("Mouse Y") * _sensetivity, 0, 0);
        }
    }

    public void PauseController() => StartCoroutine(PauseContorllerCoroutine());

    private IEnumerator PauseContorllerCoroutine()
    {
        _playerController.enabled = false;
        yield return new WaitForSeconds(0.05f);
        _playerController.enabled = true;
    }




}
