using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyUtils : MonoBehaviour
{
    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }

    public void DestroyObject(GameObject target)
    {
        Destroy(target);
    }
}
