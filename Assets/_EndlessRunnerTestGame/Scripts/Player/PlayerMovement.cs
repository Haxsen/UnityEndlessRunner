using System.Collections;
using _EndlessRunnerTestGame.Scripts.Game;
using _EndlessRunnerTestGame.Scripts.Input;
using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Player
{
    /// <summary>
    /// Manages the player or character movement.
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Basic movement")]
        [SerializeField] private float speed = 250;
        [SerializeField] private float jumpPower = 350f;
        
        [Header("Side movement")]
        [SerializeField] private float sideChangeSpeed = 0.5f;
        [Tooltip("Position offset setter (e.g. The value 1.5 will make the player move 1.5 units on X axis)")]
        [SerializeField] private float sidePositionMultiplier = 1.5f;
        
        [Header("Physics")]
        public Rigidbody rb;
        
        private IPlayerInputEvents _playerPlayerInputEvents;
        private Coroutine _sidewaysCoroutine;
        private int _currentSide;
        private bool _possiblyStucked;

        private void Awake()
        {
            if (!TryGetComponent(out rb)) Debug.LogError("Missing RigidBody on the Player.");
            if (!TryGetComponent(out _playerPlayerInputEvents)) Debug.LogError("Missing InputEvents on the Player.");
        }

        private void OnEnable()
        {
            _playerPlayerInputEvents.OnJump += Jump;
            _playerPlayerInputEvents.OnChangeSide += MoveSideways;
            _playerPlayerInputEvents.OnRollDown += RollDown;
            MoveForward();

        }

        private void OnDisable()
        {
            _playerPlayerInputEvents.OnJump -= Jump;
            _playerPlayerInputEvents.OnChangeSide -= MoveSideways;
            _playerPlayerInputEvents.OnRollDown -= RollDown;
        }

        private void Update()
        {
            if (rb.velocity.z == 0 && _possiblyStucked)
            {
                GlobalGameEvents.OnGameOver?.Invoke();
            }
        }

        private void FixedUpdate()
        {
            if (rb.velocity.z == 0)
            {
                _possiblyStucked = true;
            }
            else
            {
                MoveForward();
                _possiblyStucked = false;
            }
        }

        /// <summary>
        /// Moves the player in forward direction using Physics.
        /// </summary>
        private void MoveForward()
        {
            Vector3 velocity = rb.velocity;
            velocity.x = 0;
            velocity.z = Time.fixedDeltaTime * speed;
            rb.velocity = velocity;
        }

        /// <summary>
        /// Applies a broken downforce to reattach the player to ground.
        /// </summary>
        public void PushDown()
        {
            Vector3 velocity = rb.velocity;
            velocity.y = -1;
            rb.velocity = velocity;
        }

        /// <summary>
        /// Applies an upward force to simulate a jump.
        /// </summary>
        private void Jump()
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }

        /// <summary>
        /// Starts moving the player to the requested side.
        /// </summary>
        /// <param name="sideInputValue">The value determining which side to move towards.</param>
        private void MoveSideways(int sideInputValue)
        {
            _currentSide += sideInputValue;
            if (_sidewaysCoroutine != null) StopCoroutine(_sidewaysCoroutine);
            _sidewaysCoroutine = StartCoroutine(LerpMoveSideways(_currentSide));
        }

        /// <summary>
        /// Smoothly moves the player each frame towards the target side.
        /// </summary>
        /// <param name="toSide">The new side to move towards.</param>
        /// <returns>YieldInstruction to wait until the current frame ends processing.</returns>
        private IEnumerator LerpMoveSideways(int toSide)
        {
            int ticks = 10;
            float toPositionX = toSide * sidePositionMultiplier;
            while (true)
            {
                Vector3 position = rb.position;
                if (Mathf.Approximately(position.x, toPositionX))
                {
                    yield break;
                }
                float lerpPositionX = Mathf.Lerp(position.x, toPositionX, Time.deltaTime * sideChangeSpeed * ticks);
                rb.MovePosition(new Vector3(lerpPositionX, position.y, position.z));
                ticks++;
                yield return new WaitForEndOfFrame();
            }
        }

        /// <summary>
        /// Applies downward force to simulate rolling.
        /// </summary>
        private void RollDown()
        {
            Vector3 velocity = rb.velocity;
            velocity.y = - 1 * Time.deltaTime * jumpPower;
            rb.velocity = velocity;
        }
    }
}