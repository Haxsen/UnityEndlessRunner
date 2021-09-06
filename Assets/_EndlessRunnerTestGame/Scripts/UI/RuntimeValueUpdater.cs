using _EndlessRunnerTestGame.Scripts.Scoring;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace _EndlessRunnerTestGame.Scripts.UI
{
    public class RuntimeValueUpdater : MonoBehaviour
    {
        public Text uIText;

        private void Start()
        {
            this.UpdateAsObservable()
                .Subscribe(_ => uIText.text = ScoreManager.Score.ToString());
        }
    }
}