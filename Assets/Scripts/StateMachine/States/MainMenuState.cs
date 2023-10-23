using LoadSave;
using PlayerStuff;
using UI;

namespace StateMachine.States
{
    public class MainMenuState : IState
    {
        private readonly MainMenuUI _mainMenuUI;
        private readonly GameStateMachine _stateMachine;
        private readonly Player _player;

        public MainMenuState(MainMenuUI mainMenuUI, GameStateMachine stateMachine, Player player)
        {
            _mainMenuUI = mainMenuUI;
            _stateMachine = stateMachine;
            _player = player;
        }
        public void Enter()
        {
            _player.SetActive(false);
            _mainMenuUI.Show();
            _mainMenuUI.PlayButton.onClick.AddListener(StartGame);
        }

        public void Exit()
        {
            _mainMenuUI.Hide();
            _mainMenuUI.PlayButton.onClick.RemoveListener(StartGame);
        }

        private void StartGame()
        {
            _stateMachine.SetState<StartGameState>();
        }
    }
}