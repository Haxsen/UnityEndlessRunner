using _EndlessRunnerTestGame.Scripts.SO;
using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Scoring
{
    /// <summary>
    /// Manages the player's score (collecting coins etc).
    /// </summary>
    public class ScoreManager : MonoBehaviour
    {
        public static int Score;
        public int highScore;
        // public ScoringSO scoringObject;

        // private void Start()
        // {
        //     highScore = PlayerPrefs.GetInt("HighScore");
        // }

        /// <summary>
        /// Adds the specified amount to the score.
        /// </summary>
        /// <param name="toAddScore">Amount of score to add.</param>
        public void AddScore(int toAddScore)
        {
            // scoringObject.score += toAddScore;
            Score += toAddScore;
            SetHighScore();
        }

        private void SetHighScore()
        {
            // if (scoringObject.score > scoringObject.highScore)
            // scoringObject.highScore = scoringObject.score;
            if (Score > highScore)
            {
                highScore = Score;
                PlayerPrefs.SetInt("HighScore", highScore);
            }
        }
    }
}
