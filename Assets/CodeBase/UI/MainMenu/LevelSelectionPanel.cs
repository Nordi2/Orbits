using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.MainMenu
{
    public class LevelSelectionPanel : MonoBehaviour
    {
        [SerializeField] private Button _circleLevelButton;
        [SerializeField] private Button _squateLevelButton;
        [SerializeField] private Button _triangleLevelButton;

        private void OnEnable()
        {
           // _circleLevelButton.onClick.AddListener(Load("GamePlayCircle"));
            
        }
        private void OnDisable()
        {
            
        }
        
    }
}