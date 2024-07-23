using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CodeBase.Data;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Service.SaveSystem
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