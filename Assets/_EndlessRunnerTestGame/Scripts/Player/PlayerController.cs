using _EndlessRunnerTestGame.Scripts.Input;
using _EndlessRunnerTestGame.Scripts.Input.Touch;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _EndlessRunnerTestGame.Scripts.Player
{
    /// <summary>
    /// Controls the player inputs and events.
    /// </summary>
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

        /// <summary>
        /// Extenject dependency injection.
        /// </summary>
        /// <param name="runningSideManager">Takes in the bound <see cref="IRunningSideManager"/>.</param>
        /// <param name="playerActions">Takes in the common <see cref="PlayerActions"/></param>
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
            if (!TryGetComponent(out _groundChecker)) Debug.LogError("Missing GroundChecker on Player.");
            _touchInputResponse = GetComponentInChildren<ITouchInputResponse>();
            ConfigureInputCallbacks();
            ConfigureTouchCallbacks();
        }

        /// <summary>
        /// Configures the input callbacks, which operations to execute when an input event is fired.
        /// </summary>
        private void ConfigureInputCallbacks()
        {
            _playerActions.PlayerControls.SideMovement.performed += CatchSidewaysInput;
            _playerActions.PlayerControls.Jump.performed += ctx => Jump();
            _playerActions.PlayerControls.RollDown.performed += ctx => RollDown();
        }

        /// <summary>
        /// Configures the input touch callbacks, which operations to execute when a specific touch event is fired.
        /// </summary>
        private void ConfigureTouchCallbacks()
        {
            _touchInputResponse.OnSwipeSideways += MoveSideways;
            _touchInputResponse.OnSwipeUp += Jump;
            _touchInputResponse.OnSwipeDown += RollDown;
        }

        /// <summary>
        /// Checks if the player is on ground and fires the Jump event.
        /// </summary>
        private void Jump()
        {
            if (!_groundChecker.IsGrounded()) return;
            OnJump?.Invoke();
            Debug.Log("jumping");
        }

        /// <summary>
        /// Fires the Roll down event.
        /// </summary>
        private void RollDown()
        {
            OnRollDown?.Invoke();
            Debug.Log("rolling down");
        }

        /// <summary>
        /// Catches the horizontal input and calls the side movement procedure.
        /// </summary>
        /// <param name="ctx">The callback context containing Axis values.</param>
        private void CatchSidewaysInput(InputAction.CallbackContext ctx)
        {
            int sideInputValue = (int) ctx.ReadValue<float>();
            MoveSideways(sideInputValue);
        }

        /// <summary>
        /// Checks if the player can move to the desired side and fires the side change event.
        /// </summary>
        /// <param name="sideInputValue">The value determining which side to move towards.</param>
        private void MoveSideways(int sideInputValue)
        {
            if (!_runningSideManager.IsSidewaysMovable(sideInputValue)) return;
            OnChangeSide?.Invoke(sideInputValue);
        }
    }
}
