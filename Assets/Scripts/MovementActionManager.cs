using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class MovementActionManager : MonoBehaviour
{
    public UnityEvent<int> setMoving;
    public UnityEvent jump;
    public UnityEvent jumpStop;
    public UnityEvent punch;
    public UnityEvent kick;
    public UnityEvent punch_power;
    public UnityEvent kick_power;
    public UnityEvent enter_door;

    public void OnMoveAction(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            int facingRight = context.ReadValue<float>() > 0 ? 1 : -1;
            setMoving.Invoke(facingRight);
        }
        if (context.canceled)
        {
            setMoving.Invoke(0);
        }
    }

    public void OnJumpAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            jump.Invoke();
        }
    }

    public void OnJumpHoldAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            jumpStop.Invoke();
        }
        else if (context.canceled)
        {
            jumpStop.Invoke();
        }
    }

    public void OnPunchAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            punch.Invoke();
        }
    }

    public void OnKickAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            kick.Invoke();
        }
    }

    public void OnPunchPower(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            punch_power.Invoke();
        }
    }

    public void OnKickPower(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            kick_power.Invoke();
        }
    }

    public void OnEnterDoorAction (InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            enter_door.Invoke();
        }
    }
}
