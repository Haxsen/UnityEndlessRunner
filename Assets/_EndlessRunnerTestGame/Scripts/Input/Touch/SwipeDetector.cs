using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Input.Touch
{
    public class SwipeDetector : MonoBehaviour
    {
        [Header("Swipe limits")]
        [SerializeField] private float minSwipeDistance = 0.01f;
        [SerializeField] private float maxSwipeTime = 1f;
        
        [Header("Direction")]
        [SerializeField] private float directionThreshold = 0.8f;
        
        private TouchInputManager _touchInputManager;
        private SwipeResponse _swipeResponse;

        private Vector2 _startPosition;
        private Vector2 _endPosition;
        private float _startTime;
        private float _endTime;

        private void Awake()
        {
            TryGetComponent(out _touchInputManager);
            TryGetComponent(out _swipeResponse);
        }

        private void OnEnable()
        {
            _touchInputManager.OnStartTouch += SwipeStart;
            _touchInputManager.OnEndTouch += SwipeEnd;
            Debug.Log("subbed");
        }

        private void OnDisable()
        {
            _touchInputManager.OnStartTouch -= SwipeStart;
            _touchInputManager.OnEndTouch -= SwipeEnd;
        }

        /// <summary>
        /// Catches the starting position and time.
        /// </summary>
        /// <param name="position">The touch position.</param>
        /// <param name="time">The time of touch.</param>
        private void SwipeStart(Vector2 position, float time)
        {
            _startPosition = position;
            _startTime = time;
            Debug.Log("swipe start");
        }

        /// <summary>
        /// First catches the ending position and time, then executes the swipe detection procedure.
        /// </summary>
        /// <param name="position">The touch position.</param>
        /// <param name="time">The time of touch.</param>
        private void SwipeEnd(Vector2 position, float time)
        {
            _endPosition = position;
            _endTime = time;
            Debug.Log("swipe end");
            DetectSwipe();
        }

        /// <summary>
        /// Calculates the swipe direction and limits. If the swipe is valid, executes the swipe direction procedure.
        /// </summary>
        private void DetectSwipe()
        {
            float dist = Vector3.Distance(_startPosition, _endPosition);
            Debug.Log($"Dist is greater: {dist} > {minSwipeDistance}");
            dist = (_endTime - _startTime);
            Debug.Log($"Dist is greater: {dist} < {maxSwipeTime}");
            if (Vector3.Distance(_startPosition, _endPosition) >= minSwipeDistance
                && (_endTime - _startTime) < maxSwipeTime)
            {
                Debug.Log("Swiped");
                Debug.DrawLine(_startPosition, _endPosition, Color.green, 2f);
                Vector2 swipedDirection = new Vector2(_endPosition.x - _startPosition.x,
                    _endPosition.y - _startPosition.y).normalized;
                SwipeDirection(swipedDirection);
            }
            else
            {
                Debug.Log("not swiped");
            }
        }

        /// <summary>
        /// Determines the swipe direction.
        /// </summary>
        /// <param name="swipedDirection">The 2D Vector containing the magnitude of directional values.</param>
        private void SwipeDirection(Vector2 swipedDirection)
        {
            if (Vector2.Dot(Vector2.up, swipedDirection) > directionThreshold)
            {
                Debug.Log("swiped up");
                _swipeResponse.Jump();
            }
            else if (Vector2.Dot(Vector2.down, swipedDirection) > directionThreshold)
            {
                Debug.Log("swiped down");
                _swipeResponse.RollDown();
            }
            else if (Vector2.Dot(Vector2.left, swipedDirection) > directionThreshold)
            {
                Debug.Log("swiped left");
                _swipeResponse.MoveSideways(-1);
            }
            else if (Vector2.Dot(Vector2.right, swipedDirection) > directionThreshold)
            {
                Debug.Log("swiped right");
                _swipeResponse.MoveSideways(1);
            }
        }
    }
}
