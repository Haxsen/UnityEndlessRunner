namespace _EndlessRunnerTestGame.Scripts.Input
{
    public interface IPlayerInputEvents
    {
        public delegate void JumpDelegate();
        public delegate void ChangeSideDelegate(int side);
        public delegate void RollDownDelegate();
        public event JumpDelegate OnJump;
        public event ChangeSideDelegate OnChangeSide;
        public event RollDownDelegate OnRollDown;
    }
}