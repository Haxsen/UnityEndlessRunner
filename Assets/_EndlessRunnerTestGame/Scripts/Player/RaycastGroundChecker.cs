using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Player
{
    public class RaycastGroundChecker : MonoBehaviour, IGroundChecker
    {
        [SerializeField] private float maxRayDistance = 1.5f;
        [SerializeField] private Collider playerCollider;
        [SerializeField] private LayerMask groundLayerMask;

        public bool IsGrounded()
        {
            bool isGrounded = false;
            if (Physics.Raycast(playerCollider.transform.position, Vector3.down, out RaycastHit rayHitInfo, maxRayDistance, groundLayerMask))
            {
                isGrounded = rayHitInfo.collider != null;
            }
            return isGrounded;
        }
    }
}