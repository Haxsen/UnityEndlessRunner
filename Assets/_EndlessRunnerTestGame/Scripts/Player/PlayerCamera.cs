using System;
using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Player
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private Transform playerCameraPositionTransform;
        [SerializeField] [Range(0, 1)] private float smoothingSpeed = 0.5f;
        [SerializeField] [Range(0, 1)] private float sideMultiplier = 0.5f;

        private void Update()
        {
            SyncCameraPosition();
        }

        private void SyncCameraPosition()
        {
            Vector3 playerCamPosition = playerCameraPositionTransform.position;
            playerCamPosition.x *= sideMultiplier;
            transform.position = Vector3.Lerp(transform.position, playerCamPosition, smoothingSpeed);
        }
    }
}
