using LoadSave;
using Pipes;
using PlayerStuff;
using Scores;
using UI;
using UnityEngine;

namespace StateMachine.States
{
    public class GameOverState : IState
    {
        private readonly GameOverUI _gameOverUI;
        private readonly GameStateMachine _stateMachine;
        private readonly Player _player;
        private readonly PipeSpawner _pipeSpawner;
        private readonly PipePool _pool;
        private readonly ScoreUpdater _scoreUpdater;
        private readonly ScoreUpdaterUI _scoreUpdaterUI;
        private readonly LoadSaveScore _loadSaveScore;

        public GameOverState(GameOverUI gameOverUI, GameStateMachine stateMachine, Player player, PipeSpawner pipeSpawner,
            PipePool pool, ScoreUpdater scoreUpdater, ScoreUpdaterUI scoreUpdaterUI, LoadSaveScore loadSaveScore)
        {
            _gameOverUI = gameOverUI;
            _stateMachine = stateMachine;
            _player = player;
            _pipeSpawner = pipeSpawner;
            _pool = pool;
            _scoreUpdater = scoreUpdater;
            _scoreUpdaterUI = scoreUpdaterUI;
            _loadSaveScore = loadSaveScore;
        }
        
        public void Enter()
        {
            Time.timeScale = 0;
            _gameOverUI.Show();
            _player.Deactivate();
            _pipeSpawner.Stop();
            _loadSaveScore.Save(_scoreUpdater.Score.BestScore);
            _gameOverUI.OkButton.onClick.AddListener(BackToMenu);
        }

        public void Exit()
        {
            Time.timeScale = 1;
            _gameOverUI.Hide();
            _player.SetActive(false);
            _pool.DeactivateAll();
            ResetScore();
            _gameOverUI.OkButton.onClick.RemoveListener(BackToMenu);
        }

        private void BackToMenu() => _stateMachine.SetState<MainMenuState>();

        private void ResetScore()
        {
            _scoreUpdater.Reset();
            _scoreUpdaterUI.UpdateScore();
        }
    }
}