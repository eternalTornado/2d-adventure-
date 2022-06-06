using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentRenderer : MonoBehaviour
{
    public void FaceDirection(Vector2 direction)
    {
        if (direction.x < 0)
            transform.parent.localScale = new Vector3(-Mathf.Abs(transform.parent.localScale.x), transform.parent.localScale.y, transform.parent.localScale.z);
        else if (direction.x > 0)
            transform.parent.localScale = new Vector3(Mathf.Abs(transform.parent.localScale.x), transform.parent.localScale.y, transform.parent.localScale.z);

        // Keep the direction while idling
    }
}
