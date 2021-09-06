using _EndlessRunnerTestGame.Scripts.Game;
using UnityEngine;
using UnityEngine.Events;

namespace _EndlessRunnerTestGame.Scripts.Player
{
    /// <summary>
    /// Manages the unity collider functions of player's collider.
    /// </summary>
    public class PlayerCollider : MonoBehaviour
    {
        [Header("Tags")]
        [SerializeField] private string climberTag = "Climber";
        [SerializeField] private string pickupTag = "Pickup";
        [SerializeField] private string obstacleTag = "Obstacle";
        [Header("Player")]
        [Tooltip("Script that manages Player's movement.")]
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] [Range(0, 1)] private float sideCollisionMatchCutoff = 0.2f;

        [Header("Events")]
        [SerializeField] private UnityEvent onTriggerPickup;
        
        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag(climberTag))
            {
                Debug.Log("collision exited climber");
                playerMovement.PushDown();
            }
        }
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.parent.CompareTag(obstacleTag))
            {
                float sideMatch = GetSideMatchingContact(other);
                if (sideMatch > sideCollisionMatchCutoff)
                {
                    GlobalGameEvents.OnGameOver?.Invoke();
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(pickupTag))
            {
                onTriggerPickup.Invoke();
                Destroy(other.transform.parent.gameObject);
            }
        }

        /// <summary>
        /// Calculates the direction of collision point from player position and returns dot product of matching
        /// either side.
        /// </summary>
        /// <param name="other">The Collision caused by other object's Collider.</param>
        /// <returns>A float representing the side collision matching value.</returns>
        private float GetSideMatchingContact(Collision other)
        {
            ContactPoint contactPoint = other.GetContact(0);
            Vector3 playerPosition = transform.position;
            playerPosition.y += 1;
            Vector3 contactDirection = (contactPoint.point - playerPosition).normalized;
            float sideMatch = Vector3.Dot(Vector3.left, contactDirection);
            sideMatch = Mathf.Abs(sideMatch);
            // Debug.DrawLine(transform.position, contactDirection, Color.green, 10);
            // Debug.Log($"Contact Count: {other.contactCount} ; Side direction matching = {sideMatch}");
            return sideMatch;
        }
    }
}