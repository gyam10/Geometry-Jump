using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public ObjectPooler coinPool;

    public float distanceBetweenCoins;

    public void SpawnCoins(Vector3 StartPosition)
    {
        GameObject coin1 = coinPool.GetPooledObject();
        coin1.transform.position = StartPosition;
        coin1.SetActive(true);

        GameObject coin2 = coinPool.GetPooledObject();
        coin2.transform.position = new Vector3(StartPosition.x - distanceBetweenCoins,StartPosition.y,StartPosition.z);
        coin2.SetActive(true);

        GameObject coin3 = coinPool.GetPooledObject();
        coin3.transform.position = new Vector3(StartPosition.x + distanceBetweenCoins, StartPosition.y, StartPosition.z);
        coin3.SetActive(true);

    }
}
