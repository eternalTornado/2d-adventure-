using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] HealthUI healthUI;
    [SerializeField] PointUI pointUI;

    public void InitializeHealth(int maxHealth)
    {
        healthUI.Initialize(maxHealth);
    }

    public void SetHealth(int currentHealth)
    {
        healthUI.SetHealth(currentHealth);
    }

    public void SetPoint(int value)
    {
        pointUI.SetPoints(value);
    }
}
