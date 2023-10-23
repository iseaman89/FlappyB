using UI.Animations;
using UnityEngine;

namespace UI
{
    public class StartGameUI
    {
        private readonly StartAnimation _startAnimation;

        public StartGameUI(GameObject startGameWindow)
        {
            _startAnimation = new StartAnimation(startGameWindow);
        }

        public void Show() => _startAnimation.Enter();

        public void Hide() => _startAnimation.Exit();
    }
}