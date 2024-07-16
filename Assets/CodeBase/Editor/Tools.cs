using System.IO;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

namespace CodeBase.Editor
{
    [UsedImplicitly]
    public class Tools 
    {
        [MenuItem("Tools/Clear Save")]
        public static void ClearSave() =>
            File.Delete(Application.persistentDataPath + "/score.txt");
    }
}
