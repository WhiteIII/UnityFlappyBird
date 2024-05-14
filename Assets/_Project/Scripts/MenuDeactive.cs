using UnityEngine;

namespace _Project
{
    public class MenuDeactive : MonoBehaviour
    {
        private GameStart _gameStart;
        private Menu _menu;

        private void Start()
        {
            _gameStart = GameStart.Instance;
            _menu = Menu.Instance;

            _gameStart.GameStarted += MenuDeactivate;
        }

        private void OnDestroy()
        {
            _gameStart.GameStarted -= MenuDeactivate;
        }

        private void MenuDeactivate()
        {
            _menu.RemoveLeaderBoard();
            _menu.RemoveLogo();
            _menu.RemoveStartButton();
            _menu.RemoveInputField();
        }
    }
}