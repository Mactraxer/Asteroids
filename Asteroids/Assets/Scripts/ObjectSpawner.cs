using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject asteroidPrefab;
    [SerializeField]
    GameObject enemySpaceShipPrefab;

    float timeToSpawnAsteroid = 2f;
    float timeToSpawnEnemySpaceShip = 5f;

    float asteroidSpeed = 5f;
    float enemyShipSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        TickAsteroidSpawnTimer();
        TickEnemyShipSpawnTimer();
    }

    private void TickAsteroidSpawnTimer()
    {
        timeToSpawnAsteroid -= Time.deltaTime;
        if (timeToSpawnAsteroid < 0)
        {
            SpawnAsteroid();
            timeToSpawnAsteroid = Random.Range(1,3);
        }
    }

    private void TickEnemyShipSpawnTimer()
    {
        timeToSpawnEnemySpaceShip -= Time.deltaTime;
        if (timeToSpawnEnemySpaceShip < 0)
        {
            SpawnEnemyShip();
            timeToSpawnEnemySpaceShip = Random.Range(1,5);
        }
    }

    private void SpawnAsteroid()
    {
        Vector3 randomVector = GetRandomTopVector();
        //Debug.Log(randomVector);
        GameObject spawnedAsteroid = Instantiate(asteroidPrefab, randomVector, Quaternion.identity);
        spawnedAsteroid.GetComponent<Rigidbody>().velocity = Vector3.down * asteroidSpeed;
    }

    private Vector3 GetRandomTopVector()
    {
        Vector3 screenVector = new Vector3(Random.Range(0, Screen.width), Screen.height, -Camera.main.transform.position.z);
        //Debug.Log($"screenVector {screenVector}");
        return Camera.main.ScreenToWorldPoint(screenVector);
    }

    private void SpawnEnemyShip()
    {
        Vector3 randomVector = GetRandomTopVector();
        GameObject spawnedEnemyShip = Instantiate(enemySpaceShipPrefab, randomVector, Quaternion.identity);
       // spawnedEnemyShip.GetComponent<Rigidbody>().velocity = Vector3.down * 1f;
    }
}
