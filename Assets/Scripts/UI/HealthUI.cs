using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    private List<LifeElementUI> healthImages;
    [SerializeField] private Sprite fullHealth;
    [SerializeField] private Sprite emptyHealth;
    [SerializeField] LifeElementUI healthPrefab;

    private void Start()
    {
        Initialize(5);
    }

    public void Initialize(int maxHealth)
    {
        healthImages = new List<LifeElementUI>();
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        for(int i = 0; i< maxHealth; i++)
        {
            var life = Instantiate(healthPrefab);
            life.transform.SetParent(transform, false);
            healthImages.Add(life);
        }
    }

    public void SetHealth(int currentHealth)
    {
        for(int i = 0; i < healthImages.Count; i++)
        {
            healthImages[i].SetSprite(i < currentHealth ? fullHealth : emptyHealth);
        }
    }
}
