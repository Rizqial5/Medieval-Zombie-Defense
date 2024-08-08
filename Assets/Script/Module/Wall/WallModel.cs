using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TestAG.Module.Wall
{
    public class WallModel : BaseModel, IWallModel
    {
        public int castleHealth {  get; private set; }
        public bool isCastleDestroyed {  get; private set; }
        public UnityEvent onCastleDestroyed {  get; private set; }
        

        public void SetCastleHealth(int castleHealth)
        {  
            this.castleHealth = castleHealth;
            SetDataAsDirty();
        }

        public void BuildEvent()
        {
            onCastleDestroyed = new UnityEvent();
        }

        public void AddCastleDestroyedListener(UnityAction onCastleDestroyedListener)
        {
            onCastleDestroyed.AddListener(onCastleDestroyedListener);
        }

        public void DecreaseHealth()
        {
            castleHealth--;

            if(castleHealth <=0 )
            {
                isCastleDestroyed = true;
                onCastleDestroyed.Invoke();
            }

            SetDataAsDirty();
        }

       

        
        public void SetCastleDestroyed()
        {
            isCastleDestroyed = true;

            SetDataAsDirty() ;
        }
    }
}
