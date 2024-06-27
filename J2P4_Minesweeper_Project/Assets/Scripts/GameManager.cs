//using UnityEngine;

//public class GameManager : MonoBehaviour
//{
//    public static GameManager Instance { get; private set; }

//    public Timer timer;
//    public FlagCount flagCount;

//    private void Awake()
//    {
//        if (Instance == null)
//        {
//            Instance = this;
//            DontDestroyOnLoad(gameObject);
//        }
//        else
//        {
//            Destroy(gameObject);
//        }
//    }

//    public void RegisterTimer(Timer timerInstance)
//    {
//        timer = timerInstance;
//    }

//    public void RegisterFlagCount(FlagCount flagCountInstance)
//    {
//        flagCount = flagCountInstance;
//    }
//}
