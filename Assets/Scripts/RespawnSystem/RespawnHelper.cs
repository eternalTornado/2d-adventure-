using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RespawnSystem
{
    public class RespawnHelper : MonoBehaviour
    {
        private RespawnPointManager manager;
        private void Awake()
        {
            manager = GameObject.FindObjectOfType<RespawnPointManager>();
        }

        public void RespawnPlayer()
        {
            manager.Respawn(gameObject);
        }

        public void ResetPlayer()
        {
            manager.ResetAllSpawnPoints();
            manager.Respawn(gameObject);
        }
    }
}
