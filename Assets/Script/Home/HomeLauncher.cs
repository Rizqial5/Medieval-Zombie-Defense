using Agate.MVC.Base;
using Agate.MVC.Core;
using System.Collections;
using TestAG.Boot;
using UnityEngine;

namespace TestAG.Home
{
    public class HomeLauncher : SceneLauncher<HomeLauncher, HomeView>
    {
        public override string SceneName => "HomeScene";

        protected override IConnector[] GetSceneConnectors()
        {
            return null;
        }

        protected override IController[] GetSceneDependencies()
        {
            return null;
        }

        protected override IEnumerator InitSceneObject()
        {
            _view.SetCallBacks(OnClickPlayButton,OnExitButton);

            yield return null; 
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }

        private void OnClickPlayButton()
        {
            SceneLoader.Instance.LoadScene("GameplayScene");
        }

        private void OnExitButton()
        {
            Application.Quit();
        }
    }
}
