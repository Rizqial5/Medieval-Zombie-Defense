using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using TestAG.Boot;
using TestAG.Module.Timer;
using TestAG.Module.Wall;
using UnityEngine;

namespace TestAG.Module.Core
{
    public class GameManagerController : ObjectController<GameManagerController, GameManagerView>
    {
        TimerController timerController;
        WallController wallController;

        public override void SetView(GameManagerView view)
        {
            base.SetView(view);

            view.SetButtonListener(RestartButton, BackButton);

            timerController.SetOnTimeDoneListener(() => { view.SetPanelActive(true); });
            wallController.AddListenerCastleDestroyed(() => { view.SetPanelActive(true); });

        }

        private void BackButton()
        {
            SceneLoader.Instance.LoadScene("HomeScene");
        }

        private void RestartButton()
        {
            SceneLoader.Instance.LoadScene("GameplayScene");
        }
    }
}
