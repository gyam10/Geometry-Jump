using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyPowerupManager : MonoBehaviour
{
    private bool doublePoints;
    private bool safeMode;

    private bool powerupActive;
    private float powerupLengthCounter;

    private flyPlatformGenerator theflyPlatformGenerator;
    public CoinScript thecoinScript;
    private Player thekillPlayer;
    private float spikeRate;

    private PlatformDestroyer[] spikeList;



    // Start is called before the first frame update
    void Start()
    {
        theflyPlatformGenerator = FindObjectOfType<flyPlatformGenerator>();
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
                theflyPlatformGenerator.randomSpikeThreshold = 0f;
            }
            if (powerupLengthCounter <= 0)
            {

                thecoinScript.Double = false;
                theflyPlatformGenerator.randomSpikeThreshold = spikeRate;

                powerupActive = false;
            }
        }
    }

    public void ActivatePowerup(bool points, bool safe, float time)
    {
        doublePoints = points;
        safeMode = safe;
        powerupLengthCounter = time;


        spikeRate = theflyPlatformGenerator.randomSpikeThreshold;

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
