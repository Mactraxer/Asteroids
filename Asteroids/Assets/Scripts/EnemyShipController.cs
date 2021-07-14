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

    private float shipSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        shipRigidbody.velocity = shipSpeed * Vector3.down;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (transform.position.x != playerTransform.position.x)
        {
            Debug.Log(playerTransform.position);
            //shipTransform.Translate(playerTransform.position * 2f * Time.deltaTime);
            shipRigidbody.velocity = shipSpeed * (playerTransform.position - shipTransform.position);
        }
    }
}
