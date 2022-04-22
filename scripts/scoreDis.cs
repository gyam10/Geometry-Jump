using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreDis : MonoBehaviour
{
    public Transform Player;
    public Text distext;
    public static float Distance;
    // Update is called once per frame
  
    void Update()
    {
        Distance = Player.position.x;
        distext.text = Distance.ToString("0");
        

    }
}