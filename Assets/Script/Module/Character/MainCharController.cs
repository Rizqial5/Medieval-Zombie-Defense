using Agate.MVC.Base;
using Agate.MVC.Core;
using System.Collections;
using System.Collections.Generic;
using TestAG.Module.Shot;
using TestAG.Module.Timer;
using TestAG.Module.Wall;
using UnityEngine;

namespace TestAG.Module.Character
{
    public class MainCharController : ObjectController<MainCharController, CharacterModule, CharacterView>
    {

        private ShotController _shotController;
        private TimerController _timerController;
        private WallController _wallController;

        public override void SetView(CharacterView view)
        {
            base.SetView(view);


            _shotController.SetShotMechanic(view.SetBullet(), view.transform, view.SetAnimator());



            view.onUpdate.AddListener(() => { CharacterController(view.SetPositionList()); });

            view.onUpdate.AddListener(_shotController.ShotButton);

            SetChar(view.SetPlayer());


        }

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();

            

            _model.SetPosisionIndex();
        }

        public void CharacterController(Transform[] positionLists)
        {
            if (_timerController.CheckTime()) return;
            if (_wallController.IsCastleDestroyed()) return;

            if(Input.GetKeyDown(KeyCode.A))
            {
                _model.DecreasePositionIndex();
            }
            else if(Input.GetKeyDown(KeyCode.D))
            {
                _model.AddPositionIndex();
            }

            _model.CharacterMover(positionLists);
        }

        public void SetChar(GameObject player)
        {
            _model.character = player;
            
        }

        
    }
}
