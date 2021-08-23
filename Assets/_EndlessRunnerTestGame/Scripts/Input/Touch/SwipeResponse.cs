using _EndlessRunnerTestGame.Scripts.Player;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _EndlessRunnerTestGame.Scripts.Input.Touch
{
    public class SwipeResponse : MonoBehaviour, IPlayerInputEvents, ITouchInputResponse
    {
        public event IPlayerInputEvents.JumpDelegate OnJump;
        public event IPlayerInputEvents.ChangeSideDelegate OnChangeSide;
        public event IPlayerInputEvents.RollDownDelegate OnRollDown;
        
        private IGroundChecker _groundChecker;
        
        [Inject]
        private IRunningSideManager _runningSideManager;

        private void Awake()
        {
            TryGetComponent(out _groundChecker);
        }

        public void Jump()
        {
            if (!_groundChecker.IsGrounded()) return;
            OnJump?.Invoke();
            Debug.Log("jumping touch");
        }

        public void RollDown()
        {
            OnRollDown?.Invoke();
            Debug.Log("rolling down");
        }

        public void MoveSideways(int sideInputValue)
        {
            if (!_runningSideManager.IsSidewaysMovable(sideInputValue)) return;
            OnChangeSide?.Invoke(sideInputValue);
        }
    }
}