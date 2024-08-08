using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using TestAG.Boot;
using TestAG.Module.Character;
using TestAG.Module.Shot;
using TestAG.Module.Enemy;
using TestAG.Module.Timer;
using TestAG.Module.Core;
using TestAG.Module.Wall;

namespace TestAG.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        public override string SceneName => "GameplayScene";

        
        private MainCharController _mainChar;
        private EnemyManagerController _enemyManager;
        private EnemyController _enemyController;
        private TimerController _timerController;
        private GameManagerController _gameManagerController;
        private WallController _wallController;
        


        protected override IConnector[] GetSceneConnectors()
        {
            return null;
        }

        protected override IController[] GetSceneDependencies()
        {
            return new IController[] {


                new MainCharController(),
                new ShotController(),
                new EnemyManagerController(),
                new EnemyController(),
                new TimerController(),
                new WallController(),
                new GameManagerController(),

            };
        }

        protected override IEnumerator InitSceneObject()
        {
            
            _mainChar.SetView(_view.CharacterGameView);
            _enemyManager.SetView(_view.EnemyManagerView);
            _timerController.SetView(_view.TimerView);
            _wallController.SetView(_view.WallView);
            _gameManagerController.SetView(_view.GameManagerView);


            InvokeRepeating("SpawnEnemy", _view.spawnRate, _view.spawnRate);
            _timerController.SetOnTimeDoneListener(CancelSpawn);
            _wallController.AddListenerCastleDestroyed(CancelSpawn);
            

            yield return null;
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }

        public void SpawnEnemy()
        {
            GameObject spawnedEnemy = _enemyManager.SpawnEnemy();

            EnemyController enemyController = _enemyController;

            enemyController.SetView(spawnedEnemy.GetComponent<EnemyView>());

            Destroy(spawnedEnemy, 3f);
        }

        public void CancelSpawn()
        {
            CancelInvoke("SpawnEnemy");
        }
    }
}
