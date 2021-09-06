using _EndlessRunnerTestGame.Scripts.Input.Touch;
using _EndlessRunnerTestGame.Scripts.Player;
using _EndlessRunnerTestGame.Scripts.Scoring;
using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerManager playerManager;
        [SerializeField] private TouchInputManager touchInputManager;
        [SerializeField] private GameSceneManager gameSceneManager;

        [SerializeField] private GameObject gameOverMenu;

        private void Awake()
        {
            GlobalGameEvents.OnGameOver += EnableGameOverMenu;
        }

        /// <summary>
        /// Shows the game over menu when player dies.
        /// </summary>
        private void EnableGameOverMenu()
        {
            if (gameOverMenu != null) gameOverMenu.SetActive(true);
        }

        /// <summary>
        /// Starts the game by activating player and input.
        /// </summary>
        public void StartGame()
        {
            playerManager.ActivatePlayer();
            touchInputManager.enabled = true;
            ScoreManager.Score = 0;
            GlobalGameEvents.OnGameStarted?.Invoke();
        }

        /// <summary>
        /// Restarts the game by reloading the current scene.
        /// </summary>
        public void RestartGame()
        {
            gameSceneManager.ReloadScene();
        }
    }
}