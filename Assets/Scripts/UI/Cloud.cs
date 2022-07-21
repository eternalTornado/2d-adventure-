using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Cloud : MonoBehaviour
{
    [SerializeField] private float minScale = 1f;
    [SerializeField] private float maxScale = 1.5f;

    public float speed = 70;

    public event Action OnOutsideScreen;
    public float outsideScreenDistance;

    private void Update()
    {
        this.transform.position += Vector3.right * speed * Time.deltaTime;
        if(Vector3.Distance(this.transform.parent.transform.position, this.transform.position) > outsideScreenDistance)
        {
            OnOutsideScreen?.Invoke();
            Destroy(this.gameObject);
        }
    }

    public float GetCloudScale()
    {
        return Random.Range(minScale, maxScale);
    }

    public void Initialize(float distance, Action OnOutsideScreenHandler)
    {
        outsideScreenDistance = distance;
        OnOutsideScreen += OnOutsideScreenHandler;
    }
}
