﻿using Infrastructure.States;
using Logic;
using UnityEngine;

namespace Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private LoadingCurtain _curtain;

        private Game _game;

        private void Awake()
        {
            LoadingCurtain curtain = Instantiate(_curtain);
            _game = new Game(this, curtain);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}