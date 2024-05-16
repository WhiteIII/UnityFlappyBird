using UnityEngine.UI;
using TMPro;
using UnityEngine;

namespace _Project
{
    public class Menu : Singleton<Menu>
    {
        [SerializeField] private TMP_Text _logo;
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private Button _startGameButton;
        [SerializeField] private GameObject _leadeBoardFrame;

        public void RemoveLogo()
        {
            _logo.gameObject.SetActive(false);
        }

        public void RemoveStartButton()
        {
            _startGameButton.gameObject.SetActive(false);
        }

        public void RemoveLeaderBoard()
        {
            _leadeBoardFrame.SetActive(false);
        }

        public void RemoveInputField()
        {
            _inputField.gameObject.SetActive(false);
        }
    }
}