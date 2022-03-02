using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCC : MonoBehaviour
{
    [SerializeField]
    private float _walkSpeed = 5;
    [SerializeField]
    private float _runSpeed = 10;
    [SerializeField]
    private float _gravity = 9.8f;

    

    [SerializeField]
    private float _HorizontalSensitibity = 2;
    [SerializeField]
    private float _VerticalSensitibity = 2;

    [SerializeField]
    private float _limitHeadUp = 60 ;
    [SerializeField]
    private float _limitHeadDown = 60;

    private float _hMouse;
    private float _vMouse;
    private CharacterController _ccPlayer;
    private Camera _headCamera;

    private Shoot _fire;
    private Animator _playerAnimator;


    void Awake()
    {
        _playerAnimator = GetComponentInChildren<Animator>();
        _ccPlayer = GetComponent<CharacterController>();
        _headCamera = GetComponentInChildren<Camera>();
        _fire = GetComponent<Shoot>();
        _limitHeadDown *= -1;
    }

    // Update is called once per frame
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
        if (_ccPlayer.isGrounded) return true;
        else return false;
    }
    
    private void MoveHead()
    {
        Quaternion vAngle = new Quaternion();
        Quaternion hAngle = new Quaternion();
        
        DirectionToLook(ref vAngle,ref hAngle);
        Look(ref vAngle,ref hAngle);          
    }

    private void DirectionToLook(ref Quaternion vAngle, ref Quaternion hAngle)
    {
        _hMouse += Input.GetAxis("Mouse X") * _HorizontalSensitibity;
        _vMouse -= Input.GetAxis("Mouse Y") * _VerticalSensitibity;
        _vMouse = Mathf.Clamp(_vMouse, _limitHeadDown, _limitHeadUp);
        vAngle = Quaternion.Euler(_vMouse, 0, 0);
        hAngle = Quaternion.Euler(0, _hMouse, 0);
    }

    private void Look(ref Quaternion vAngle, ref Quaternion hAngle)
    {
        _headCamera.transform.localRotation = vAngle;
        transform.localRotation = hAngle;
    }

    private void MoveFeet()
    {
        if (IsRun())
        {
            Move(DirectionToMove(),_runSpeed);
        }
        else
        {
            Move(DirectionToMove(),_walkSpeed);
        }        
    }
    
    private Vector3 DirectionToMove()
    {
        float hKeyboardAxis = Input.GetAxisRaw("Horizontal");
        float vkeyboardAxis = Input.GetAxisRaw("Vertical");
        Vector3 directionToMove = new Vector3(hKeyboardAxis, 0f, vkeyboardAxis);

        Animation(hKeyboardAxis, vkeyboardAxis, IsRun());

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
       _ccPlayer.Move(transform.TransformDirection(Vector3.down) * _gravity * Time.deltaTime);
    }

    private void Animation(float hKeyboardAxis, float vkeyboardAxis, bool isRun)
    {
        // IDLE
        if (hKeyboardAxis == 0 && vkeyboardAxis == 0)
        {
            _playerAnimator.SetBool("isWalk", false);
            _playerAnimator.SetBool("isRun", false);
            _playerAnimator.SetBool("isLeftStrafe", false);
            _playerAnimator.SetBool("isRightStrafe", false);
            _playerAnimator.SetBool("isWalkingBack", false);
        }
        if (!isRun)
        {
            _playerAnimator.SetBool("isRun", false);
            _playerAnimator.SetBool("isRunBack", false);
            _playerAnimator.SetBool("isRightStrafeRun", false);
            _playerAnimator.SetBool("isLeftStrafeRun", false);
            //WALK
            if (hKeyboardAxis == 0)
            {
                _playerAnimator.SetBool("isLeftStrafe", false);
                _playerAnimator.SetBool("isRightStrafe", false);
                //WALKING FORDWARD
                if (vkeyboardAxis > 0)
                {
                    _playerAnimator.SetBool("isWalk", true);
                    _playerAnimator.SetBool("isWalkingBack", false);
                }
                //WALKING BACK
                if (vkeyboardAxis < 0)
                {
                    _playerAnimator.SetBool("isWalk", false);
                    _playerAnimator.SetBool("isWalkingBack", true);
                }
            }
            //STRAFE
            if (vkeyboardAxis == 0)
            {
                _playerAnimator.SetBool("isWalk", false);
                _playerAnimator.SetBool("isWalkingBack", false);
                //LEFT STRAFE
                if (hKeyboardAxis < 0)
                {
                    _playerAnimator.SetBool("isLeftStrafe", true);
                    _playerAnimator.SetBool("isRightStrafe", false);
                }
                //RIGHT STRAFE
                if (hKeyboardAxis > 0)
                {
                    _playerAnimator.SetBool("isLeftStrafe", false);
                    _playerAnimator.SetBool("isRightStrafe", true);
                }
            }
            
        }
        /*if (isRun)
        {
            _playerAnimator.SetBool("isRun", true);
            _playerAnimator.SetBool("isWalk", true);
            //Run
            if (hKeyboardAxis == 0)
            {
                _playerAnimator.SetBool("isLeftStrafeRun", false);
                _playerAnimator.SetBool("isRightStrafeRun", false);
                //Running forward
                if (vkeyboardAxis > 0)
                {
                    _playerAnimator.SetBool("isWalk", true);
                    _playerAnimator.SetBool("isWalkingBack", false);
                }
                //Running back
                if (vkeyboardAxis < 0)
                {
                    _playerAnimator.SetBool("isWalk", false);
                    _playerAnimator.SetBool("isWalkingBack", true);
                }
            }
            //Strafe Run
            if (vkeyboardAxis == 0)
            {
                _playerAnimator.SetBool("isWalk", false);
                _playerAnimator.SetBool("isWalkingBack", false);
                //LEFT STRAFE
                if (hKeyboardAxis < 0)
                {
                    _playerAnimator.SetBool("isLeftStrafe", true);
                    _playerAnimator.SetBool("isRightStrafe", false);
                }
                //RIGHT STRAFE
                if (hKeyboardAxis > 0)
                {
                    _playerAnimator.SetBool("isLeftStrafe", false);
                    _playerAnimator.SetBool("isRightStrafe", true);
                }
            }

        }*/

    }
}
