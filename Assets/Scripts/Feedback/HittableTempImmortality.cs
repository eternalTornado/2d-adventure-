using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;

public class HittableTempImmortality : MonoBehaviour, IHittable
{
    public Collider2D[] colliders;
    public float immortalityTime = 1;

    public SpriteRenderer spriteRenderer;
    public float flashDelay = 0.1f;
    [Range(0f, 1f)]
    public float flashAlpha = 0.5f;

    [Header("For Debug purposes")]
    public bool isImmortal = false;

    private void Awake()
    {
        colliders = this.GetComponents<Collider2D>();
    }

    public void GetHit(GameObject gameObject, int weaponDamage)
    {
        if (!this.enabled)
            return;
        ToggleColliders(false);
        StartCoroutine(ResetColliders());
        StartCoroutine(Flash(flashAlpha));
    }

    private void ToggleColliders(bool value)
    {
        isImmortal = value;
        foreach (var col in colliders)
            col.enabled = value;
    }

    private IEnumerator ResetColliders()
    {
        yield return new WaitForSeconds(immortalityTime);
        StopAllCoroutines();
        ToggleColliders(true);
        ChangeSpriteRendererColorAlpha(1);
    }

    private void ChangeSpriteRendererColorAlpha(float alpha)
    {
        Color c = spriteRenderer.color;
        c.a = alpha;
        spriteRenderer.color = c;
    }

    private IEnumerator Flash(float alpha)
    {
        alpha = Mathf.Clamp01(alpha);
        ChangeSpriteRendererColorAlpha(alpha);
        yield return new WaitForSeconds(flashDelay);
        StartCoroutine(Flash(alpha < 1 ? 1 : flashAlpha));
    }
}
