using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScaleElement : MonoBehaviour
{
    private Sequence sequence;

    [SerializeField] RectTransform element;
    [SerializeField] private float animationEndScale;
    [SerializeField] private float animationTime;
    private float baseScaleValue;
    private Vector3 baseScale, endScale;
    [SerializeField] private bool playConstantly = false;

    private void Start()
    {
        baseScale = element.localScale;
        endScale = Vector3.one * animationEndScale;

        if (playConstantly)
        {
            sequence = DOTween.Sequence();
            sequence.Append(element.DOScale(baseScale, animationTime));
            sequence.Append(element.DOScale(endScale, animationTime));
            sequence.SetLoops(-1, LoopType.Yoyo);
            sequence.Play();
        }
    }

    public void PlayAnimation()
    {
        StopAllCoroutines();
        element.localScale = baseScale;
        StartCoroutine(ScaleImage(true));
    }

    public IEnumerator ScaleImage(bool scaleUp)
    {
        float time = 0f;
        while(time < animationTime)
        {
            time += Time.deltaTime;
            var value = (time / animationTime);
            Vector3 currentScale;
            if (scaleUp)
            {
                currentScale = baseScale + value * (endScale - baseScale);
            }
            else
            {
                currentScale = endScale - value * (endScale - baseScale);
            }
            element.localScale = currentScale;
            yield return null;
        }

        element.localScale = scaleUp ? endScale : baseScale;
        if (playConstantly || scaleUp == true)
            StartCoroutine(ScaleImage(!scaleUp));
    }

    private void OnDestroy()
    {
        if (sequence != null)
            sequence.Kill();
    }
}
