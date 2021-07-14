using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSplit : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject chipedAsteroidPrefab;
    private float chipAsteroidSpeed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject spawnedChipAsteroid = Instantiate(chipedAsteroidPrefab, new Vector3(transform.position.x,transform.position.y), Quaternion.identity);
        spawnedChipAsteroid.GetComponent<Rigidbody>().velocity = Vector3.down * chipAsteroidSpeed;
        Destroy(this.gameObject);
    }   
}
