using System;
using _EndlessRunnerTestGame.Scripts.Input;
using _EndlessRunnerTestGame.Scripts.Player;
using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Animation
{
    public class CharacterAnimationManager : MonoBehaviour
    {
        [SerializeField] private CharacterAnimatorValues characterAnimatorValues = new CharacterAnimatorValues();
        
        private Animator _animator;
        private IPlayerInputEvents _playerInputEvents;
        private IGroundChecker _groundChecker;

        private void Awake()
        {
            if(!TryGetComponent(out _animator)) Debug.LogError("Missing Animator on the Character.");
            if(!TryGetComponent(out _playerInputEvents)) Debug.LogError("Missing InputEvents on the Player.");
            if(!TryGetComponent(out _groundChecker)) Debug.LogError("Missing GroundChecker on the Player.");
        }

        private void OnEnable()
        {
            _playerInputEvents.OnJump += StartJump;
            _playerInputEvents.OnChangeSide += StartChangingSide;
            _playerInputEvents.OnRollDown += StartRolling;
            StartRunForwards();
        }

        private void OnDisable()
        {
            _playerInputEvents.OnJump -= StartJump;
            _playerInputEvents.OnChangeSide -= StartChangingSide;
            _playerInputEvents.OnRollDown -= StartRolling;
        }

        private void StartRunForwards()
        {
            _animator.SetTrigger(characterAnimatorValues.runForwardTrigger);
        }

        private void StartJump()
        {
            _animator.SetTrigger(characterAnimatorValues.jumpTrigger);
        }

        private void StartChangingSide(int side = default)
        {
            if (_groundChecker.IsGrounded())
            {
                if (side == -1) _animator.SetTrigger(characterAnimatorValues.sideChangeLeftTrigger);
                else if (side == 1) _animator.SetTrigger(characterAnimatorValues.sideChangeRightTrigger);
            }
        }

        private void StartRolling()
        {
            _animator.SetTrigger(characterAnimatorValues.rollDownTrigger);
        }
    }

    [Serializable]
    public class CharacterAnimatorValues
    {
        public string jumpTrigger = "Jump";
        public string runForwardTrigger = "RunForwards";
        public string sideChangeLeftTrigger = "MoveLeft";
        public string sideChangeRightTrigger = "MoveRight";
        public string rollDownTrigger = "RollDown";
    }
}
