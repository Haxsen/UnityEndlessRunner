using System;
using System.Collections;
using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Player
{
    public class PlayerCollider : MonoBehaviour
    {
        [SerializeField] private float divideSizeBy = 2f;
        [SerializeField] private float waitRevertRollMode = 1.5f;
        
        private PlayerController _playerController;
        private Coroutine _revertRollModeCoroutine;
        private bool _isColliderAtDefaultSize = true;

        private void Awake()
        {
            transform.parent.TryGetComponent(out _playerController);
            _playerController.OnRollDown += ChangeToRollMode;
        }

        private void OnEnable()
        {
            _playerController.OnRollDown += ChangeToRollMode;
        }

        private void OnDisable()
        {
            _playerController.OnRollDown -= ChangeToRollMode;
        }

        private void ChangeToRollMode()
        {
            if (!_isColliderAtDefaultSize) return;
            Vector3 scale = transform.localScale;
            scale.y /= divideSizeBy;
            transform.localScale = scale;
            _isColliderAtDefaultSize = false;
            if (_revertRollModeCoroutine != null) StopCoroutine(_revertRollModeCoroutine);
            _revertRollModeCoroutine = StartCoroutine(RevertRollMode(waitRevertRollMode));
        }

        IEnumerator RevertRollMode(float wait)
        {
            yield return new WaitForSeconds(wait);
            Vector3 scale = transform.localScale;
            scale.y *= divideSizeBy;
            transform.localScale = scale;
            _isColliderAtDefaultSize = true;
        }
    }
}