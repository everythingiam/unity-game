using UnityEngine;

public class DummyShoot : MonoBehaviour
{
    [SerializeField] private GameObject[] targets;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject target in targets)
            {
                TargetDummy dummy = target.GetComponent<TargetDummy>();
                if (dummy != null)
                {
                    dummy.EnableTracking(true);
                    dummy.StartShooting(); 
                }
            }

            GetComponent<BoxCollider>().enabled = false; 
        }
    }
}