﻿using RollAndBall.Model;
using System.IO;
using UnityEngine;

namespace RollAndBall
{
    public sealed class SaveDataRepository
    {
        private readonly IData<SavedData> _data;

        private const string _folderName = "dataSave";
        private const string _fileName = "data.bat";
        private readonly string _path;

        public SaveDataRepository()
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                _data = new PlayerPrefsData();
            }
            else
            {
                _data = new JsonData<SavedData>();
            }
            _path = Path.Combine(Application.dataPath, _folderName);
        }

        public void Save(PlayerBase player)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
            var savePlayer = new SavedData
            {
                Position = player.transform.position,
                Name = "Vitaliy",
                IsEnabled = true
            };

            _data.Save(savePlayer, Path.Combine(_path, _fileName));
        }

        public void Load(PlayerBase player)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file)) return;
            var newPlayer = _data.Load(file);
            player.transform.position = newPlayer.Position;
            player.name = newPlayer.Name;
            player.gameObject.SetActive(newPlayer.IsEnabled);

            Debug.Log(newPlayer);
        }

        public void SaveBonus(InteractiveObject bonus)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
            var saveBonus = new SavedData
            {
                Position = bonus.transform.position,
                Name = "Bonus",
                IsEnabled = true
            };

            _data.Save(saveBonus, Path.Combine(_path, _fileName));
        }
    }
}