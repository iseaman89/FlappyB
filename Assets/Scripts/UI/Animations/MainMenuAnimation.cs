using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace UI.Animations
{
    public class MainMenuAnimation
    {
        private readonly HorizontalLayoutGroup _buttonsContainer;
        private readonly Image _label;

        public MainMenuAnimation(GameObject mainMenuWindow)
        {
            _buttonsContainer = mainMenuWindow.GetComponentInChildren<HorizontalLayoutGroup>();
            _label = mainMenuWindow.GetComponentInChildren<Image>();
        }

        public void Enter()
        {
            _label.transform.DOMoveY(0, .5f).SetEase(Ease.InBounce);
            _buttonsContainer.transform.DOMoveY(-3, .5f).SetEase(Ease.InBounce);
        }

        public void Exit()
        {
            _label.transform.DOMoveY(6, .5f).SetEase(Ease.OutBounce);
            _buttonsContainer.transform.DOMoveY(-10, .5f).SetEase(Ease.OutBounce);
        }
    }
}