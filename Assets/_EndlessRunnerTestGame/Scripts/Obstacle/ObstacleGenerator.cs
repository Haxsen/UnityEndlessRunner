using _EndlessRunnerTestGame.Scripts.Pickup;
using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Obstacle
{
    /// <summary>
    /// Manages own side's obstacle generation.
    /// </summary>
    public class ObstacleGenerator : MonoBehaviour
    {
        [Header("Obstacles")]
        [SerializeField] private GameObject[] obstacles;
        [SerializeField] private GameObject obstacleExpandable;
        [SerializeField] private GameObject obstacleClimbable;

        [Header("Obstacles Container")]
        [SerializeField] private Transform obstaclesParent;

        [Header("Pickups")]
        [SerializeField] private PickupGenerator pickupGenerator;
    
        private float _overhead;
        private bool _isGeneratingTrain;

        /// <summary>
        /// Generates a normal obstacle.
        /// </summary>
        public void GenerateObstacle()
        {
            if (_isGeneratingTrain) return;
            
            Vector3 thisPosition = GetPositionWithRandomizedAxisZ(transform.position);
            int rand = Random.Range(0, obstacles.Length);
            GameObject spawnedObstacle = Instantiate(obstacles[rand], thisPosition,
                Quaternion.identity, obstaclesParent);
            
            float obstacleLength = spawnedObstacle.transform.GetChild(0).localScale.z;
            _overhead += obstacleLength;
            UpdateSelfPosition(transform.localPosition);
        }

        /// <summary>
        /// Generates a train obstacle.
        /// </summary>
        /// <param name="isClimbable">Decides to spawn climbable type of train.</param>
        /// <param name="isExpansion">Whether the mode is expansion.</param>
        public void GenerateTrain(bool isClimbable, bool isExpansion)
        {
            if (_isGeneratingTrain && !isExpansion) return;

            Vector3 thisPosition = transform.position;
            if (!isExpansion) thisPosition = GetPositionWithRandomizedAxisZ(thisPosition);
            GameObject toSpawn = isClimbable ? obstacleClimbable : obstacleExpandable;
            
            GameObject spawnedObstacle = Instantiate(toSpawn, thisPosition,
                Quaternion.identity, obstaclesParent);
            if (_isGeneratingTrain) spawnedObstacle.name += "+";

            Vector3 spawnedObjectScale = spawnedObstacle.transform.GetChild(0).localScale;
            float trainLength = spawnedObjectScale.z;
            _overhead += trainLength + 0.1f;

            if (Random.value > 0.5f)
            {
                int spawnPickupAmount = Random.Range(0, 6);
                thisPosition.y += spawnedObjectScale.y;
                pickupGenerator.GeneratePickups(spawnPickupAmount, thisPosition);
            }
            
            UpdateSelfPosition(transform.localPosition);
            
            RandomGenerateTrain();
        }

        /// <summary>
        /// Randomizes frontal position a bit.
        /// </summary>
        /// <param name="position">The target position.</param>
        /// <returns>The new randomized position.</returns>
        private Vector3 GetPositionWithRandomizedAxisZ(Vector3 position)
        {
            float randomizeAxisZ = Random.Range(0, 3);
            position.z += randomizeAxisZ;
            return position;
        }

        /// <summary>
        /// Decides to expand the train.
        /// </summary>
        private void RandomGenerateTrain()
        {
            if (Random.value > 0.75f) ExpandTrain();
            else _isGeneratingTrain = false;
        }

        /// <summary>
        /// Expands the train.
        /// </summary>
        private void ExpandTrain()
        {
            _isGeneratingTrain = true;
            GenerateTrain(false, true);
        }

        /// <summary>
        /// Updates own position to avoid spawning multiple objects in the same position.
        /// </summary>
        /// <param name="fromPosition">The original position.</param>
        private void UpdateSelfPosition(Vector3 fromPosition)
        {
            transform.localPosition = new Vector3(fromPosition.x, fromPosition.y, fromPosition.z + _overhead);
            _overhead = 0;
        }
    }
}