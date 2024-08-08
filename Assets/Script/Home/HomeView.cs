using Agate.MVC.Base;
using Agate.MVC.Core;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TestAG.Home
{
    public class HomeView : BaseSceneView
    {
        [SerializeField] Button _playButton;
        [SerializeField] Button _exitButton;


        public void SetCallBacks(UnityAction onClickPlayButton, UnityAction onExitButton)
        {
            _playButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();

            _playButton.onClick.AddListener(onClickPlayButton);
            _exitButton.onClick.AddListener(onExitButton);
        }
    }
}
