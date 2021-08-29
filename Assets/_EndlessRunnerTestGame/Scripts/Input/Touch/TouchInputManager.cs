using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _EndlessRunnerTestGame.Scripts.Input.Touch
{
    /// <summary>
    /// Manages the touch input events.
    /// </summary>
    [DefaultExecutionOrder(-1)]
    public class TouchInputManager : MonoBehaviour
    {
        /// <summary>
        /// Delegate to take the first touch starting position and time.
        /// </summary>
        public delegate void StartTouch(Vector2 position, float time);
        
        /// <summary>
        /// Delegate to take the first touch ending position and time.
        /// </summary>
        public delegate void EndTouch(Vector2 position, float time);
        public event StartTouch OnStartTouch;
        public event EndTouch OnEndTouch;

        private PlayerActions _playerActions;
        private Camera _mainCamera;

        /// <summary>
        /// Extenject dependency injection.
        /// </summary>
        /// <param name="playerActions">Takes in the common <see cref="PlayerActions"/></param>
        [Inject]
        public void Construct(PlayerActions playerActions)
        {
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
            _mainCamera = Camera.main;
            _playerActions.PlayerControls.PrimaryContact.started += StartTouchPrimary;
            _playerActions.PlayerControls.PrimaryContact.canceled += EndTouchPrimary;
        }

        /// <summary>
        /// Fires the touch starting event by catching touch's position and time.
        /// </summary>
        /// <param name="ctx">The CallbackContext containing touch values.</param>
        private void StartTouchPrimary(InputAction.CallbackContext ctx)
        {
            OnStartTouch?.Invoke(TouchInputHelper.GetTouchPosition(_mainCamera,
                _playerActions.PlayerControls.PrimaryPosition.ReadValue<Vector2>()), (float) ctx.startTime);
        }

        /// <summary>
        /// Fires the touch ending event by catching touch's position and time.
        /// </summary>
        /// <param name="ctx">The CallbackContext containing touch values.</param>
        private void EndTouchPrimary(InputAction.CallbackContext ctx)
        {
            OnEndTouch?.Invoke(TouchInputHelper.GetTouchPosition(_mainCamera,
                _playerActions.PlayerControls.PrimaryPosition.ReadValue<Vector2>()), (float) ctx.time);
        }
    }
}
