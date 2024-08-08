using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestAG.Module.Enemy
{
    public class EnemyModel : BaseModel, IEnemyModel
    {
        public float enemySpeed {  get; private set; }

        public bool isEnemyDie { get; private set; }

        public void SetEnemySpeed(float speed)
        {
            enemySpeed = speed;

            SetDataAsDirty();
        }

        public void SetEnemyDie(bool enemyDie)
        {
            isEnemyDie = enemyDie;
        }
    }
}
