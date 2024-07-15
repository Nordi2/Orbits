using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CodeBase.Data;
using CodeBase.UI.Score;
using UnityEngine;

namespace CodeBase.SaveSystem
{
    public static class SaveProgress
    {
        public static bool IsSave;

        public static void SaveScore(ScoreWallet scoreWallet)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/score.txt";
            FileStream stream = new FileStream(path, FileMode.Create);

            PlayerData data = new PlayerData(scoreWallet);
            IsSave = true;
            formatter.Serialize(stream, data);
            stream.Close();
        }
    }
}