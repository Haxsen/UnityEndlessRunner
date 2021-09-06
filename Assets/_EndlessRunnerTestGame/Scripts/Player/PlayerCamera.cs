using System;
using _EndlessRunnerTestGame.Scripts.Game;
using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Player
{
    /// <summary>
    /// Manages the main camera following the player.
    /// </summary>
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private Transform playerCameraPositionTransform;
        [SerializeField] [Range(0, 1)] private float smoothingSpeed = 0.5f;
        [SerializeField] [Range(0, 1)] private float sideMultiplier = 0.5f;

        private bool toFollowPlayer = true;

        private void OnEnable()
        {
            GlobalGameEvents.OnGameOver += DisableFollowingPlayer;
        }

        private void OnDisable()
        {
            GlobalGameEvents.OnGameOver -= DisableFollowingPlayer;
        }

        private void Update()
        {
            if (toFollowPlayer) SyncCameraPosition();
        }

        private void DisableFollowingPlayer()
        {
            toFollowPlayer = false;
        }

        /// <summary>
        /// Follows the player smoothly.
        /// </summary>
        private void SyncCameraPosition()
        {
            Vector3 playerCamPosition = playerCameraPositionTransform.position;
            playerCamPosition.x *= sideMultiplier;
            transform.position = Vector3.Lerp(transform.position, playerCamPosition, smoothingSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, playerCameraPositionTransform.rotation, smoothingSpeed * 0.5f);
        }
    }
}
