using System;
using System.Collections.Generic;

namespace StateMachine
{
    public class GameStateMachine
    {
        private IState _currentState;
        private readonly Dictionary<Type, IState> _states = new();

        public void Register<T>(IState state) => _states.Add(typeof(T), state);

        public void SetState<T>()
        {
            if (!_states.TryGetValue(typeof(T), out var state)) return;
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }
}