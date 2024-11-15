using System.Collections;
using UnityEngine;

public class TargetDummy : MonoBehaviour
{
    [SerializeField] private Animator dummyAnimator;
    [SerializeField] private int swordHitCount = 2;
    [SerializeField] private int arrowHitCount = 1;
    [SerializeField] public Transform spawnPoint;
    
    private int hitCount = 0;

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
                dummyAnimator.SetTrigger("Death");
                GetComponent<BoxCollider>().enabled = false;
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
                dummyAnimator.SetTrigger("Death");
                GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    public void ActivateDummy()
    {
        dummyAnimator.SetTrigger("Activate");
    }
}