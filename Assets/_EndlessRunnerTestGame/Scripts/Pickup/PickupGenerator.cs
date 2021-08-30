using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Pickup
{
    /// <summary>
    /// Provides pickup spawning service.
    /// </summary>
    public class PickupGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject pickup;
        [Tooltip("Parent containing all pickups")]
        [SerializeField] private Transform pickupContainer;
        [Tooltip("Distance between pickups")]
        [SerializeField] private float distanceDelta = 1f;

        /// <summary>
        /// Spawns a number of pickups starting from a defined position. 
        /// </summary>
        /// <param name="amount">The amount or number of pickups to spawn.</param>
        /// <param name="fromPosition">Starting position for first spawn.</param>
        public void GeneratePickups(int amount, Vector3 fromPosition)
        {
            for (int i = 0; i < amount; i++)
            {
                SpawnPickup(fromPosition);
                fromPosition.z += distanceDelta;
            }
        }

        /// <summary>
        /// Spawns a pickup at defined position.
        /// </summary>
        /// <param name="position">The position to spawn at.</param>
        private void SpawnPickup(Vector3 position)
        {
            GameObject spawnedPickup = Instantiate(pickup, position, Quaternion.identity, pickupContainer);
        }
    }
}