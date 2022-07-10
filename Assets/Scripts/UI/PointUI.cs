using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class PointUI : MonoBehaviour
{
    private TextMeshProUGUI txtPoint;

    public UnityEvent OnTextChange;

    private void Awake()
    {
        txtPoint = this.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetPoints(int value)
    {
        txtPoint.text = value.ToString();
        OnTextChange?.Invoke();
    }
}
