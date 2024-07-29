using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CodeBase.Data;
using UnityEngine;

namespace CodeBase.Infrastructure.Service
{
    public static class LoadProgress
    {
        public static PlayerData LoadPlayer()
        {
            string path = Application.persistentDataPath + "/score.txt";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                PlayerData data = formatter.Deserialize(stream) as PlayerData;
                stream.Close();
                return data;
            }
            else
            {
                Debug.LogWarning("Save file not found in " + path);
                return null;
            }
        }
    }
}