using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSplit : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject chipedAsteroidPrefab;
    private float chipAsteroidSpeed = 2f;
    [SerializeField]
    ScoreCalculator eventDelegate;

    private bool needSplitAsteroid = false;

    void Start()
    {
        eventDelegate = GameObject.Find("ScoreText").GetComponent<ScoreCalculator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (needSplitAsteroid)
        {
            SplitAsteroid();
            needSplitAsteroid = false;
        } 
    }

    private void SplitAsteroid()
    {
        eventDelegate.AddScore(250);

        GameObject spawnedChipAsteroid = Instantiate(chipedAsteroidPrefab, GetRandomOffsetVector(), Quaternion.identity);
        spawnedChipAsteroid.GetComponent<Rigidbody>().velocity = GetRandomDirectionVector() * chipAsteroidSpeed;
        Destroy(this.gameObject);
    }

    private Vector3 GetRandomOffsetVector()
    {
        float xOffset = Random.Range(transform.position.x - (transform.lossyScale.x / 2), transform.position.x);
        float yOffset = Random.Range(transform.position.y - (transform.lossyScale.y / 2), transform.position.y);
        Vector3 offset = new Vector3(xOffset, yOffset);
        return offset;
    }

    private Vector3 GetRandomDirectionVector()
    {
        int[] directions = new int[] { -1, 1 };
        float xDirection = directions[Random.Range(0, directions.Length)];
        Vector3 direction = new Vector3(xDirection, -1);
        return direction;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.tag == ObjectTag.Ally)
        {
            needSplitAsteroid = true;
        }
    }   
}
