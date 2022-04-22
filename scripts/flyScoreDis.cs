using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flyScoreDis : MonoBehaviour
{
    public Transform Player;
    public Text distext;
    public static float Distance;
    // Update is called once per frame

    void Update()
    {
        Distance = Player.position.x / 1000;
        distext.text = Distance.ToString("0");


    }
}