using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    private bool doublePoints;
    private bool safeMode;

    private bool powerupActive;
    private float powerupLengthCounter;

    private PlatformGenerator thePlatformGenerator;
    public CoinScript thecoinScript;
    private Player thekillPlayer;
    private float spikeRate;

    private PlatformDestroyer[] spikeList;



    // Start is called before the first frame update
    void Start()
    {
        thePlatformGenerator = FindObjectOfType<PlatformGenerator>();
        thekillPlayer = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (powerupActive)
        {
            powerupLengthCounter -= Time.deltaTime;

            if (thekillPlayer.powerupReset == true)
            {
                powerupLengthCounter = 0;

                thekillPlayer.powerupReset = false;
            }


            if (doublePoints)
            {
                thecoinScript.Double = true;
            }

            if (safeMode)
            {
                thePlatformGenerator.randomSpikeThreshold = 0f;
            }
            if (powerupLengthCounter <= 0)
            {

                thecoinScript.Double = false;
                thePlatformGenerator.randomSpikeThreshold = spikeRate;

                powerupActive = false;
            }
        }
    }

    public void ActivatePowerup(bool points, bool safe, float time)
    {
        doublePoints = points;
        safeMode = safe;
        powerupLengthCounter = time;


        spikeRate = thePlatformGenerator.randomSpikeThreshold;

        if (safeMode)
        {
            spikeList = FindObjectsOfType<PlatformDestroyer>();
            for (int i = 0; i < spikeList.Length; i++)
            {
                if (spikeList[i].gameObject.name.Contains("spike"))
                {
                    spikeList[i].gameObject.SetActive(false);
                }

            }
        }

        powerupActive = true;

    }

}
