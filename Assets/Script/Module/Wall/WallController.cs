using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Events;

namespace TestAG.Module.Wall
{
    public class WallController : ObjectController<WallController, WallModel, IWallModel, WallView>
    {
        public override void SetView(WallView view)
        {
            base.SetView(view);

            _model.SetCastleHealth(view.CastleHealth());

            view.onCastleDamage = DecreaseHealth;

            _model.AddCastleDestroyedListener(CastleDestroyed);
            
        }

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();

            _model.BuildEvent();
        }

        public void DecreaseHealth()
        {
            _model.DecreaseHealth();
        }

        public void CastleDestroyed()
        {
            Debug.Log("Castle Destroyed");

            _model.SetCastleDestroyed();
        }

        public bool IsCastleDestroyed()
        {
            return _model.isCastleDestroyed;
        }

        public void AddListenerCastleDestroyed(UnityAction onCastleDestroyed)
        {
            _model.AddCastleDestroyedListener(onCastleDestroyed);
        }

        
    }
}
