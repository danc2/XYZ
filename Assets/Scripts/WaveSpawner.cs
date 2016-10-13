using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour {

    // setup prefab for enemy
    public Transform enemyPrefab;

    // setup place to spawn the wave
    public Transform spawnPoint;

    // set time between waves.
    // change this to suit level difficulty
    public float timeBetweenWaves = 20f;

    // time to spawn the first wave
    // increase this time after playtesting to give the player time to set turrets up
    private float countDown = 1f;

    // this sets how many of each enemy to spawn for the first wave - we will increase this for each wave.
    private int numberOfEnemies = 1;
    // set starting waveNumber as 1
    private int waveNumber = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        // once countDown reaches 0, then we spawn next wave
	    if (countDown <= 0f)
        {
            // call the SpawnWave Coroutine
            // this is an amazing feature - need to read more on this
            StartCoroutine(SpawnWave());
            // increase wave number and set the number of enemies for the next wave
            // we may need to tweak the formula below to change the difficulty
            waveNumber = waveNumber + 1;
            //numberOfEnemies = waveNumber * waveNumber;
            numberOfEnemies = waveNumber;
            // reset timer to be timeBeteenWaves
            countDown = timeBetweenWaves;
        }
        // every second reduce the countDown timer by 1
        countDown -= Time.deltaTime;
	}

    IEnumerator SpawnWave ()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            Debug.Log("Spawn!");
            yield return new WaitForSeconds(10.0f);
        }
        
    }

    void SpawnEnemy ()
    {
        // instantiate the enemy
        // need to expand this for the different types - or do we just create a spawn point for each enemy?
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
