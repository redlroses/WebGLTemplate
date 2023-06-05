﻿using Infrastructure.Factory;
using Logic;

namespace Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly LoadingCurtain _curtain;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IGameFactory gameFactory,
            LoadingCurtain curtain)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _curtain = curtain;
        }

        public void Enter(string payload)
        {
            _curtain.Show();
            _gameFactory.Cleanup();
            _gameFactory.WarmUp();
            _sceneLoader.Load(payload, OnLoaded);
        }

        public void Exit() =>
            _curtain.Hide();

        private void OnLoaded() =>
            _stateMachine.Enter<GameLoopState>();
    }
}