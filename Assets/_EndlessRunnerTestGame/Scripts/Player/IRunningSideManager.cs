namespace _EndlessRunnerTestGame.Scripts.Player
{
    /// <summary>
    /// Contains the sides movement data.
    /// </summary>
    public interface IRunningSideManager
    {
        /// <summary>
        /// Checks whether the player is movable to the requested side and not falling off the ground.
        /// </summary>
        /// <param name="sideInputValue">The value determining which side to move towards.</param>
        /// <returns>A boolean whether the movement is possible.</returns>
        public bool IsSidewaysMovable(int sideInputValue);
    }
}