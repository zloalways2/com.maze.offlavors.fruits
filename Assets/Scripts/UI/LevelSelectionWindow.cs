using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LevelSelectionWindow : Window
    {
        [SerializeField]
        private LevelSelectButton[] _levelSelectButtons;
        [SerializeField]
        private Button _exitToMenu;

        public override void Initialize()
        {
            base.Initialize();
            _exitToMenu.onClick.AddListener(()=>_manager.SwitchWindow(typeof(MenuWindow)));
        }


        public override void Show()
        {
            base.Show();

            for (int i = 0; i < _levelSelectButtons.Length; i++)
            {
                var stars = 0;
                if (PlayerPrefs.HasKey($"LevelDone{i}"))
                {
                    stars = PlayerPrefs.GetInt($"LevelDone{i}");
                }
                
                _levelSelectButtons[i].Configure(StartLevel,i, stars);
            }
        }

        public void StartLevel(int levelIndex)
        {
            var game = _manager.SwitchWindow(typeof(MazeGameWindow)) as MazeGameWindow;

            // ReSharper disable once Unity.NoNullPropagation
            game?.StartGame(levelIndex);
        }
    }
}