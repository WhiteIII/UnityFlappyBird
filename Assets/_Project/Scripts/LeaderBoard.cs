
using System;
using System.Text;
using TMPro;
using UnityEngine;

namespace _Project
{
    public class LeaderBoard : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;

        private PlayerKill _playerKill;
        private PlayersPoints _playersPoints;
        private StringBuilder _stringBuilder = new StringBuilder();

        public string Input { get; private set; }
        public readonly string Highscore = "highscore";

        public void GrabOnInputField(string input)
        {
            Input = input;
        }

        private void Start()
        {
            _playersPoints = PlayersPoints.Instance;
            _playerKill = PlayerKill.Instance;

            _playerKill.OnPlayerKilled += SavePlayerPoints;
        }

        private void OnDestroy()
        {
            _playerKill.OnPlayerKilled -= SavePlayerPoints;
        }

        private void SavePlayerPoints()
        {
            string highscore = PlayerPrefs.GetString(Highscore);

            if (Input == null)
            {
                return;
            }

            if (PlayerPrefs.GetString(Highscore).Length == 0)
            {
                PlayerPrefs.SetString(Highscore, ";" + Input + ":" + _playersPoints.Points + ";");
            }

            if (PlayerPrefs.GetString(Highscore).Contains(";" + Input + ":"))
            {
                for (int i = 0; i < highscore.Split(';').Length; i++)
                {

                    if (highscore.Split(';')[i].Split(':')[0] == Input &&
                        Convert.ToInt32(highscore.Split(';')[i].Split(':')[1]) < _playersPoints.Points)
                    {
                        _stringBuilder.Append(highscore);
                        _stringBuilder.Replace(":" + highscore.Split(';')[i].Split(':')[1] + ";",
                            ":" + _playersPoints.Points + ";");
                        highscore = _stringBuilder.ToString();
                        PlayerPrefs.SetString(Highscore, highscore);
                    }
                }
            }
            else
            {
                PlayerPrefs.SetString(Highscore, highscore + Input + ":" + _playersPoints.Points + ";");
            }

            PlayerPrefs.Save();
        }
    }
}