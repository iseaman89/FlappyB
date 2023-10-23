using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Animations
{
    public class InGameAnimation
    {
        private readonly Image _toasty;
        private readonly Button _pauseButton;
        private readonly TextMeshProUGUI _score;

        public InGameAnimation(GameObject inGameWindow)
        {
            _toasty = inGameWindow.GetComponentInChildren<Image>();
            _pauseButton = inGameWindow.GetComponentInChildren<Button>();
            _score = inGameWindow.GetComponentInChildren<TextMeshProUGUI>();
        }

        public void Enter()
        {
            _pauseButton.transform.DOMoveY(4.5f, .5f).SetEase(Ease.Linear);
            _score.transform.DOMoveY(4.5f, .5f).SetEase(Ease.Linear);
        }

        public void Exit()
        {
            _pauseButton.transform.DOMoveY(6, .5f).SetEase(Ease.Linear).SetUpdate(true);
            _score.transform.DOMoveY(6, .5f).SetEase(Ease.Linear).SetUpdate(true);
        }

        public void ShowToasty()
        {
            _toasty.transform.DOMoveX(1, 1f).OnComplete((() =>
                _toasty.transform.DOMoveX(4, 1f)));
        }
    }
}