using _EndlessRunnerTestGame.Scripts.Input.Touch;
using _EndlessRunnerTestGame.Scripts.Player;
using _EndlessRunnerTestGame.Scripts.Scoring;
using _EndlessRunnerTestGame.Scripts.SO;
using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameEventsSO gameEventsObject;
        [SerializeField] private PlayerManager playerManager;
        [SerializeField] private TouchInputManager touchInputManager;

        private void OnEnable()
        {
            gameEventsObject.OnGameStarted += StartGame;
        }

        private void OnDisable()
        {
            gameEventsObject.OnGameStarted -= StartGame;
        }

        public void StartGame()
        {
            playerManager.ActivatePlayer();
            touchInputManager.enabled = true;
            ScoreManager.Score = 0;
            GlobalGameEvents.OnGameStarted?.Invoke();
        }
    }
}