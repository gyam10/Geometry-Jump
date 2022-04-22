using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class killPlayer : MonoBehaviour
{
    public int Respawn;
     
   
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player")) 
        {

            if(PlayerPrefs.GetFloat("Highscore") < scoreDis.Distance + CoinScript.coinCount)
                PlayerPrefs.SetFloat("Highscore", scoreDis.Distance + CoinScript.coinCount);
            
            SceneManager.LoadScene(Respawn);
            
        }

    }
    


}
