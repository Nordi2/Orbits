using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CodeBase.Data;
using CodeBase.UI.Score;
using UnityEngine;

namespace CodeBase.SaveSystem
{
    public static class SaveProgress
    {
        public static void SaveScore(ScoreWallet scoreWallet)
        {
            PlayerData data = LoadProgress.LoadPlayer();
            if (data.Score < scoreWallet.Score)
            {
                data.SaveScore(scoreWallet);
                File.Delete(Application.persistentDataPath + "/score.txt");
                BinaryFormatter formatter = new BinaryFormatter();
                string path = Application.persistentDataPath + "/score.txt";
                FileStream stream = new FileStream(path, FileMode.Create);
                formatter.Serialize(stream, data);
                stream.Close();
            }
        }

        public static void FirstSaveScore(ScoreWallet scoreWallet)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/score.txt";
            FileStream stream = new FileStream(path, FileMode.Create);

            PlayerData data = new PlayerData(scoreWallet);
            formatter.Serialize(stream, data);
            stream.Close();
        }
    }
}