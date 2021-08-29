namespace _EndlessRunnerTestGame.Scripts.Input
{
    /// <summary>
    /// Contains the input events triggered by the player.
    /// </summary>
    public interface IPlayerInputEvents
    {
        public delegate void JumpDelegate();
        public delegate void ChangeSideDelegate(int side);
        public delegate void RollDownDelegate();
        
        /// <summary>
        /// The event to be triggered when player inputs Jump button.
        /// </summary>
        public event JumpDelegate OnJump;
        
        /// <summary>
        /// The event to be triggered when player inputs horizontal axis value.
        /// </summary>
        public event ChangeSideDelegate OnChangeSide;
        
        /// <summary>
        /// The event to be triggered when player inputs RollDown button.
        /// </summary>
        public event RollDownDelegate OnRollDown;
    }
}