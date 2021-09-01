using _EndlessRunnerTestGame.Scripts.SO;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace _EndlessRunnerTestGame.Scripts.UI
{
    public class RuntimeValueUpdater : MonoBehaviour
    {
        public Text uIText;
        public ScoringSO scoringObject;

        private void Start()
        {
            this.UpdateAsObservable()
                .Subscribe(_ => uIText.text = scoringObject.score.ToString());
        }
    }
}