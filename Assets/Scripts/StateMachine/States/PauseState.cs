using UI;
using UnityEngine;

namespace StateMachine.States
{
    public class PauseState : IState
    {
        private readonly PauseUI _pauseUI;
        private readonly GameStateMachine _stateMachine;

        public PauseState(PauseUI pauseUI, GameStateMachine stateMachine)
        {
            _pauseUI = pauseUI;
            _stateMachine = stateMachine;
        }
        
        public void Enter()
        {
            Time.timeScale = 0;
            _pauseUI.Show();
            _pauseUI.PlayButton.onClick.AddListener(ResumeGame);
        }

        public void Exit()
        {
            Time.timeScale = 1;
            _pauseUI.Hide();
            _pauseUI.PlayButton.onClick.RemoveListener(ResumeGame);
        }

        private void ResumeGame() => _stateMachine.SetState<InGameState>();
    }
}