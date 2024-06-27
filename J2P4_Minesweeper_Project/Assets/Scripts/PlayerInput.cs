//using UnityEngine;
//using TMPro;
//using UnityEngine.UI; // Make sure to include this for TextMeshProUGUI

//public class PlayerInput : MonoBehaviour
//{
//    [SerializeField] private InputField nameInputField; // TMP input field for player's name
//    [SerializeField] private Leaderboard leaderboard; // Reference to Leaderboard script

//    private void Start()
//    {
//        if (nameInputField == null)
//        {
//            Debug.LogError("nameInputField is not assigned in the Inspector.");
//            return;
//        }

//        if (leaderboard == null)
//        {
//            Debug.LogError("leaderboard is not assigned in the Inspector.");
//            return;
//        }

//        nameInputField.onEndEdit.AddListener(SubmitName);
//    }

//    private void SubmitName(string playerName)
//    {
//        int score = CalculateScore();
//        Debug.Log($"Submitting score: {score} for player: {playerName}");
//        leaderboard.AddToLeaderboard(playerName, score);
//        nameInputField.text = "";
//    }

//    private int CalculateScore()
//    {
//        if (GameManager.Instance == null)
//        {
//            Debug.LogError("GameManager instance is null.");
//            return 0;
//        }

//        Timer timer = GameManager.Instance.timer;
//        FlagCount flagCount = GameManager.Instance.flagCount;

//        if (timer == null)
//        {
//            Debug.LogError("Timer instance is null.");
//            return 0;
//        }

//        if (flagCount == null)
//        {
//            Debug.LogError("FlagCount instance is null.");
//            return 0;
//        }

//        int timeElapsed = timer.timerValue;
//        int flagsPlaced = flagCount.FlagsPlaced;
//        int score = flagsPlaced + timeElapsed; // Example scoring formula
//        return score;
//    }
//}
