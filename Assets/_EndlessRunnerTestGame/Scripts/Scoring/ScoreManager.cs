using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Scoring
{
    /// <summary>
    /// Manages the player's score (collecting coins etc).
    /// </summary>
    public class ScoreManager : MonoBehaviour
    {
        public int score;

        public void AddScore(int toAddScore)
        {
            score += toAddScore;
        }
    }
}
