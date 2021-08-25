using _EndlessRunnerTestGame.Scripts.Input;
using _EndlessRunnerTestGame.Scripts.Input.Touch;
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
        private ITouchInputResponse _touchInputResponse;

        [Inject]
        public void Construct(IRunningSideManager runningSideManager, PlayerActions playerActions)
        {
            _runningSideManager = runningSideManager;
            _playerActions = playerActions;
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
            TryGetComponent(out _groundChecker);
            _touchInputResponse = GetComponentInChildren<ITouchInputResponse>();
            ConfigureInputCallbacks();
            ConfigureTouchCallbacks();
        }

        private void ConfigureInputCallbacks()
        {
            _playerActions.PlayerControls.SideMovement.performed += CatchSidewaysInput;
            _playerActions.PlayerControls.Jump.performed += ctx => Jump();
            _playerActions.PlayerControls.RollDown.performed += ctx => RollDown();
        }

        private void ConfigureTouchCallbacks()
        {
            _touchInputResponse.OnSwipeSideways += MoveSideways;
            _touchInputResponse.OnSwipeUp += Jump;
            _touchInputResponse.OnSwipeDown += RollDown;
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

        private void CatchSidewaysInput(InputAction.CallbackContext ctx)
        {
            int sideInputValue = (int) ctx.ReadValue<float>();
            MoveSideways(sideInputValue);
        }

        private void MoveSideways(int sideInputValue)
        {
            if (!_runningSideManager.IsSidewaysMovable(sideInputValue)) return;
            OnChangeSide?.Invoke(sideInputValue);
        }
    }
}
