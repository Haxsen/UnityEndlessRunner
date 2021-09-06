using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Scoring
{
    /// <summary>
    /// Manages the player's score (collecting coins etc).
    /// </summary>
    public class ScoreManager : MonoBehaviour
    {
        public static int Score;
        
        private int _highScore;
        // public ScoringSO scoringObject;

        private void Awake()
        {
            _highScore = PlayerPrefs.GetInt("HighScore");
        }

        /// <summary>
        /// Adds the specified amount to the score.
        /// </summary>
        /// <param name="toAddScore">Amount of score to add.</param>
        public void AddScore(int toAddScore)
        {
            // scoringObject.score += toAddScore;
            Score += toAddScore;
            if (Score > _highScore) SetHighScore();
        }

        private void SetHighScore()
        {
            // if (scoringObject.score > scoringObject.highScore)
            // scoringObject.highScore = scoringObject.score;
            _highScore = Score;
            PlayerPrefs.SetInt("HighScore", _highScore);
        }
    }
}
