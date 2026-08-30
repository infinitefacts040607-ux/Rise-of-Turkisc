using System.IO;
using UnityEngine;

namespace RiseOfTurkics.Core
{
    public static class SaveLoadManager
    {
        public static void Save(string path, SaveData data)
        {
            var dir = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var json = JsonUtility.ToJson(data, true);
            File.WriteAllText(path, json);
            Debug.Log($"Game saved to {path}");
        }

        public static SaveData Load(string path)
        {
            if (!File.Exists(path))
            {
                Debug.LogWarning($"Save file not found: {path}");
                return null;
            }

            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log($"Game loaded from {path}");
            return data;
        }
    }
}
