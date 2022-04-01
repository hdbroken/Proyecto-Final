using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCC : MonoBehaviour
{
    [SerializeField]
    private PlayerData _playerData;

    private float _hMouse;
    private float _vMouse;
    private CharacterController _ccPlayer;
    private Camera _headCamera;

    private Shoot _fire;
    private Animator _playerAnimator;
    private bool _isDead = false;

    private void OnPausedGameEvent(bool obj)
    {
        this.enabled = !obj;
    }

    private void Awake()
    {
        EventManager.onPauseGame += OnPausedGameEvent;
        _playerAnimator = GetComponentInChildren<Animator>();
        _ccPlayer = GetComponent<CharacterController>();
        _headCamera = GetComponentInChildren<Camera>();
        _fire = GetComponent<Shoot>();
        Debug.Log(_playerData.limitHeadDown);
    }
    private void OnDestroy()
    {
        EventManager.onPauseGame -= OnPausedGameEvent;
    }

    void Update()
    {
        TouchTheFloor();
        Movement();
        _fire.Shooting(_headCamera);
    }

    private void Movement()
    {
        if (PlayerIsGrounded())
            MoveFeet();

        MoveHead();
    }

    private bool PlayerIsGrounded()
    {
        if (_ccPlayer.isGrounded) 
            return true;
        else
            return false;
    }

    private void MoveHead()
    {
        if (!_isDead)
        {
            Quaternion vAngle = new Quaternion();
            Quaternion hAngle = new Quaternion();
        
            DirectionToLook(ref vAngle, ref hAngle);
            Look(vAngle, hAngle);
        }
    }

    private void DirectionToLook(ref Quaternion vAngle, ref Quaternion hAngle)
    {
        _hMouse += Input.GetAxis("Mouse X") * _playerData.horizontalSensitivity;
        _vMouse -= Input.GetAxis("Mouse Y") * _playerData.verticalSensitivity;
        _vMouse = Mathf.Clamp(_vMouse, _playerData.limitHeadDown, _playerData.limitHeadUp);
        vAngle = Quaternion.Euler(_vMouse, 0, 0);
        hAngle = Quaternion.Euler(0, _hMouse, 0);        
    }

    private void Look(Quaternion vAngle, Quaternion hAngle)
    {
        _headCamera.transform.localRotation = vAngle;
        transform.localRotation = hAngle;
    }

    private void MoveFeet()
    {
        if (IsRun())
        {
            Move(DirectionToMove(), _playerData.runSpeed);
        }
        else
        {
            Move(DirectionToMove(), _playerData.walkSpeed);
        }
    }

    private Vector3 DirectionToMove()
    {
        float hKeyboardAxis = Input.GetAxisRaw("Horizontal");
        float vkeyboardAxis = Input.GetAxisRaw("Vertical");
        Vector3 directionToMove = new Vector3(hKeyboardAxis, 0f, vkeyboardAxis);
        
        return directionToMove;
    }

    private bool IsRun()
    {
        if (Input.GetKey(KeyCode.LeftShift)) return true;
        else return false;
    }

    private void Move(Vector3 directionToMove, float speed)
    {
        _ccPlayer.Move(transform.TransformDirection(directionToMove) * speed * Time.deltaTime);
    }

    private void TouchTheFloor()
    {
        _ccPlayer.Move(transform.TransformDirection(Vector3.down) * _playerData.gravity * Time.deltaTime);
    }

    IEnumerator SmoothLook()
    {
        float angleDown = 0;

        Quaternion lookDownAngle = new Quaternion();
        
        Quaternion samelook = transform.localRotation;
        
        while (angleDown < -_playerData.limitHeadDown)
        {
            Debug.Log(angleDown);
            Debug.Log(lookDownAngle);
            lookDownAngle = Quaternion.Euler(angleDown, 0, 0);
            Look(lookDownAngle, samelook);            
            yield return new WaitForSeconds(0.025f);
            angleDown += 0.5f;
        }
    }
    public void LookOnDeath()
    {
        _isDead = true;
        StartCoroutine(SmoothLook());
    }

    public void StopMove()
    {
        this.enabled = false;
        _playerAnimator.enabled = false;
    }
}
