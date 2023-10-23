using System;
using Audios;
using LoadSave;
using Pipes;
using PlayerStuff;
using Scores;
using StateMachine;
using StateMachine.States;
using UI;
using UnityEngine;
using UnityEngine.UI;
using World;

public class EntryPoint : MonoBehaviour
{
        [SerializeField] private PipeConfig _pipeConfig;
        [SerializeField] private Pipe _pipePrefab;
        [SerializeField] private WorldObjectConfig[] _worldObjectConfigs;
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private GameObject _mainMenuWindow;
        [SerializeField] private GameObject _startGameWindow;
        [SerializeField] private GameObject _puaseWindow;
        [SerializeField] private GameObject _inGameWindow;
        [SerializeField] private GameObject _gameOverWindow;
        [SerializeField] private AudioPlaylist _playlist;

        private void Awake()
        {
                var updater = gameObject.AddComponent<Updater>();
                
                var pipeFactory = new PipeFactory(_pipePrefab);
                var pipePool = new PipePool(pipeFactory, updater, _pipeConfig);
                var pipeSpawner = new PipeSpawner(_pipeConfig, pipePool, updater);
                
                var worldObjectsSpawner = new WorldObjectsSpawner(_worldObjectConfigs, updater);
                worldObjectsSpawner.Init();

                var playerFactory = new PlayerFactory(_playerPrefab);
                var player = playerFactory.Create();
                player.Configurate(_playerConfig, updater);

                var stateMachine = new GameStateMachine();

                var gameOverUI = new GameOverUI(_gameOverWindow);
                var inGameUI = new InGameUI(_inGameWindow);
                var score = new Score();
                var loadSaveScore = new LoadSaveScore(score);
                loadSaveScore.Load();
                var scoreUpdater = new ScoreUpdater(score);
                var scoreUpdaterUI = new ScoreUpdaterUI(gameOverUI, inGameUI, scoreUpdater);
                var audioSource = gameObject.AddComponent<AudioSource>();
                var audioPlayer = new AudioPlayer(_playlist, audioSource);
                        
                stateMachine.Register<MainMenuState>(new MainMenuState(new MainMenuUI(_mainMenuWindow),
                        stateMachine, player));
                stateMachine.Register<StartGameState>(new StartGameState(new StartGameUI(_startGameWindow),
                        stateMachine, updater, player));
                stateMachine.Register<InGameState>(new InGameState(inGameUI, stateMachine,player, pipeSpawner,
                        scoreUpdater, scoreUpdaterUI, audioPlayer));
                stateMachine.Register<PauseState>(new PauseState(new PauseUI(_puaseWindow), stateMachine));
                stateMachine.Register<GameOverState>(new GameOverState(gameOverUI, stateMachine, player, pipeSpawner,
                        pipePool, scoreUpdater, scoreUpdaterUI, loadSaveScore));
                stateMachine.SetState<MainMenuState>();
        }
}