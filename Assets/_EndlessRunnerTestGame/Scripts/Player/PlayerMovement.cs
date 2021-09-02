using System.Collections;
using _EndlessRunnerTestGame.Scripts.Input;
using _EndlessRunnerTestGame.Scripts.SO;
using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Player
{
    /// <summary>
    /// Manages the player or character movement.
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Basic movement")]
        [SerializeField] private float speed = 100f;
        [SerializeField] private float jumpPower = 350f;
        
        [Header("Side movement")]
        [SerializeField] private float sideChangeSpeed = 1f;
        [Tooltip("Position offset setter (e.g. The value 1.5 will make the player move 1.5 units on X axis)")]
        [SerializeField] private float sidePositionMultiplier = 1.5f;

        [Header("Game Events")]
        [SerializeField] private GameEventsSO gameEventsSO;
        
        private Rigidbody _rb;
        private IPlayerInputEvents _playerPlayerInputEvents;
        private Coroutine _sidewaysCoroutine;
        private int _currentSide;

        private void Awake()
        {
            if (!TryGetComponent(out _rb)) Debug.LogError("Missing RigidBody on the Player.");
            if (!TryGetComponent(out _playerPlayerInputEvents)) Debug.LogError("Missing InputEvents on the Player.");
            MoveForward();
        }

        private void OnEnable()
        {
            _playerPlayerInputEvents.OnJump += Jump;
            _playerPlayerInputEvents.OnChangeSide += MoveSideways;
            _playerPlayerInputEvents.OnRollDown += RollDown;
        }

        private void OnDisable()
        {
            _playerPlayerInputEvents.OnJump -= Jump;
            _playerPlayerInputEvents.OnChangeSide -= MoveSideways;
            _playerPlayerInputEvents.OnRollDown -= RollDown;
        }

        private void FixedUpdate()
        {
            if (_rb.velocity.z == 0)
            {
                gameEventsSO.OnGameOver?.Invoke();
                GameOverThrowCharacter();
                this.enabled = false;
            }
            else
            {
                MoveForward();
            }
        }

        /// <summary>
        /// Moves the player in forward direction using Physics.
        /// </summary>
        private void MoveForward()
        {
            Vector3 velocity = _rb.velocity;
            velocity.x = 0;
            velocity.z = 1 * Time.fixedDeltaTime * speed;
            if (!Mathf.Approximately(_rb.velocity.z, velocity.z))
            {
                _rb.velocity = velocity;
            }
        }

        /// <summary>
        /// Applies a broken downforce to reattach the player to ground.
        /// </summary>
        public void PushDown()
        {
            Vector3 velocity = _rb.velocity;
            velocity.y = -1;
            _rb.velocity = velocity;
        }

        /// <summary>
        /// Applies an upward force to simulate a jump.
        /// </summary>
        private void Jump()
        {
            _rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
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
                Vector3 position = _rb.position;
                if (Mathf.Approximately(position.x, toPositionX))
                {
                    Debug.Log("sideReached");
                    yield break;
                }
                float lerpPositionX = Mathf.Lerp(position.x, toPositionX, Time.deltaTime * sideChangeSpeed * ticks);
                _rb.MovePosition(new Vector3(lerpPositionX, position.y, position.z));
                ticks++;
                yield return new WaitForEndOfFrame();
            }
        }

        /// <summary>
        /// Applies downward force to simulate rolling.
        /// </summary>
        private void RollDown()
        {
            _rb.AddForce(Vector3.down * jumpPower, ForceMode.Impulse);
        }

        private void GameOverThrowCharacter()
        {
            _rb.velocity = new Vector3(0, 1, -1) * 10;
        }
    }
}