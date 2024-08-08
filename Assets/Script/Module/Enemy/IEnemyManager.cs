using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestAG.Module.Enemy
{
    public interface IEnemyManager : IBaseModel
    {
        public int enemyDeadCount {  get;  }
    }
}
