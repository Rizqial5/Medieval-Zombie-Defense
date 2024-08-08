using Agate.MVC.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TestAG.Module.Core
{
    public class GameManagerView : BaseView
    {
        [SerializeField] GameObject gameStopPanel;
        [SerializeField] Button restartButton;
        [SerializeField] Button backButton;


        public void SetPanelActive(bool setActive)
        {
            gameStopPanel.SetActive(setActive);
        }

        public void SetButtonListener(UnityAction onRestartPressed, UnityAction onBackPressed)
        {
            restartButton.onClick.RemoveAllListeners();
            backButton.onClick.RemoveAllListeners();

            restartButton.onClick.AddListener(onRestartPressed);
            backButton.onClick.AddListener(onBackPressed);
        }
    }
}
