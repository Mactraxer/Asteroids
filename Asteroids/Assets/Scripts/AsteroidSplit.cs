using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSplit : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject chipedAsteroidPrefab;
    private float chipAsteroidSpeed = 5f;
    [SerializeField]
    ScoreCalculator eventDelegate;

    void Start()
    {
        eventDelegate = GameObject.Find("ScoreText").GetComponent<ScoreCalculator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ally")
        {
            eventDelegate.AddScore(250);
        }
        GameObject spawnedChipAsteroid = Instantiate(chipedAsteroidPrefab, new Vector3(transform.position.x,transform.position.y), Quaternion.identity);
        spawnedChipAsteroid.GetComponent<Rigidbody>().velocity = Vector3.down * chipAsteroidSpeed;
        Destroy(this.gameObject);
    }   
}
