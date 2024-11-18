using System.Collections;
using UnityEngine;

public class TargetDummy : MonoBehaviour
{
    [SerializeField] private Animator dummyAnimator;
    [SerializeField] private int swordHitCount = 2;
    [SerializeField] private int arrowHitCount = 1;
    [SerializeField] public Transform spawnPoint;
    [SerializeField] private Transform player;

    [Header("Shooting Settings")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private float baseBulletSpeed = 10f;
    [SerializeField] private int bulletCount = 10;
    [SerializeField] private float bulletInterval = 0.1f;

    private int hitCount = 0;
    private bool isTrackingPlayer = false;
    private bool isAlive = true;

    private void Update()
    {
        if (isTrackingPlayer)
        {
            LookAtPlayer();
        }
    }

    private void LookAtPlayer()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }

    public void ActivateDummy()
    {
        dummyAnimator.SetTrigger("Activate");
    }

    public void EnableTracking(bool enable)
    {
        isTrackingPlayer = enable;
    }

    public void StartShooting()
    {
        if (isAlive)
        {
            StartCoroutine(ShootBullets());
        }
    }

    private IEnumerator ShootBullets()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            if (!isAlive)
            {
                yield break;
            }

            if (player != null)
            {
                float distanceToPlayer = Vector3.Distance(transform.position, player.position);
                float adjustedBulletSpeed = baseBulletSpeed + distanceToPlayer * 0.5f;

                GameObject spawnedBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
                Rigidbody bulletRb = spawnedBullet.GetComponent<Rigidbody>();
                bulletRb.velocity = spawnPoint.forward * adjustedBulletSpeed;

                Destroy(spawnedBullet, 5f);
                yield return new WaitForSeconds(bulletInterval);
            }
        }
    }

    private void OnDeath()
    {
        isAlive = false; 
        dummyAnimator.SetTrigger("Death");
        EnableTracking(false);
        GetComponent<BoxCollider>().enabled = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            hitCount++;

            if (hitCount < arrowHitCount)
            {
                dummyAnimator.SetTrigger("Hit");
            }
            else
            {
                OnDeath();
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            hitCount++;

            if (hitCount < swordHitCount)
            {
                dummyAnimator.SetTrigger("Hit");
            }
            else
            {
                OnDeath();
            }
        }
    }
}
