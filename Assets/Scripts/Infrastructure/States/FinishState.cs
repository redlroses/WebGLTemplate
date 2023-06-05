using CodeBase.Services.SaveLoad;

namespace CodeBase.Infrastructure.States
{
    public class FinishState : IState
    {
        private readonly ISaveLoadService _saveLoadService;

        public FinishState() { }

        public void Enter() { }

        public void Exit() { }
    }
}