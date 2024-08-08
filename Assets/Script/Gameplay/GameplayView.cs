using UnityEngine;
using Agate.MVC.Base;
using TestAG.Module.Character;
using TestAG.Module.Enemy;
using TestAG.Module.Timer;
using TestAG.Module.Core;
using TestAG.Module.Wall;

namespace TestAG.Gameplay
{
    public class GameplayView : BaseSceneView
    {
        [SerializeField] public CharacterView CharacterGameView;
        [SerializeField] public EnemyManagerView EnemyManagerView;
        [SerializeField] public TimerView TimerView;
        [SerializeField] public GameManagerView GameManagerView;
        [SerializeField] public WallView WallView;

        [SerializeField] public float spawnRate;

       
    }
}
