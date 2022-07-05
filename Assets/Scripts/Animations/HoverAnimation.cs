using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HoverAnimation : MonoBehaviour
{
    public float movementDistance = 0.5f;
    public float animationDuration = 1;
    public Ease animationEase;

    private void Start()
    {
        transform.DOLocalMoveY(this.transform.localPosition.x + movementDistance, animationDuration)
            .SetEase(animationEase)
            .SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        DOTween.Kill(transform);
    }
}
