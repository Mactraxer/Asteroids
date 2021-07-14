using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidChipController : MonoBehaviour
{
    [SerializeField]
    ScoreCalculator eventDelegate;
    // Start is called before the first frame update
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
            eventDelegate.AddScore(50);
        }

        Destroy(gameObject);
    }
}
