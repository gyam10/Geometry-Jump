using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyPlatformGenerator : MonoBehaviour
{
    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;
    public float distanceBetweenMin;
    public float distanceBetweenMax;

    //public GameObject[] thePlatforms;
    private int platformSelector;
    private float[] platformWidths;
    public ObjectPooler[] theObjectPools;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    //for generating coin
    private CoinGenerator theCoinGenerator;
    public float randomCoinThreshold;

    //generating spikes random
    public float randomSpikeThreshold;
    public ObjectPooler[] spikePools;
    public int spikeSelector;

    public float powerupHeight;
    public ObjectPooler powerupPool;
    public float powerupThreshold;



    // Start is called before the first frame update
    void Start()
    {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        platformWidths = new float[theObjectPools.Length];

        for (int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        theCoinGenerator = FindObjectOfType<CoinGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            platformSelector = Random.Range(0, theObjectPools.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);
            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            //random poweruP
            if (Random.Range(0f, 100f) < powerupThreshold)
            {
                GameObject newPowerup = powerupPool.GetPooledObject();

                newPowerup.transform.position = transform.position + new Vector3(distanceBetween / 2f, Random.Range(powerupHeight / 200f, powerupHeight), 0f);
                newPowerup.SetActive(true);
            }


            //spikes selector
            spikeSelector = Random.Range(0, spikePools.Length);
            

            transform.position = new Vector3(transform.position.x + platformWidths[platformSelector] / 2 + distanceBetween, heightChange, transform.position.z);



            // Instantiate(/*thePlatform*/ thePlatforms[platformSelector], transform.position, transform.rotation);

            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
            // gets coins spawned 
            if (Random.Range(0f, 100f) < randomCoinThreshold)
            {
                if (heightChange < maxHeight / 2)
                {
                    theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 800f, transform.position.z));
                }
                else if(heightChange > maxHeight / 2)
                {
                    theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y - 800f, transform.position.z));
                }
            }

            //gets spikes spawned
            if (Random.Range(0f, 100f) < randomSpikeThreshold)
            {
                    GameObject newSpike = spikePools[spikeSelector].GetPooledObject();

                    float spikeXPosition = Random.Range(-platformWidths[platformSelector] / 200f + 100f, platformWidths[platformSelector] / 200f + 100f);


                    Vector3 spikePosition = new Vector3(spikeXPosition, 500f, 0f);
                    newSpike.transform.position = transform.position + spikePosition;
                    newSpike.transform.rotation = transform.rotation;
                    newSpike.SetActive(true);
              

            }

            transform.position = new Vector3(transform.position.x + platformWidths[platformSelector] / 2, transform.position.y, transform.position.z);
        }
    }
}
