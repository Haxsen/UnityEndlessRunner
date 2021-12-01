using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Ground
{
    /// <summary>
    /// Generates the ground based on Player's position.
    /// </summary>
    public class GroundGenerator : MonoBehaviour
    {
        [Header("Ground related fields")]
        [SerializeField] private GameObject groundPrefab;
        [SerializeField] private Transform groundContainer;

        [Header("Player related fields")]
        [SerializeField] private float playerDistanceCutoff = 10f;
        [SerializeField] private Transform playerTransform;

        private float _selfMovementDistance;

        private GameObject _currentGround;

        private void Awake()
        {
            // Finds the self distance using prefab's scale.
            _selfMovementDistance = (groundPrefab.transform.GetChild(0).localScale.z / 2) * 10;
        }

        private void Update()
        {
            if (CheckPlayerOutOfRange())
            {
                MoveSelfAhead();
                GenerateGround();
            }
        }

        /// <summary>
        /// Checks if the player is out of specified range (distance between this ground generator and the player).
        /// </summary>
        /// <returns>A boolean whether the player is out of range.</returns>
        private bool CheckPlayerOutOfRange()
        {
            return Vector3.Distance(playerTransform.position, transform.position) > playerDistanceCutoff;
        }

        /// <summary>
        /// Moves self position ahead of player so it comes in range.
        /// </summary>
        private void MoveSelfAhead()
        {
            transform.position += transform.forward * _selfMovementDistance;
        }

        /// <summary>
        /// Generates the ground prefab next to the previous ground object.
        /// </summary>
        private void GenerateGround()
        {
            // TODO: Use object pooling to improve memory allocation (performance).
            if (_currentGround != null) Destroy(_currentGround);
            _currentGround = Instantiate(groundPrefab, transform.position, Quaternion.identity, groundContainer);
        }
    }
}
