using UnityEngine;

public class DummyTrigger : MonoBehaviour
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
                    dummy.ActivateDummy();
                }
            }
        }
    }
}