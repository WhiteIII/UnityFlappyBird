using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

namespace _Project
{
    public class LeaderBoardScreen : MonoBehaviour
    {
        [SerializeField] private TMP_Text _topPlayersText;
        [SerializeField] private LeaderBoard _leaderBoard;
        [SerializeField] private PlayerKill _playerKill;
        [SerializeField] private int _topPlayersCount;

        private Dictionary<string, int> _playerDictionary = new Dictionary<string, int>();
        private string _highscore;
        private string _topHighscore = "";
        public int BestPlayerScore { get; private set; }

        private void Awake()
        {
            SetTopPlayers();
            _playerKill.OnPlayerKilled += SetTopPlayers;
        }

        private void OnDestroy()
        {
            _playerKill.OnPlayerKilled -= SetTopPlayers;
        }

        private void SetTopPlayers()
        {
            int topPlayersCount = _topPlayersCount;
            
            _highscore = PlayerPrefs.GetString(_leaderBoard.Highscore);
            
            if (_highscore == null)
            {
                return;
            }
            
            for (int i = 0; i < _highscore.Split(';').Length; i++)
            {
                if (_highscore.Split(";")[i] != "")
                {
                    _playerDictionary.Add(_highscore.Split(";")[i].Split(":")[0],
                        Convert.ToInt32(_highscore.Split(";")[i].Split(":")[1]));
                }
            }

            if (_playerDictionary.Count < _topPlayersCount)
            {
                topPlayersCount = _playerDictionary.Count;
            }

            var sortedDict = _playerDictionary.OrderByDescending(x => x.Value).
                Take(topPlayersCount).ToDictionary(x => x.Key, x => x.Value);
            var first = sortedDict.OrderBy(kvp => kvp.Key).First();
            string firstKey = first.Key;
            BestPlayerScore = sortedDict[firstKey];

            foreach (var highscore in sortedDict)
            {
                _topHighscore += highscore.Key + " | " + highscore.Value + "\n";
            }

            _topPlayersText.text = _topHighscore;

            _playerDictionary.Clear();
            sortedDict.Clear();
        }
    }
}