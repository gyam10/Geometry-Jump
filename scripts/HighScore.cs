using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text highscore;
    private void Start()
    {
    
       highscore.text = PlayerPrefs.GetFloat("Highscore", 0).ToString("0");
    }
}
