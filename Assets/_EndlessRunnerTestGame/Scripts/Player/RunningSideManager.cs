using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Player
{
    public class RunningSideManager : IRunningSideManager
    {
        private enum RunningSides {
            Left = -1,
            Center = 0,
            Right = 1
        }
        
        private RunningSides _currentRunningSide = RunningSides.Center;

        public bool IsSidewaysMovable(int sideInputValue)
        {
            if (_currentRunningSide == RunningSides.Left && sideInputValue < 0)
            {
                return false;
            }
            if (_currentRunningSide == RunningSides.Right && sideInputValue > 0)
            {
                return false;
            }
            _currentRunningSide = (RunningSides) (sideInputValue + (int) _currentRunningSide);
            return true;
        }
    }
}