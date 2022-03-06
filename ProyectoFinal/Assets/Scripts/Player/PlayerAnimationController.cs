using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        bool IsWalk = Input.GetKey(KeyCode.W);
        bool IsWalkingBack = Input.GetKey(KeyCode.S);
        bool IsRun = Input.GetKey(KeyCode.LeftShift);
        bool IsLStrafe = Input.GetKey(KeyCode.A);
        bool IsRStrafe = Input.GetKey(KeyCode.D);

        // IDLE
        _animator.SetBool("isWalk", false);
        _animator.SetBool("isRun", false);
        _animator.SetBool("isLStrafe", false);
        _animator.SetBool("isRStrafe", false);
        _animator.SetBool("isWalkingBack", false);
        _animator.SetBool("isRStrafeRun", false);
        _animator.SetBool("isLStrafeRun", false);
        //
        if (!IsRun)
        {
            _animator.SetBool("isRun", false);
            _animator.SetBool("isRunBack", false);
            _animator.SetBool("isRStrafeRun", false);
            _animator.SetBool("isLStrafeRun", false);
            //Walk
            if (!IsLStrafe && !IsRStrafe)
            {
                _animator.SetBool("isLStrafe", false);
                _animator.SetBool("isRStrafe", false);
                //Forward Walk
                if (IsWalk)
                {
                    _animator.SetBool("isWalk", true);
                }
                //Back Walk
                if (IsWalkingBack)
                {
                    _animator.SetBool("isWalkingBack", true);
                }
            }
            //Strafe
            if (!IsWalk && !IsWalkingBack)
            {
                _animator.SetBool("isWalk", false);
                _animator.SetBool("isWalkingBack", false);
                //LEFT STRAFE
                if (IsLStrafe)
                {
                    _animator.SetBool("isLStrafe", true);
                }
                //RIGHT STRAFE
                if (IsRStrafe)
                {
                    _animator.SetBool("isRStrafe", true);
                }
            }

            //Strafe + Walk
            if ((IsWalk || IsWalkingBack) && IsLStrafe)
            {
                _animator.SetBool("isLStrafe", true);
            }
            if ((IsWalk || IsWalkingBack) && IsRStrafe)
            {
                _animator.SetBool("isRStrafe", true);
            }

        }
        //Run
        if (IsRun)
        {
            _animator.SetBool("isRun", true);
            _animator.SetBool("isRunBack", false);
            _animator.SetBool("isRStrafe", false);
            _animator.SetBool("isLStrafe", false);
            //Walk
            if (!IsLStrafe && !IsRStrafe)
            {
                _animator.SetBool("isLStrafeRun", false);
                _animator.SetBool("isRStrafeRun", false);
                //Forward Run
                if (IsWalk)
                {
                    _animator.SetBool("isWalk", true);
                }
                //Back Run
                if (IsWalkingBack)
                {
                    _animator.SetBool("isWalkingBack", true);
                    _animator.SetBool("isRunBack", true);
                }
            }
            //Strafe Run
            if (!IsWalk && !IsWalkingBack)
            {
                _animator.SetBool("isWalk", false);
                _animator.SetBool("isWalkingBack", false);
                //LEFT STRAFE RUN
                if (IsLStrafe)
                {
                    _animator.SetBool("isLStrafe", true);
                    _animator.SetBool("isLStrafeRun", true);
                }
                //RIGHT STRAFE RUN
                if (IsRStrafe)
                {
                    _animator.SetBool("isRStrafe", true);
                    _animator.SetBool("isRStrafeRun", true);
                }
            }

            //Strafe + Run
            if ((IsWalk || IsWalkingBack) && IsLStrafe)
            {
                _animator.SetBool("isLStrafeRun", true);
            }
            if ((IsWalk || IsWalkingBack) && IsRStrafe)
            {
                _animator.SetBool("isRStrafeRun", true);
            }

        }
    }
}
            