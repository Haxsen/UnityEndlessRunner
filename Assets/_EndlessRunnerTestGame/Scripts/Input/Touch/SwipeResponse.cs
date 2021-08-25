using _EndlessRunnerTestGame.Scripts.Player;
using UnityEngine;
using Zenject;

namespace _EndlessRunnerTestGame.Scripts.Input.Touch
{
    [DefaultExecutionOrder(-1)]
    public class SwipeResponse : MonoBehaviour, ITouchInputResponse
    {
        public event IPlayerInputEvents.JumpDelegate OnSwipeUp;
        public event IPlayerInputEvents.ChangeSideDelegate OnSwipeSideways;
        public event IPlayerInputEvents.RollDownDelegate OnSwipeDown;

        public void Jump()
        {
            OnSwipeUp?.Invoke();
            Debug.Log("jumping touch");
        }

        public void RollDown()
        {
            OnSwipeDown?.Invoke();
            Debug.Log("rolling down touch");
        }

        public void MoveSideways(int sideInputValue)
        {
            OnSwipeSideways?.Invoke(sideInputValue);
            Debug.Log("sideways touch");
        }
    }
}