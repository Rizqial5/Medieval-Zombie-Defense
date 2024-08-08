using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace TestAG.Module.Timer
{
    public class TimerView : ObjectView<ITimer>
    {

        [SerializeField] TextMeshProUGUI showTimeText;

        [SerializeField] float startTimeInMinutes;
        [SerializeField] float timeSpeed;

        public UnityEvent onStartTime;
           

        protected override void InitRenderModel(ITimer model)
        {
            float minutes = Mathf.FloorToInt(model.currentTime / 60);
            float seconds = Mathf.FloorToInt(model.currentTime % 60);

            showTimeText.text = "Time :\n" + string.Format("{0:00}:{1:00}", minutes, seconds);
            

        }

        protected override void UpdateRenderModel(ITimer model)
        {
            float minutes = Mathf.FloorToInt(model.currentTime / 60);
            float seconds = Mathf.FloorToInt(model.currentTime % 60);

            

            if(model.timeIsUp)
            {
                model.onTimeDone.Invoke();
                minutes = 0;
                seconds = 0;
            }

            showTimeText.text = "Time :\n" + string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        private void Update()
        {
            onStartTime.Invoke();
        }

        public float StartTime()
        {
            return startTimeInMinutes;
        }

        public float TimeSpeed()
        { return timeSpeed;}
    }
}
