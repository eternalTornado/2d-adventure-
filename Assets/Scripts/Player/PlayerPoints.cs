using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerPoints : MonoBehaviour
{
    public UnityEvent<int> OnPointsValueChanged;
    public UnityEvent OnPickupPoints;
    private int points = 0;

    public int Points
    {
        get { return points; }
        private set { points = value; }
    }

    private void Start()
    {
        OnPointsValueChanged?.Invoke(Points);
    }

    public void Add(int amount)
    {
        Points += amount;
        OnPickupPoints?.Invoke();
        OnPointsValueChanged?.Invoke(Points);
    }
}
