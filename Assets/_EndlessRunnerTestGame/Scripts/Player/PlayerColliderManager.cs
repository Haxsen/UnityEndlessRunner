using System.Collections;
using _EndlessRunnerTestGame.Scripts.Input;
using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Player
{
    /// <summary>
    /// Manages the player collider on states like rolling.
    /// </summary>
    public class PlayerColliderManager : MonoBehaviour
    {
        [Tooltip("Value used to divide the collider size.")]
        [SerializeField] private float sizeMultiplier = 2f;
        [Tooltip("Roll interval in seconds.")]
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

        /// <summary>
        /// Changes to Roll mode by dividing the size down by <see cref="sizeMultiplier"/>.
        /// </summary>
        private void ChangeToRollMode()
        {
            if (!_isColliderAtDefaultSize) return;
            SetColliderSize(1 / sizeMultiplier);
            if (_revertRollModeCoroutine != null) StopCoroutine(_revertRollModeCoroutine);
            _revertRollModeCoroutine = StartCoroutine(RevertRollMode(waitRevertRollMode));
        }

        /// <summary>
        /// Sets collider size by a multiplier.
        /// </summary>
        /// <param name="multiplyToSize">The multiplier.</param>
        private void SetColliderSize(float multiplyToSize)
        {
            Vector3 scale = transform.localScale;
            scale.y *= multiplyToSize;
            transform.localScale = scale;
            
            _isColliderAtDefaultSize = false;
        }

        /// <summary>
        /// Reverts back to normal mode from roll mode by multiplying the size up by <see cref="sizeMultiplier"/>.
        /// </summary>
        /// <param name="wait"></param>
        /// <returns></returns>
        IEnumerator RevertRollMode(float wait)
        {
            yield return new WaitForSeconds(wait);
            SetColliderSize(sizeMultiplier);
            
            _isColliderAtDefaultSize = true;
        }
    }
}