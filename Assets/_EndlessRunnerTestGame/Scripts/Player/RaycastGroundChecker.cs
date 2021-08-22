using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Player
{
    public class RaycastGroundChecker : MonoBehaviour, IGroundChecker
    {
        [SerializeField] private Collider playerCollider;
        [SerializeField] private LayerMask groundLayerMask;

        public bool IsGrounded()
        {
            bool isGrounded = false;
            Vector3 colliderBottom = playerCollider.transform.position;
            colliderBottom.y -= playerCollider.bounds.extents.y - 0.1f;
            if (Physics.Raycast(playerCollider.transform.position, Vector3.down, out RaycastHit rayHitInfo, 1f, groundLayerMask))
            {
                isGrounded = rayHitInfo.collider != null;
            }
            return isGrounded;
        }
    }
}