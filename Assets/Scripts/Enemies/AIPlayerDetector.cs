using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayerDetector : MonoBehaviour
{
    [SerializeField] public bool PlayerDetected { get; private set; }

    public Vector2 DirectionToTarget => target.transform.position - detectorOrigin.position;

    [SerializeField] private Transform detectorOrigin;
    public Vector2 detectorSize = Vector2.zero;
    public Vector2 detectorOriginOffset = Vector2.zero;

    public float detectionDelay = 0.3f;
    public LayerMask detectorLayerMask;

    [Header("Gizmos Param")]
    public Color gizmosIdleColor = Color.green;
    public Color GizmosDetectedColor = Color.red;
    public bool showGizmos = true;

    private GameObject target;

    public GameObject Target
    {
        get => target;
        private set
        {
            target = value;
            PlayerDetected = target != null;
        }
    }

    private void Start()
    {
        StartCoroutine(DetectionCoroutine());
    }

    private IEnumerator DetectionCoroutine()
    {
        yield return new WaitForSeconds(detectionDelay);
        var collider = Physics2D.OverlapBox((Vector2)detectorOrigin.position + detectorOriginOffset,
            detectorSize,
            0,
            detectorLayerMask);
        if (collider != null)
        {
            Target = collider.gameObject;
        }
        else
            Target = null;
        StartCoroutine(DetectionCoroutine());
    }

    private void OnDrawGizmos()
    {
        if(showGizmos && detectorOrigin != null)
        {
            Gizmos.color = gizmosIdleColor;
            if (PlayerDetected)
                Gizmos.color = GizmosDetectedColor;
            Gizmos.DrawCube((Vector2)detectorOrigin.position + detectorOriginOffset, detectorSize);
        }
    }
}
