using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameOverUI
    {
        private readonly GameObject _gameOverWindow;
        public Button OkButton { get; }
        public TextMeshProUGUI ScoreText { get; private set; }
        public TextMeshProUGUI BestScoreText { get; private set; }

        public GameOverUI(GameObject gameOverWindow)
        {
            _gameOverWindow = gameOverWindow;
            OkButton = _gameOverWindow.GetComponentInChildren<Button>();
            ScoreText = _gameOverWindow.GetComponentsInChildren<TextMeshProUGUI>()[0];
            BestScoreText = _gameOverWindow.GetComponentsInChildren<TextMeshProUGUI>()[1];
        }
        
        public void Show() => _gameOverWindow.SetActive(true);

        public void Hide() => _gameOverWindow.SetActive(false);
    }
}