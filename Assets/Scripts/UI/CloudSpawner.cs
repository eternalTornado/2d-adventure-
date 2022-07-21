using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private float width = 1000f;
    [SerializeField] private float length = 1000f;

    [SerializeField] private Color gizmosColor = new Color(1f, 0f, 0f, 0.2f);
    [SerializeField] private bool showGizmos = true;

    [SerializeField] private List<Cloud> cloudPrefabs = new List<Cloud>();
    private RectTransform myRectTransform;

    [SerializeField] private float cloudSpeed = 50f;
    [SerializeField] private float scaleModifier = 0.5f;

    public Canvas canvas;

    private void Start()
    {
        foreach (var cloud in transform.GetComponentsInChildren<Cloud>())
        {
            cloud.Initialize((width / 2f) * canvas.scaleFactor + 50, SpawnClouds);
        }
    }

    private void SpawnClouds()
    {
        Vector3 position = GetRandomPosition();

        int cloudIndex = Random.Range(0, cloudPrefabs.Count);
        var cloud = cloudPrefabs[cloudIndex];

        float scale = cloud.GetCloudScale() + scaleModifier;

        GameObject cloudObject = GameObject.Instantiate(cloud.gameObject);

        RectTransform rectTransform = cloudObject.GetComponent<RectTransform>();

        rectTransform.position = position;
        rectTransform.localScale = Vector3.one * scale * canvas.scaleFactor;

        Cloud newCloud = cloudObject.GetComponent<Cloud>();

        newCloud.speed = cloudSpeed;

        rectTransform.SetParent(rectTransform);

        newCloud.Initialize((width / 2f) * canvas.scaleFactor + 50, SpawnClouds);
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(
                this.transform.position.x - (width/2f) * canvas.scaleFactor,
                Random.Range(this.transform.position.y - length / 2f * canvas.scaleFactor, this.transform.position.y + length / 2f * canvas.scaleFactor),
                1
            );
    }

    private void OnDrawGizmos()
    {
        if(showGizmos && canvas != null)
        {
            Gizmos.color = gizmosColor;
            Gizmos.DrawCube(transform.position, new Vector2(width, length) * canvas.scaleFactor);
        }
    }
}
