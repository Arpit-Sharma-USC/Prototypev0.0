using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : DestroyScript {


    public Transform[] SpawnPoints;
    private float spawnTime=20.0f;

    public GameObject[] Coins;

	// Use this for initialization
	void Start () {
        if (!(gameParametersContainer.gameParam == null))
            spawnTime = float.Parse(gameParametersContainer.gameParam.respawnTime);

        InvokeRepeating("SpawnCoins",spawnTime,spawnTime);
        Debug.Log(spawnTime+"spawn");
	}
	
	// Update is called once per frame
	void Update () {
        //InvokeRepeating("SpawnCoins", spawnTime, spawnTime);
    }

    void SpawnCoins(){
        
        int spawnIndex = Random.Range(0,SpawnPoints.Length);

        int objectIndex = Random.Range(0,Coins.Length);
        if(flag == false)
        {
            Instantiate(Coins[objectIndex], SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation);
        }
    }
}
