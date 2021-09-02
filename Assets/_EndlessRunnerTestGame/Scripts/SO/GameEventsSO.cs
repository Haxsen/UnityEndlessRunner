using UnityEngine;
using UnityEngine.Events;

namespace _EndlessRunnerTestGame.Scripts.SO
{
    [CreateAssetMenu(fileName = "GameEventsObject", menuName = "Endless Runner ScriptableObjects/Create GameEventsObject", order = 1)]
    public class GameEventsSO : ScriptableObject
    {
        public UnityAction OnGameOver;
    }
}