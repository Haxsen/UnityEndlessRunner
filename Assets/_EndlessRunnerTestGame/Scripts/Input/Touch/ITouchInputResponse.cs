namespace _EndlessRunnerTestGame.Scripts.Input.Touch
{
    /// <summary>
    /// Contains the response of touch / swipe events.
    /// </summary>
    public interface ITouchInputResponse
    {
        public event IPlayerInputEvents.JumpDelegate OnSwipeUp;
        public event IPlayerInputEvents.ChangeSideDelegate OnSwipeSideways;
        public event IPlayerInputEvents.RollDownDelegate OnSwipeDown;
    }
}