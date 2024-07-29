using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CodeBase.Data;
using UnityEngine;

namespace CodeBase.Infrastructure.Service
{
    public static class SaveProgress
    {
        public static void SaveScore(PlayerData data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/score.txt";
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate);

            formatter.Serialize(stream, data);
            stream.Close();
        }
    }
}