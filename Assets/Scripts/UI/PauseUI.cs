using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PauseUI
    {
        private readonly GameObject _pauseWindow;
        public Button PlayButton { get; private set; }

        public PauseUI(GameObject pauseWindow)
        {
            _pauseWindow = pauseWindow;
            PlayButton = _pauseWindow.GetComponentInChildren<Button>();
        }
        
        public void Show() => _pauseWindow.SetActive(true);

        public void Hide() => _pauseWindow.SetActive(false);
    }
}