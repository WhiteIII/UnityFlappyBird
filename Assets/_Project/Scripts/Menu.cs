using UnityEngine.UI;
using TMPro;
using UnityEngine;

namespace _Project
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private TMP_Text _logo;
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private Button _startGameButton;
        [SerializeField] private GameObject _leadeBoardFrame;

        public static Menu Instance { get; private set; }

        private void Awake()
        {
            if (!Instance)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

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