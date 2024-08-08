using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace TestAG.Module.Enemy
{
    public class EnemyController : ObjectController<EnemyController, EnemyModel, IEnemyModel, EnemyView>
    {
        
        
        public void SetEnemySpeed()
        {
            _model.SetEnemySpeed(5);
        }

        public void EnemyDie()
        {
            _model.SetEnemyDie(true);
        }
        

        public override void SetView(EnemyView view)
        {
            base.SetView(view);

            SetEnemySpeed();

            view.onEnemyDie.AddListener(EnemyDie);
        }

       
        
    }
}
