using Audios;
using Pipes;
using PlayerStuff;
using Scores;
using UI;

namespace StateMachine.States
{
    public class InGameState : IState
    {
        private readonly InGameUI _inGameUI;
        private readonly GameStateMachine _stateMachine;
        private readonly Player _player;
        private readonly PipeSpawner _pipeSpawner;
        private readonly ScoreUpdater _scoreUpdater;
        private readonly ScoreUpdaterUI _scoreUpdaterUI;
        private readonly AudioPlayer _audioPlayer;

        public InGameState(InGameUI inGameUI, GameStateMachine stateMachine, Player player, PipeSpawner pipeSpawner,
            ScoreUpdater scoreUpdater, ScoreUpdaterUI scoreUpdaterUI, AudioPlayer audioPlayer)
        {
            _inGameUI = inGameUI;
            _stateMachine = stateMachine;
            _player = player;
            _pipeSpawner = pipeSpawner;
            _scoreUpdater = scoreUpdater;
            _scoreUpdaterUI = scoreUpdaterUI;
            _audioPlayer = audioPlayer;
        }
        
        public void Enter()
        {
            _player.Activate();
            _pipeSpawner.Start();
            _inGameUI.Show();
            _inGameUI.PauseButton.onClick.AddListener(Pause);
            _player.OnCollision += GameOver;
            _player.OnTrigger += UpdateScore;
            _player.OnJump += PlayJumpSound;
            _scoreUpdater.OnValueChanged += _scoreUpdaterUI.UpdateScore;
            _scoreUpdater.OnToastyGoalReached += ShowToasty;

        }

        public void Exit()
        {
            _inGameUI.Hide();
            _inGameUI.PauseButton.onClick.RemoveListener(Pause);
            _player.OnCollision -= GameOver;
            _player.OnTrigger -= UpdateScore;
            _player.OnJump -= PlayJumpSound;
            _scoreUpdater.OnValueChanged -= _scoreUpdaterUI.UpdateScore;
            _scoreUpdater.OnToastyGoalReached -= ShowToasty;
        }

        private void Pause() => _stateMachine.SetState<PauseState>();

        private void GameOver() 
        {
            _audioPlayer.PlaySound("Die");
            _stateMachine.SetState<GameOverState>();
        }

        private void UpdateScore()
        {
            _scoreUpdater.Update();
            _audioPlayer.PlaySound("Score");
        }

        private void ShowToasty()
        {
            _audioPlayer.PlaySound("Toasty");
            _inGameUI.InGameAnimation.ShowToasty();
        }

        private void PlayJumpSound() => _audioPlayer.PlaySound("Jump");
    }
}