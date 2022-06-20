using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RespawnSystem
{
    public class RespawnPoint : MonoBehaviour
    {
        [SerializeField] private GameObject respawnTarget;

        [SerializeField] UnityEvent OnSpawnPointActivated;

        private Collider2D myCollider;

        private void Start()
        {
            myCollider = this.GetComponent<Collider2D>();

            OnSpawnPointActivated.AddListener(() =>
            {
                GetComponentInParent<RespawnPointManager>().UpdateRespawnPoint(this);
            });
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                respawnTarget = collision.gameObject;
                OnSpawnPointActivated?.Invoke();
            }
        }

        public void RespawnPlayer()
        {
            respawnTarget.transform.position = this.transform.position;
        }

        public void SetPlayerGO(GameObject player)
        {
            respawnTarget = player;
            myCollider.enabled = false;
        }

        public void DisableRespawnPoint()
        {
            myCollider.enabled = false;
        }

        public void ResetRespawnPoint()
        {
            respawnTarget = null;
            myCollider.enabled = true;
        }
    }
}
