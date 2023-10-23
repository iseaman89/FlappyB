using UI;

namespace Scores
{
    public class ScoreUpdaterUI
    {
        private readonly GameOverUI _gameOverUI;
        private readonly InGameUI _inGameUI;
        private readonly ScoreUpdater _scoreUpdater;

        public ScoreUpdaterUI(GameOverUI gameOverUI, InGameUI inGameUI, ScoreUpdater scoreUpdater)
        {
            _gameOverUI = gameOverUI;
            _inGameUI = inGameUI;
            _scoreUpdater = scoreUpdater;
        }

        public void UpdateScore()
        {
            _inGameUI.ScoreText.text = _scoreUpdater.Score.LastScore.ToString();
            _gameOverUI.ScoreText.text = _scoreUpdater.Score.LastScore.ToString();
            _gameOverUI.BestScoreText.text = _scoreUpdater.Score.BestScore.ToString();
        }
    }
}