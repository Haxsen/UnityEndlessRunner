namespace _EndlessRunnerTestGame.Scripts.Player
{
    /// <summary>
    /// Provides ground check implementation.
    /// </summary>
    public interface IGroundChecker
    {
        /// <summary>
        /// Checks if the player is grounded.
        /// </summary>
        /// <returns>The boolean whether the player is grounded.</returns>
        public bool IsGrounded();
    }
}