using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Player
{
    /// <summary>
    /// Manages the unity collider functions of player's collider.
    /// </summary>
    public class PlayerCollider : MonoBehaviour
    {
        [SerializeField] private string climberTag = "Climber";
        [Tooltip("Script that manages Player's movement.")]
        [SerializeField] private PlayerMovement playerMovement;
        
        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag(climberTag))
            {
                Debug.Log("collision exited climber");
                playerMovement.PushDown();
            }
        }
    }
}