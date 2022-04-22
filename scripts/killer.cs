using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class killer : MonoBehaviour
{
    public int Respawn;
    public static int deaths { get; private set; }
    // refrence to script deathCounter

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            SceneManager.LoadScene(Respawn);
            deaths += 1;
        }

    }


}