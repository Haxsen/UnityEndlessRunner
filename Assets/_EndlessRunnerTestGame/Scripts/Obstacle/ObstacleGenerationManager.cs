using UnityEngine;
using Random = UnityEngine.Random;

namespace _EndlessRunnerTestGame.Scripts.Obstacle
{
    public class ObstacleGenerationManager : MonoBehaviour
    {
        public Transform playerTransform;
    
        [SerializeField] private float startingDistance = 10f;
        [SerializeField] private float distanceDelta = 5f;
        [SerializeField] private float maxDistance = 50f;
        [SerializeField] private ObstacleGenerator[] obstacleGenerators;
        [SerializeField] private Transform obstacleContainer;
        [SerializeField] [Range(0, 1)] private float spawnProbability = 0.8f;

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

        private void MoveAhead()
        {
            transform.position = new Vector3(0, 0, transform.position.z + distanceDelta);
        }

        private void SyncToPlayerPosition()
        {
            Vector3 playerPosition = playerTransform.position;
            transform.position = new Vector3(0, 0, playerPosition.z + startingDistance);
        }

        private void StartObstacleGeneration()
        {
            foreach (ObstacleGenerator obstacleGenerator in obstacleGenerators)
            {
                // int spawnedObstaclesAmount = obstacleContainer.childCount;
                // float spawnProbability = 10 / (10 + (float) spawnedObstaclesAmount);
                if (Random.value > spawnProbability) continue;
                if (Random.value > 0.3f)
                {
                    obstacleGenerator.GenerateObstacle();
                }
                else
                {
                    obstacleGenerator.GenerateTrain(Random.value > 0.65f, false);
                }
            }
        }
    }
}
