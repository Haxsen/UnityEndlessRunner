using System.Collections;
using _EndlessRunnerTestGame.Scripts.Input;
using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 100f;
        [SerializeField] private float jumpPower = 350f;
        [SerializeField] private float sideChangeSpeed = 1f;
        [SerializeField] private float sidePositionMultiplier = 1.5f;
    
        public bool AddDownForce { get; set; } = true;
        
        private Rigidbody _rb;
        private IPlayerInputEvents _playerPlayerInputEvents;
        private Coroutine _sidewaysCoroutine;
        private int _currentSide;

        private void Awake()
        {
            TryGetComponent(out _rb);
            TryGetComponent(out _playerPlayerInputEvents);
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
            MoveForward();
        }

        private void MoveForward()
        {
            Vector3 velocity = _rb.velocity;
            velocity.x = 0;
            velocity.z = 1 * Time.fixedDeltaTime * speed;
            // if (AddDownForce)
            // {
            //     velocity.y = - 1 * Time.fixedDeltaTime * speed * 0.001f;
            // }
            _rb.velocity = velocity;
        }

        public void PushDown()
        {
            Vector3 velocity = _rb.velocity;
            velocity.y = -1;
            _rb.velocity = velocity;
        }

        private void Jump()
        {
            AddDownForce = false;
            _rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }

        private void MoveSideways(int sideInputValue)
        {
            _currentSide += sideInputValue;
            if (_sidewaysCoroutine != null) StopCoroutine(_sidewaysCoroutine);
            _sidewaysCoroutine = StartCoroutine(LerpMoveSideways(_currentSide));
        }

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

        private void RollDown()
        {
            _rb.AddForce(Vector3.down * jumpPower, ForceMode.Impulse);
        }
    }
}