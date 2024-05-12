using UnityEngine;

namespace _Project
{
    public class MenuDeactive : MonoBehaviour
    {
        [SerializeField] private Menu _menu;
        [SerializeField] private GameStart _gameStart;

        private void Awake()
        {
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