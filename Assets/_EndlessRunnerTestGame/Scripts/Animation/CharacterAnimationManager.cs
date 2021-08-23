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
        private IPlayerInputEvents _playerPlayerInputEvents;
        private IGroundChecker _groundChecker;

        private void Awake()
        {
            TryGetComponent(out _animator);
            TryGetComponent(out _playerPlayerInputEvents);
            TryGetComponent(out _groundChecker);
            StartRunForwards();
        }

        private void OnEnable()
        {
            _playerPlayerInputEvents.OnJump += StartJump;
            _playerPlayerInputEvents.OnChangeSide += StartChangingSide;
            _playerPlayerInputEvents.OnRollDown += StartRolling;
        }

        private void OnDisable()
        {
            _playerPlayerInputEvents.OnJump -= StartJump;
            _playerPlayerInputEvents.OnChangeSide -= StartChangingSide;
            _playerPlayerInputEvents.OnRollDown -= StartRolling;
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
