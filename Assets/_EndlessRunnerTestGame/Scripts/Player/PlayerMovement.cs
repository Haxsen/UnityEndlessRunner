using System.Collections;
using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 100f;
        [SerializeField] private float jumpPower = 350f;
        [SerializeField] private float sideChangeSpeed = 1f;
    
        private Rigidbody _rb;
        private PlayerController _playerController;
        private Coroutine _sidewaysCoroutine;
        private int _currentSide;

        private void Awake()
        {
            TryGetComponent(out _rb);
            TryGetComponent(out _playerController);
            MoveForward();
        }

        private void OnEnable()
        {
            _playerController.OnJump += Jump;
            _playerController.OnChangeSide += MoveSideways;
        }

        private void MoveForward()
        {
            Vector3 velocity = _rb.velocity;
            velocity.z = 1 * Time.fixedDeltaTime * speed;
            _rb.velocity = velocity;
        }

        private void Jump()
        {
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
            while (true)
            {
                Vector3 position = _rb.position;
                if (Mathf.Approximately(position.x, toSide))
                {
                    Debug.Log("sideReached");
                    yield break;
                }
                float lerpPositionX = Mathf.Lerp(position.x, toSide, Time.deltaTime * sideChangeSpeed * ticks);
                _rb.MovePosition(new Vector3(lerpPositionX, position.y, position.z));
                ticks++;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}