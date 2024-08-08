using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

namespace TestAG.Module.Enemy
{
    public class EnemyManagerModel : BaseModel, IEnemyManager
    {
        public GameObject enemyPrefab {  get; private set; }
        public Transform[] enemySpawnLocations {  get; private set; }

        public int enemyDeadCount { get; private set; }

       

        public void SetEnemyPrefab(GameObject enemyPrefab)
        {
            this.enemyPrefab = enemyPrefab;
        }

        public void SetEnemyLocations(Transform[] enemyLocations)
        {
            enemySpawnLocations = enemyLocations;
        }

        public void AddEnemyDeadCount()
        {
            enemyDeadCount++;
            
            SetDataAsDirty();
        }
        

        public Transform[] GetEnemyTransforms() { return enemySpawnLocations; }
        public GameObject GetEnemyPrefab() { return this.enemyPrefab; }

    }
}
