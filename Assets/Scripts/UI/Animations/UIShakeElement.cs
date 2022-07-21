using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShakeElement : MonoBehaviour
{
    public RectTransform element;

    [Header("Shake animation settings")]
    public float animationTime = 0.5f;
    public float shakeStrength = 90f;
    public float randomness = 90;
    public int vibrato = 90;
    public bool fadeOut = true;
    public float delayBetweenShakes = 3;

    Sequence sequence;

    private void Start()
    {
        sequence = DOTween.Sequence();
        sequence.Append(element.DOShakeRotation(animationTime, shakeStrength, vibrato, randomness, fadeOut));
        sequence.SetLoops(-1, LoopType.Restart);
        sequence.AppendInterval(delayBetweenShakes);
        sequence.Play();
    }

    public void OnDestroy()
    {
        if (sequence != null)
            sequence.Kill();
    }
}
