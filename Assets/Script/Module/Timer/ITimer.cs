using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TestAG.Module.Timer
{
    public interface ITimer : IBaseModel
    {
        public float currentTime { get; }

        public bool timeIsUp {  get; }

        public UnityEvent onTimeDone { get; }
    }
}
