using UnityEngine;
using UnityEngine.SceneManagement;

namespace _EndlessRunnerTestGame.Scripts.Game
{
    public class GameSceneManager : MonoBehaviour
    {
        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
