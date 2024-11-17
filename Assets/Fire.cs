using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private GameObject bullet;    
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float bulletSpeed = 12f;

    public void FireBullet()
    {
        GameObject newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * bulletSpeed;
        Destroy(newBullet, 5f);
    }
}
