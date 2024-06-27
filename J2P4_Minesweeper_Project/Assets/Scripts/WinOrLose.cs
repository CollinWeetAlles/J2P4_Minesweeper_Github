//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.UI;

//public class WinOrLose : MonoBehaviour
//{
//    [SerializeField] List<Sprite> Smileys = new List<Sprite>();
//    [SerializeField] Image img;
//    private int currentSmile = 0;

//    public void ChangeSprite(int smileIndex)
//    {
//        if (smileIndex >= 0 && smileIndex < Smileys.Count)
//        {
//            img.sprite = Smileys[smileIndex];
//            currentSmile = smileIndex;
//        }
//        else
//        {
//            Debug.LogError("Smile index out of range.");
//        }
//    }
//}