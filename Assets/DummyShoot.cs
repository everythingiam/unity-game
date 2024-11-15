using System.Collections;
using UnityEngine;

public class DummyShoot : MonoBehaviour
{
    [SerializeField] private GameObject[] targets; 
    [SerializeField] private GameObject bullet; 
    [SerializeField] private float bulletSpeed = 10f; 
    [SerializeField] private int bulletCount = 10; 
    [SerializeField] private float bulletInterval = 0.1f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject target in targets)
            {
                Transform spawnPoint = target.GetComponent<TargetDummy>().spawnPoint;
                StartCoroutine(ShootBullets(spawnPoint));
            }
        }
    }

    private IEnumerator ShootBullets(Transform spawnPoint)
    {
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject spawnedBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
            spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * bulletSpeed;
            yield return new WaitForSeconds(bulletInterval);
        }
    }
}