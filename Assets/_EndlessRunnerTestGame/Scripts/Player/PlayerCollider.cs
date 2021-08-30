using UnityEngine;
using UnityEngine.Events;

namespace _EndlessRunnerTestGame.Scripts.Player
{
    /// <summary>
    /// Manages the unity collider functions of player's collider.
    /// </summary>
    public class PlayerCollider : MonoBehaviour
    {
        [SerializeField] private string climberTag = "Climber";
        [SerializeField] private string pickupTag = "Pickup";
        [Tooltip("Script that manages Player's movement.")]
        [SerializeField] private PlayerMovement playerMovement;

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

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(pickupTag))
            {
                onTriggerPickup.Invoke();
                Destroy(other.transform.parent.gameObject);
            }
        }
    }
}