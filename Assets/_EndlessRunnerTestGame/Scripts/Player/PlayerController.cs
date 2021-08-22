using UnityEngine;
using UnityEngine.InputSystem;

namespace _EndlessRunnerTestGame.Scripts.Player
{
    [DefaultExecutionOrder(-1)]
    public class PlayerController : MonoBehaviour
    {
        private enum RunningSides {
            Left = -1,
            Center = 0,
            Right = 1
        }

        public delegate void JumpDelegate();
        public delegate void ChangeSideDelegate(int side);
        public delegate void RollDownDelegate();
        public event JumpDelegate OnJump;
        public event ChangeSideDelegate OnChangeSide;
        public event RollDownDelegate OnRollDown;
        
        private PlayerControls _playerControls;
        private RunningSides _currentRunningSide = RunningSides.Center;
        private IGroundChecker _groundChecker;

        private void OnEnable()
        {
            _playerControls.Enable();
        }

        private void OnDisable()
        {
            _playerControls.Disable();
        }

        private void Awake()
        {
            TryGetComponent(out _groundChecker);
            _playerControls = new PlayerControls();
            _playerControls.DefaultActionMap.SideMovement.performed += MoveSideways;
            _playerControls.DefaultActionMap.Jump.performed += ctx => Jump();
            _playerControls.DefaultActionMap.RollDown.performed += ctx => RollDown();
        }

        private void Jump()
        {
            if (!_groundChecker.IsGrounded()) return;
            OnJump?.Invoke();
            Debug.Log("jumping");
        }

        private void RollDown()
        {
            OnRollDown?.Invoke();
            Debug.Log("rolling down");
        }

        private void MoveSideways(InputAction.CallbackContext ctx)
        {
            int sideInputValue = (int) ctx.ReadValue<float>();
            if (_currentRunningSide == RunningSides.Left)
            {
                if (sideInputValue < 0) return;
            }
            else if (_currentRunningSide == RunningSides.Right)
            {
                if (sideInputValue > 0) return;
            }
            _currentRunningSide = (RunningSides) (sideInputValue + (int) _currentRunningSide);
            OnChangeSide?.Invoke(sideInputValue);
        }
    }
}
