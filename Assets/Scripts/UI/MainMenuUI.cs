using UI.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuUI
    {
        private readonly MainMenuAnimation _mainMenuAnimation;
        public Button PlayButton { get; private set; }

        public MainMenuUI(GameObject mainMenuWindow)
        {
            _mainMenuAnimation = new MainMenuAnimation(mainMenuWindow);
            PlayButton = mainMenuWindow.GetComponentInChildren<Button>();
        }

        public void Show()
        {
            _mainMenuAnimation.Enter();
        }

        public void Hide()
        {
            _mainMenuAnimation.Exit();
        }
    }
}