using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFallingObjects : MonoBehaviour
{
    public LayerMask ObjectsToDestroyLayerMask;
    public Vector2 size;

    [Header("Gizmos param")]
    public Color gizmosColor = Color.red;
    public bool showGizmos = true;

    private void FixedUpdate()
    {
        var collider = Physics2D.OverlapBox(this.transform.position,
            size,
            0,
            ObjectsToDestroyLayerMask);
        if(collider != null)
        {
            var agent = collider.GetComponent<Agent>();
            if(agent == null)
            {
                Destroy(agent.gameObject);
                return;
            }
            var damagable = agent.GetComponent<Damagable>();
            if (damagable != null)
                damagable.GetHit(1);
            agent.AgentDied();
        }
    }

    private void OnDrawGizmos()
    {
        if (showGizmos)
        {
            Gizmos.color = gizmosColor; 
            Gizmos.DrawWireCube(this.transform.position, size);
        }
    }
}
