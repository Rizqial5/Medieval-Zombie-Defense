using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TestAG.Module.Wall
{
    public interface IWallModel : IBaseModel
    {
        public int castleHealth { get; }

        
    }
    
}
