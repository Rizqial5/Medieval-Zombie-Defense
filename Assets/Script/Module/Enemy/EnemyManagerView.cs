using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TestAG.Module.Enemy
{
    public class EnemyManagerView : ObjectView<IEnemyManager>
    {
        [SerializeField] TextMeshProUGUI totalEnemyDefeatedText;


        protected override void InitRenderModel(IEnemyManager model)
        {
            totalEnemyDefeatedText.text = "Total Enemy Defeated : " + model.enemyDeadCount;
        }

        protected override void UpdateRenderModel(IEnemyManager model)
        {
            totalEnemyDefeatedText.text = "Total Enemy Defeated : " + model.enemyDeadCount;

            
        }

        
    }

}