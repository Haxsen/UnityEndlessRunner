using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Player
{
    public class PlayerCollider : MonoBehaviour
    {
        [SerializeField] private string climberTag = "Climber";
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