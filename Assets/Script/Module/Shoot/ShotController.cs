using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using TestAG.Module.Character;
using TestAG.Module.Timer;
using TestAG.Module.Wall;
using UnityEngine;


namespace TestAG.Module.Shot
{
    public class ShotController : DataController<ShotController,ShotModel,IShotMechanic>
    {
        private TimerController timerController;
        private WallController wallController;

        public void ShotButton()
        {
            if (timerController.CheckTime()) return;
            if (wallController.IsCastleDestroyed()) return;

            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                _model.ShootAction();

                _model.PlayAnimation();
            }
        }

        public void SetShotMechanic(GameObject bulletPrefab, Transform spawnPosition, Animator animator)
        {
            _model.SetBullet(bulletPrefab);
            _model.SetPosition(spawnPosition);
            _model.SetAnimator(animator);
        }


        
    }
}
