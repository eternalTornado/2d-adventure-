using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RespawnSystem
{
    public class RespawnPointManager : MonoBehaviour
    {
        private List<RespawnPoint> respawnPoints = new List<RespawnPoint>();

        private RespawnPoint currentRespawnPoint;

        private void Awake()
        {
            foreach (var point in this.GetComponentsInChildren<RespawnPoint>())
                respawnPoints.Add(point);

            currentRespawnPoint = respawnPoints[0];
        }

        public void UpdateRespawnPoint(RespawnPoint newRespawnPoint)
        {
            currentRespawnPoint.DisableRespawnPoint();
            currentRespawnPoint = newRespawnPoint;
        }

        public void Respawn(GameObject objectToRespawn)
        {
            currentRespawnPoint.RespawnPlayer();
            objectToRespawn.SetActive(true);
        }

        public void RespawnAt(RespawnPoint spawnPoint, GameObject gameGO)
        {
            spawnPoint.SetPlayerGO(gameGO);
            Respawn(gameGO);
        }

        public void ResetAllSpawnPoints()
        {
            foreach (var point in respawnPoints)
                point.ResetRespawnPoint();

            currentRespawnPoint = respawnPoints[0];
        }
    }
}
