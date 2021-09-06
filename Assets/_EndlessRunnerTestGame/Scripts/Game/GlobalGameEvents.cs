using System;

namespace _EndlessRunnerTestGame.Scripts.Game
{
    public static class GlobalGameEvents
    {
        public static Action OnGameStarted;
        public static Action OnPlayerDied;
        public static Action OnGameOver;

        public static void StartGameEvent()
        {
            OnGameStarted?.Invoke();
        }
    }
}