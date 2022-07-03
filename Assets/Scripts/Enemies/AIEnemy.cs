using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIEnemy : MonoBehaviour, IAgentInput
{
    public Vector2 movementVector { get; set; }

    public event Action OnAttack;
    public event Action OnJumpPressed;
    public event Action OnJumpReleased;
    public event Action<Vector2> OnMovement;
    public event Action OnWeaponChange;

    public void CallOnAttacke()
    {
        OnAttack?.Invoke();
    }

    public void CallOnJumpPressed()
    {
        OnJumpPressed?.Invoke();
    }

    public void CallOnJumpReleased()
    {
        OnJumpReleased?.Invoke();
    }

    public void CallOnWeaponChanged()
    {
        OnWeaponChange?.Invoke();
    }

    public void CallOnMovement(Vector2 movement)
    {
        OnMovement?.Invoke(movement);
    }
}
