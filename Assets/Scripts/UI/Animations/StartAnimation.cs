using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Animations
{
    public class StartAnimation
    {
        private readonly Image[] _images;

        public StartAnimation(GameObject startGameWindow)
        {
            _images = startGameWindow.GetComponentsInChildren<Image>();
        }

        public void Enter()
        {
            for (var i = 0; i < _images.Length - 1; i++)
            {
                _images[i].transform.DOScale(Vector3.one, .5f).SetEase(Ease.InBack);
            }
        }

        public void Exit()
        {
            foreach (var image in _images)
            {
                image.transform.DOScale(Vector3.zero, .5f).SetEase(Ease.OutBack);
            }
        }
    }
}