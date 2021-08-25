namespace _EndlessRunnerTestGame.Scripts.Input.Touch
{
    public interface ITouchInputResponse
    {
        public event IPlayerInputEvents.JumpDelegate OnSwipeUp;
        public event IPlayerInputEvents.ChangeSideDelegate OnSwipeSideways;
        public event IPlayerInputEvents.RollDownDelegate OnSwipeDown;
    }
}