using UnityEngine;
using UnityEngine.InputSystem;

namespace _EndlessRunnerTestGame.Scripts.Input
{
    [DefaultExecutionOrder(-1)]
    public class TouchInputManager : MonoBehaviour
    {
        public delegate void StartTouch(Vector2 position, float time);
        public delegate void EndTouch(Vector2 position, float time);
        public event StartTouch OnStartTouch;
        public event EndTouch OnEndTouch;

        private PlayerControls _playerControls;
        private Camera _mainCamera;

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
            _mainCamera = Camera.main;
            _playerControls = new PlayerControls();
            _playerControls.DefaultActionMap.PrimaryContact.started += StartTouchPrimary;
            _playerControls.DefaultActionMap.PrimaryContact.canceled += EndTouchPrimary;
        }

        private void StartTouchPrimary(InputAction.CallbackContext ctx)
        {
            OnStartTouch?.Invoke(TouchInputHelper.GetPrimaryPosition(_mainCamera,
                _playerControls.DefaultActionMap.PrimaryPosition.ReadValue<Vector2>()), (float) ctx.startTime);
        }

        private void EndTouchPrimary(InputAction.CallbackContext ctx)
        {
            OnEndTouch?.Invoke(TouchInputHelper.GetPrimaryPosition(_mainCamera,
                _playerControls.DefaultActionMap.PrimaryPosition.ReadValue<Vector2>()), (float) ctx.time);
        }
    }
}
