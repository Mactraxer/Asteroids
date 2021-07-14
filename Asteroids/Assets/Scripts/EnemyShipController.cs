using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;
    [SerializeField]
    Rigidbody shipRigidbody;
    [SerializeField]
    Transform shipTransform;
    [SerializeField]
    ScoreCalculator eventDelegate;

    private float shipSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        shipRigidbody.velocity = shipSpeed * Vector3.down;
        eventDelegate = GameObject.Find("ScoreText").GetComponent<ScoreCalculator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (transform.position.x != playerTransform.position.x && transform.position.y >= playerTransform.position.y)
        {
            Vector3 direction = playerTransform.position - transform.position;
            shipRigidbody.AddForce(direction.normalized);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ally")
        {
            eventDelegate.AddScore(500);
        }

        Destroy(gameObject);
    }
}
