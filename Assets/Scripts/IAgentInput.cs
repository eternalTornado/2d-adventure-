using System;
using UnityEngine;

public interface IAgentInput
{
    Vector2 movementVector { get; set; }

    event Action OnAttack;
    event Action OnJumpPressed;
    event Action OnJumpReleased;
    event Action<Vector2> OnMovement;
    event Action OnWeaponChange;
}