using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDummy : MonoBehaviour
{
    [SerializeField] private Animator dummyAnimator;
    [SerializeField] private MeshCollider meshCollider; 
    private int hitCount = 0;
    private static int MAX_HIT_COUNT = 2;

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
    }

    public void ActivateDummy()
    {
        dummyAnimator.SetTrigger("Activate");
    }
}