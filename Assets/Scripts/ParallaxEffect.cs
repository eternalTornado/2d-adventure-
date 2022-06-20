using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{

    [Range(0f, 1f)]
    public float moveSpeed;
    private Camera mainCamera => Camera.main;

    private Transform myTransform;
    private void Awake()
    {
        myTransform = this.transform;
    }

    private void FixedUpdate()
    {
        myTransform.position = new Vector2(mainCamera.transform.position.x * moveSpeed, myTransform.position.y);
    }

}
