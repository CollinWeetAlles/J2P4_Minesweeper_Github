//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;
//using System.IO;

//public class Leaderboard : MonoBehaviour
//{
//    [SerializeField] private List<TextMeshProUGUI> playerNameTextsTMP = new List<TextMeshProUGUI>();
//    [SerializeField] private List<TextMeshProUGUI> scoreTextsTMP = new List<TextMeshProUGUI>();

//    private List<LeaderboardEntry> leaderboardEntries = new List<LeaderboardEntry>();
//    private string leaderboardFilePath;

//    private void Start()
//    {
//        leaderboardFilePath = Application.persistentDataPath + "/leaderboard.json";
//        Debug.Log(Application.persistentDataPath);
//        LoadLeaderboard();
//        UpdateLeaderboardUI();
//    }

//    private void LoadLeaderboard()
//    {
//        if (File.Exists(leaderboardFilePath))
//        {
//            string json = File.ReadAllText(leaderboardFilePath);
//            leaderboardEntries = JsonUtility.FromJson<LeaderboardWrapper>(json).leaderboardEntries;
//        }
//        else
//        {
//            Debug.LogWarning("Leaderboard file not found, creating new.");
//            InitializeLeaderboard();
//        }
//    }

//    private void SaveLeaderboard()
//    {
//        LeaderboardWrapper wrapper = new LeaderboardWrapper { leaderboardEntries = leaderboardEntries };
//        string json = JsonUtility.ToJson(wrapper);
//        File.WriteAllText(leaderboardFilePath, json);
//    }

//    private void InitializeLeaderboard()
//    {
//        for (int i = 0; i < 10; i++)
//        {
//            leaderboardEntries.Add(new LeaderboardEntry("Player" + (i + 1), 100 - i * 10));
//        }
//        SaveLeaderboard();
//    }

//    private void UpdateLeaderboardUI()
//    {
//        for (int i = 0; i < playerNameTextsTMP.Count && i < leaderboardEntries.Count; i++)
//        {
//            playerNameTextsTMP[i].text = leaderboardEntries[i].playerName;
//            scoreTextsTMP[i].text = leaderboardEntries[i].score.ToString();
//        }
//    }

//    public void AddToLeaderboard(string playerName, int score)
//    {
//        leaderboardEntries.Add(new LeaderboardEntry(playerName, score));
//        leaderboardEntries.Sort((a, b) => b.score.CompareTo(a.score));
//        if (leaderboardEntries.Count > 10)
//        {
//            leaderboardEntries.RemoveAt(leaderboardEntries.Count - 1);
//        }
//        SaveLeaderboard();
//        UpdateLeaderboardUI();
//    }

//    [System.Serializable]
//    public class LeaderboardWrapper
//    {
//        public List<LeaderboardEntry> leaderboardEntries;
//    }

//    [System.Serializable]
//    public class LeaderboardEntry
//    {
//        public string playerName;
//        public int score;

//        public LeaderboardEntry(string playerName, int score)
//        {
//            this.playerName = playerName;
//            this.score = score;
//        }
//    }
//}