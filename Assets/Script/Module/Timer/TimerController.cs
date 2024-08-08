using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using TestAG.Module.Wall;
using UnityEngine;
using UnityEngine.Events;

namespace TestAG.Module.Timer
{
    public class TimerController : ObjectController<TimerController,TimerModel,ITimer,TimerView>
    {
        private WallController wallController;


        public override IEnumerator Initialize()
        {
            yield return base.Initialize();

            _model.BuildDoneEvents();
        }

        public override void SetView(TimerView view)
        {
            base.SetView(view);

            
            _model.SetStartTime(view.StartTime());
            _model.SetTimeSpeed(view.TimeSpeed());


            

            view.onStartTime.AddListener(TimerCountDown); 
            
        }

        public void TimerCountDown()
        {
            if(CheckTime())
            {
                _model.SetStartTime(0);
                return;
            }

            if (wallController.IsCastleDestroyed()) return;

            _model.UpdateTime();
            
        }

        public bool CheckTime()
        {
            if(_model.currentTime <= 0)
            {
                _model.SetTimeDone(true);
                return true;
            }

            return false;
        }

        

        public void SetOnTimeDoneListener(UnityAction onTimeDone)
        {
            _model.AddDoneListenerEvents(onTimeDone);
        }
    }
}
