using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using TestAG.Module.Timer;
using TestAG.Module.Wall;
using UnityEngine;

namespace TestAG.Module.Enemy
{
    public class EnemyManagerController : ObjectController<EnemyManagerController, EnemyManagerModel, IEnemyManager,EnemyManagerView>
    {

        private EnemyController enemyController;
        private TimerController timerController;
        private WallController wallController;
        


        public override void SetView(EnemyManagerView view)
        {
            base.SetView(view);

            

            //timerController.SetOnTimeDoneListener(() => { view.CancelInvoke("SpawnEnemy"); });
        }

        public GameObject SpawnEnemy()
        {
            int spawnIndex = Random.Range(0, _model.GetEnemyTransforms().Length);

            GameObject spawnedEnemy = GameObject.Instantiate(_model.GetEnemyPrefab(), _model.GetEnemyTransforms()[spawnIndex].position, Quaternion.identity);


            enemyController.SetView(spawnedEnemy.GetComponent<EnemyView>());

            spawnedEnemy.GetComponent<EnemyView>().onEnemyDie.AddListener(CountEnemyDeadCount);
            
            return spawnedEnemy;
        }

       

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();

            GameObject enemyPrefab = Resources.Load<GameObject>(@"Prefab/EnemyPrefab");

            GameObject[] enemySpawnLocations = GameObject.FindGameObjectsWithTag("Enemy Pos");
            Transform[] enemySpawnTransfoms = new Transform[enemySpawnLocations.Length];

            for (int i = 0; i < enemySpawnLocations.Length; i++)
            {
                enemySpawnTransfoms[i] = enemySpawnLocations[i].transform;
            }

            _model.SetEnemyLocations(enemySpawnTransfoms);
            _model.SetEnemyPrefab(enemyPrefab);

            
        }

        public void CountEnemyDeadCount()
        {
            if (timerController.CheckTime()) return;
            if (wallController.IsCastleDestroyed()) return;
            _model.AddEnemyDeadCount();
        }

        
    }
}
