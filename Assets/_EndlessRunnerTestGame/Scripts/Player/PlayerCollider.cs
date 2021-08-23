using System;
using System.Collections;
using _EndlessRunnerTestGame.Scripts.Input;
using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Player
{
    public class PlayerCollider : MonoBehaviour
    {
        [SerializeField] private float sizeMultiplier = 2f;
        [SerializeField] private float waitRevertRollMode = 1.5f;
        
        private IPlayerInputEvents _playerPlayerInputEvents;
        private Coroutine _revertRollModeCoroutine;
        private bool _isColliderAtDefaultSize = true;

        private void Awake()
        {
            transform.parent.TryGetComponent(out _playerPlayerInputEvents);
            _playerPlayerInputEvents.OnRollDown += ChangeToRollMode;
        }

        private void OnEnable()
        {
            _playerPlayerInputEvents.OnRollDown += ChangeToRollMode;
        }

        private void OnDisable()
        {
            _playerPlayerInputEvents.OnRollDown -= ChangeToRollMode;
        }

        private void ChangeToRollMode()
        {
            if (!_isColliderAtDefaultSize) return;
            SetColliderSize(1 / sizeMultiplier);
            if (_revertRollModeCoroutine != null) StopCoroutine(_revertRollModeCoroutine);
            _revertRollModeCoroutine = StartCoroutine(RevertRollMode(waitRevertRollMode));
        }

        private void SetColliderSize(float multiplyToSize)
        {
            Vector3 scale = transform.localScale;
            scale.y *= multiplyToSize;
            transform.localScale = scale;
            
            _isColliderAtDefaultSize = false;
        }

        IEnumerator RevertRollMode(float wait)
        {
            yield return new WaitForSeconds(wait);
            SetColliderSize(sizeMultiplier);
            
            _isColliderAtDefaultSize = true;
        }
    }
}