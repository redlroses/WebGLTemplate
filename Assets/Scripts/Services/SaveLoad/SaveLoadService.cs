using Data;
using Infrastructure.Factory;
using Services.PersistentProgress;
using Tools.Extension;
using UnityEngine;

namespace Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "Progress";

        private readonly IPersistentProgressService _progressService;
        private readonly IGameFactory _gameFactory;

        public SaveLoadService(IPersistentProgressService progressService, IGameFactory gameFactory)
        {
            _progressService = progressService;
            _gameFactory = gameFactory;
        }

        public void SaveProgress()
        {
            foreach (ISavedProgress progressWriter in _gameFactory.ProgressWriters)
                progressWriter.UpdateProgress(_progressService.Progress);

            Debug.Log("save");
            PlayerPrefs.SetString(ProgressKey, _progressService.Progress.ToJson());
        }

        public PlayerProgress LoadProgress() =>
            PlayerPrefs.GetString(ProgressKey)?
                .ToDeserialized<PlayerProgress>();
    }
}