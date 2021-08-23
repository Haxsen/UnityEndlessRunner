namespace _EndlessRunnerTestGame.Scripts.Input.Touch
{
    public interface ITouchInputResponse
    {
        public void Jump();
        public void RollDown();
        public void MoveSideways(int sideInputValue);
    }
}