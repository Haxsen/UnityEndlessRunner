using UnityEngine;
using UnityEngine.UI;

namespace _EndlessRunnerTestGame.Scripts.UI
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private Text highScoreText;
    
        private void OnEnable()
        {
            UpdateHighScore();
        }

        private void UpdateHighScore()
        {
            highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
    }
}
