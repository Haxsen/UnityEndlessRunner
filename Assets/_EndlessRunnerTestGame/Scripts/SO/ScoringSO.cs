using UnityEngine;

namespace _EndlessRunnerTestGame.Scripts.SO
{
    /// <summary>
    /// SO which is responsible for keeping score value.
    /// </summary>
    [CreateAssetMenu(fileName = "ScoringObject", menuName = "Endless Runner ScriptableObjects/Create ScoringObject", order = 1)]
    public class ScoringSO : ScriptableObject, ISerializationCallbackReceiver
    {
        public int score;

        public void OnAfterDeserialize()
        {
            score = 0;
        }

        public void OnBeforeSerialize() { }
    }
}