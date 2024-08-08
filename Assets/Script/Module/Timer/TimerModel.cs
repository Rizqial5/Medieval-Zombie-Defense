using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TestAG.Module.Timer
{
    public class TimerModel : BaseModel, ITimer
    {
        public float startTime {  get; private set; }

        public float currentTime {  get; private set; }

        public float timeSpeed {  get; private set; }

        public bool timeIsUp { get; private set; }

        public UnityEvent onTimeDone { get; private set; }
        public void SetStartTime(float startTime)
        { 
            this.startTime = startTime;
            
            currentTime = this.startTime * 60;

            SetDataAsDirty();
        }

        public void SetTimeSpeed(float timeSpeed)
        { 
            this.timeSpeed = timeSpeed;

            SetDataAsDirty();
        }

        public void SetTimeDone(bool isTimeDone)
        {
            this.timeIsUp = isTimeDone;

            SetDataAsDirty() ;
        }

        public void BuildDoneEvents()
        {
            onTimeDone = new UnityEvent();
        }

        public void AddDoneListenerEvents(UnityAction onDone)
        {
            onTimeDone.AddListener(onDone);
        }

        public void UpdateTime()
        {
            currentTime -= Time.deltaTime * timeSpeed;

            SetDataAsDirty() ;
        }

    }
}
