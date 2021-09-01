using _EndlessRunnerTestGame.Scripts.SO;
using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.Scoring
{
    /// <summary>
    /// Manages the player's score (collecting coins etc).
    /// </summary>
    public class ScoreManager : MonoBehaviour
    {
        public int score;
        public ScoringSO scoringObject;

        public void AddScore(int toAddScore)
        {
            scoringObject.score += toAddScore;
        }
    }
}
