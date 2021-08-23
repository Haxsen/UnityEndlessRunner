using _EndlessRunnerTestGame.Scripts.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _EndlessRunnerTestGame.Scripts.Player
{
    [DefaultExecutionOrder(-1)]
    public class PlayerController : MonoBehaviour, IPlayerInputEvents
    {
        public event IPlayerInputEvents.JumpDelegate OnJump;
        public event IPlayerInputEvents.ChangeSideDelegate OnChangeSide;
        public event IPlayerInputEvents.RollDownDelegate OnRollDown;

        private PlayerActions _playerActions;
        private IGroundChecker _groundChecker;
        
        private IRunningSideManager _runningSideManager;

        [Inject]
        public void Construct(IRunningSideManager runningSideManager)
        {
            _runningSideManager = runningSideManager;
        }

        private void OnEnable()
        {
            _playerActions.Enable();
        }

        private void OnDisable()
        {
            _playerActions.Disable();
        }

        private void Awake()
        {
            _playerActions = new PlayerActions();
            TryGetComponent(out _groundChecker);
            ConfigureInputCallbacks();
        }

        private void ConfigureInputCallbacks()
        {
            _playerActions.PlayerControls.SideMovement.performed += MoveSideways;
            _playerActions.PlayerControls.Jump.performed += ctx => Jump();
            _playerActions.PlayerControls.RollDown.performed += ctx => RollDown();
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
            if (!_runningSideManager.IsSidewaysMovable(sideInputValue)) return;
            OnChangeSide?.Invoke(sideInputValue);
        }
    }
}
