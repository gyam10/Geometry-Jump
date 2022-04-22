using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinScript : MonoBehaviour
{

    public static int coinCount = 0;
    public TextMeshProUGUI textCoin;

    public bool Double;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "coin")
        {
            
            if (Double == true)
            {
                coinCount += 2;
            }
            
                coinCount += 1;
            
            textCoin.text = coinCount.ToString();

            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);

        }
    }

}