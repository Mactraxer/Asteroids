using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceShipShooting : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;
    private float bulletSpeed = 5f;
    private float shootingSpeed = 1f;
    private float shootingCooldown;
    // Start is called before the first frame update
    void Start()
    {
        shootingCooldown = shootingSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        ShootingCooldonwTick();    
    }

    void ShootingCooldonwTick()
    {
        shootingCooldown -= Time.deltaTime;
        if (shootingCooldown < 0)
        {
            Shoot();
            shootingCooldown = shootingSpeed;
        }
    }

    void Shoot()
    {
        Vector3 bulletStartPosition = new Vector3(transform.position.x, transform.position.y - transform.lossyScale.y, transform.position.z);
        GameObject bullet = Instantiate(bulletPrefab, bulletStartPosition, Quaternion.identity);
        bullet.tag = "Enemy";
        bullet.GetComponent<Rigidbody>().velocity = bulletSpeed * Vector3.down;
    }

}
