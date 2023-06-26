using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float _playerMovemenetSpeed = 2.0f;
    [SerializeField] private float _rotationFactorPerFrame = 10.0f;
    [SerializeField] private float _dashSpeed = 5.0f;
    private CharacterController _characterController;
    public PlayerInput PlayerInput;
    private Vector2 _currentMovementInput;
    private Vector3 _currentMovement;
    private Animator _animator;
    private bool _isMovementPressed;
    private bool _isRun;
    private bool _isJump;
    private bool _isDash;
    private bool _isDashReady = true;
    private float _dashTime = .25f;
    private float _dashTimer = 0;
    private float _dashReUseTime = 10.0f;
    private float _dashReUseTimer;
    private readonly int _isWalk = Animator.StringToHash("isWalk");

    private void Awake()
    {
        PlayerInput = new PlayerInput();
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();

        PlayerInput.PlayerMovement.Move.started += OnMovementInput;
        PlayerInput.PlayerMovement.Move.canceled += OnMovementInput;
        PlayerInput.PlayerMovement.Move.performed += OnMovementInput;

        PlayerInput.PlayerMovement.Run.started += OnRun;
        PlayerInput.PlayerMovement.Run.canceled += OnRun;

        PlayerInput.PlayerMovement.Jump.started += OnJump;
        PlayerInput.PlayerMovement.Jump.canceled += OnJump;

        PlayerInput.PlayerMovement.Dash.started += OnDash;
        PlayerInput.PlayerMovement.Dash.performed += OnDash;
    }


    private void Update()
    {
        _characterController.Move(_currentMovement * (_playerMovemenetSpeed * Time.deltaTime));
        SetRotation();
        HandleAnimation();
        if (_isDash)
        {
            _characterController.Move(transform.forward * (_dashSpeed * Time.deltaTime));
            _dashTimer += Time.deltaTime;
            _dashReUseTimer += Time.deltaTime;
            if (_dashTimer >= _dashTime)
            {
                _dashTimer = 0;
                _isDash = false;
            }
        }

        if (_dashReUseTimer > 0.1)
        {
            _dashReUseTimer += Time.deltaTime;
            if (_dashReUseTimer >= _dashReUseTime)
            {
                _isDashReady = true;
                _dashReUseTimer = 0;
            }
        }
    }

    private void OnMovementInput(InputAction.CallbackContext context)
    {
        _currentMovementInput = context.ReadValue<Vector2>();
        _currentMovement.x = _currentMovementInput.x;
        _currentMovement.z = _currentMovementInput.y;
        _isMovementPressed = _currentMovementInput.x != 0 || _currentMovementInput.y != 0;
    }

    private void OnRun(InputAction.CallbackContext context)
    {
        _isRun = context.ReadValueAsButton();
        if (_isRun)
        {
            _playerMovemenetSpeed *= 2;
        }
        else
        {
            _playerMovemenetSpeed /= 2;
        }
    }

    private void OnDash(InputAction.CallbackContext context)
    {
        if (_isDash == false && _isDashReady == true)
        {
            _isDash = context.ReadValueAsButton();
            _isDashReady = false;
        }
    }


    private void OnJump(InputAction.CallbackContext context)
    {
        _isJump = context.ReadValueAsButton();

        if (_isJump)
        {
            transform.GetComponent<Rigidbody>().AddForce(Vector3.back * 200);
        }
    }

    private void HandleAnimation()
    {
        _animator.SetBool(_isWalk, _isMovementPressed);
        _animator.SetBool("isRun", _isRun);
    }

    private void SetRotation()
    {
        Vector3 positionToLookAt = new Vector3(_currentMovement.x, 0.0f, _currentMovement.z);

        Quaternion currentRotation = transform.rotation;

        if (_isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation =
                Quaternion.Slerp(currentRotation, targetRotation, _rotationFactorPerFrame * Time.deltaTime);
        }
    }

    private void OnEnable()
    {
        PlayerInput.PlayerMovement.Enable();
    }

    private void OnDisable()
    {
        PlayerInput.PlayerMovement.Disable();
    }
}