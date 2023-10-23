using PlayerStuff;
using UI;
using UnityEngine;

namespace StateMachine.States
{
    public class StartGameState : IState, IUpdateListener
    {
        private readonly StartGameUI _startGameUI;
        private readonly GameStateMachine _stateMachine;
        private readonly Updater _updater;
        private readonly Player _player;

        public StartGameState(StartGameUI startGameUI, GameStateMachine stateMachine, Updater updater, Player player)
        {
            _startGameUI = startGameUI;
            _stateMachine = stateMachine;
            _updater = updater;
            _player = player;
        }

        public void Enter()
        {
            _player.SetActive(true);
            _player.ResetPosition();
            _player.Deactivate();
            _startGameUI.Show();
            _updater.AddListener(this);
        }

        public void Exit()
        {
            _startGameUI.Hide();
            _updater.RemoveListener(this);
        }

        public void Updater(float deltaTime)
        {
#if UNITY_ANDROID
            
            if (Input.touchCount <= 0) return;
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _stateMachine.SetState<InGameState>();
            }
            
#endif
#if UNITY_EDITOR

            if (Input.GetKeyDown(KeyCode.Space)) _stateMachine.SetState<InGameState>();
            
#endif
        }
    }
}