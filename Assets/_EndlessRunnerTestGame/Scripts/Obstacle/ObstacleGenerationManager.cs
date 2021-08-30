using _EndlessRunnerTestGame.Scripts.Pickup;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _EndlessRunnerTestGame.Scripts.Obstacle
{
    /// <summary>
    /// Manages the generation of obstacles and trains.
    /// </summary>
    public class ObstacleGenerationManager : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        
        [Header("Generator config")]
        [SerializeField] private float startingDistance = 10f;
        [Tooltip("Distance to move ahead after each generation of object.")]
        [SerializeField] private float distanceDelta = 5f;
        [SerializeField] private float maxDistance = 50f;
        [SerializeField] [Range(0, 1)] private float spawnProbability = 0.8f;
        
        [Header("Obstacle Specific")]
        [Tooltip("The respective side Obstacle Generators.")]
        [SerializeField] private ObstacleGenerator[] obstacleGenerators;

        [Header("Pickups")]
        [SerializeField] private PickupGenerator pickupGenerator;

        private float _distanceFromPlayer;
    
        private void Awake()
        {
            SyncToPlayerPosition();
        }

        private void Update()
        {
            _distanceFromPlayer = Vector3.Distance(transform.position, playerTransform.position);
            if (_distanceFromPlayer > maxDistance) return;
            if (Random.value > 0.5f) StartObstacleGeneration();
            MoveAhead();
        }

        /// <summary>
        /// Moves itself farther ahead from player.
        /// </summary>
        private void MoveAhead()
        {
            transform.position = new Vector3(0, 0, transform.position.z + distanceDelta);
        }

        /// <summary>
        /// Initializes its own position.
        /// </summary>
        private void SyncToPlayerPosition()
        {
            Vector3 playerPosition = playerTransform.position;
            transform.position = new Vector3(0, 0, playerPosition.z + startingDistance);
        }

        /// <summary>
        /// Starts the obstacle generation procedure by going through each generator.
        /// </summary>
        private void StartObstacleGeneration()
        {
            int trainsGenerated = 0;
            foreach (ObstacleGenerator obstacleGenerator in obstacleGenerators)
            {
                // @TODO: Remove auto probability calculation zombie code.
                // int spawnedObstaclesAmount = obstacleContainer.childCount;
                // float spawnProbability = 10 / (10 + (float) spawnedObstaclesAmount);

                if (Random.value > spawnProbability)
                {
                    if (Random.value > 0.5f)
                    {
                        int spawnPickupAmount = Random.Range(0, 6);
                        pickupGenerator.GeneratePickups(spawnPickupAmount, obstacleGenerator.transform.position);
                        
                    }
                    continue;
                }
                if (Random.value > 0.3f)
                {
                    obstacleGenerator.GenerateObstacle();
                }
                else
                {
                    if (trainsGenerated >= 2) return;
                    obstacleGenerator.GenerateTrain(Random.value > 0.65f, false);
                    trainsGenerated++;
                }
            }
        }
    }
}
