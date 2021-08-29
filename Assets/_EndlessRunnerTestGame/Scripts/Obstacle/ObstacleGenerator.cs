using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Obstacle
{
    public class ObstacleGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject[] obstacles;
        [SerializeField] private GameObject obstacleExpandable;
        [SerializeField] private GameObject obstacleClimbable;

        [SerializeField] private Transform obstaclesParent;
    
        private float _overhead;
        private bool _isGeneratingTrain;

        public void GenerateObstacle()
        {
            if (_isGeneratingTrain) return;
            
            Vector3 thisPosition = GetPositionWithRandomizedAxisZ(transform.position);
            int rand = Random.Range(0, obstacles.Length);
            GameObject spawnedObstacle = Instantiate(obstacles[rand], thisPosition,
                Quaternion.identity, obstaclesParent);
        }

        public void GenerateTrain(bool isClimbable, bool isExpansion)
        {
            if (_isGeneratingTrain && !isExpansion) return;

            Vector3 thisPosition = transform.position;
            if (!isExpansion) thisPosition = GetPositionWithRandomizedAxisZ(transform.position);
            GameObject toSpawn = isClimbable ? obstacleClimbable : obstacleExpandable;
            
            GameObject spawnedObstacle = Instantiate(toSpawn, thisPosition,
                Quaternion.identity, obstaclesParent);
            if (_isGeneratingTrain) spawnedObstacle.name += "+";
            
            float trainLength = spawnedObstacle.transform.GetChild(0).localScale.z;
            _overhead += trainLength + 0.1f;
            
            UpdateSelfPosition(transform.localPosition);
            
            RandomGenerateTrain();
        }

        private Vector3 GetPositionWithRandomizedAxisZ(Vector3 position)
        {
            float randomizeAxisZ = Random.Range(0, 3);
            position.z += randomizeAxisZ;
            return position;
        }

        private void RandomGenerateTrain()
        {
            if (Random.value > 0.25f) ExpandTrain();
            else _isGeneratingTrain = false;
        }

        private void ExpandTrain()
        {
            Debug.Log("expanding train");
            _isGeneratingTrain = true;
            GenerateTrain(false, true);
        }

        private void UpdateSelfPosition(Vector3 fromPosition)
        {
            transform.localPosition = new Vector3(fromPosition.x, fromPosition.y, fromPosition.z + _overhead);
            _overhead = 0;
        }
    }
}