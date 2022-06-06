using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public Vector2 movementVector { get; set; }

    public event Action OnAttack, OnJumpPressed, OnJumpReleased, OnWeaponChange;

    public event Action<Vector2> OnMovement;

    public KeyCode jumpKey, attackKey, menuKey;

    public UnityEvent OnMenuKeyPressed;

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            GetMovementInput();
            GetJumpInput();
            GetAttackInput();
            GetWeaponSwapInput();
        }

        GetMenuInput();
    }

    private void GetJumpInput()
    {
        if (Input.GetKeyDown(jumpKey))
            OnJumpPressed?.Invoke();

        if (Input.GetKeyUp(jumpKey))
            OnJumpReleased?.Invoke();   
    }

    private void GetAttackInput()
    {
        if (Input.GetKeyDown(attackKey))
            OnAttack?.Invoke();
    }

    private void GetWeaponSwapInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
            OnWeaponChange?.Invoke();
    }

    private void GetMenuInput()
    {
        if (Input.GetKeyDown(menuKey))
            OnMenuKeyPressed?.Invoke();
    }

    private void GetMovementInput()
    {
        OnMovement?.Invoke(GetMovementVector());
    }

    protected Vector2 GetMovementVector()
    {
        movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        return movementVector;
    }
}
