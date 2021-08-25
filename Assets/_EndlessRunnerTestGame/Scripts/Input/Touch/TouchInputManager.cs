using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _EndlessRunnerTestGame.Scripts.Input.Touch
{
    [DefaultExecutionOrder(-1)]
    public class TouchInputManager : MonoBehaviour
    {
        public delegate void StartTouch(Vector2 position, float time);
        public delegate void EndTouch(Vector2 position, float time);
        public event StartTouch OnStartTouch;
        public event EndTouch OnEndTouch;

        private PlayerActions _playerActions;
        private Camera _mainCamera;

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

        private void StartTouchPrimary(InputAction.CallbackContext ctx)
        {
            OnStartTouch?.Invoke(TouchInputHelper.GetPrimaryPosition(_mainCamera,
                _playerActions.PlayerControls.PrimaryPosition.ReadValue<Vector2>()), (float) ctx.startTime);
        }

        private void EndTouchPrimary(InputAction.CallbackContext ctx)
        {
            OnEndTouch?.Invoke(TouchInputHelper.GetPrimaryPosition(_mainCamera,
                _playerActions.PlayerControls.PrimaryPosition.ReadValue<Vector2>()), (float) ctx.time);
        }
    }
}
