using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightFeedback : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float feedbackTime = 0.1f;

    public void PlayFeeback()
    {
        if (spriteRenderer == null || !spriteRenderer.material.HasProperty("_MakeSolidColor"))
        {
            Debug.LogError(spriteRenderer.material.HasProperty("_MakeSolidColor"));
            return;
        }

        ToggleMaterial(1);
        StopAllCoroutines();
        StartCoroutine(ResetColor());
    }

    private void ToggleMaterial(int value)
    {
        value = Mathf.Clamp(value, 0, 1);
        spriteRenderer.material.SetInt("_MakeSolidColor", value);
    }

    private IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(feedbackTime);
        ToggleMaterial(0);
    }
}
