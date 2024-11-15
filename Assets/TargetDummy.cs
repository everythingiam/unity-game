using System.Collections;
using UnityEngine;

public class TargetDummy : MonoBehaviour
{
    [SerializeField] private Animator dummyAnimator;
    private int hitCount = 0;
    private static int MAX_HIT_COUNT = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Arrow"))
        {
            dummyAnimator.SetTrigger("Death");
            GetComponent<BoxCollider>().enabled = false;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            hitCount++;

            if (hitCount < MAX_HIT_COUNT)
            {
                dummyAnimator.SetTrigger("Hit");
            }
            else
            {
                dummyAnimator.SetTrigger("Death");
                GetComponent<BoxCollider>().enabled = false;
            }
        }

        if (collision.gameObject.CompareTag("Arrow"))
        {
            dummyAnimator.SetTrigger("Death");
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void ActivateDummy()
    {
        dummyAnimator.SetTrigger("Activate");
    }
}