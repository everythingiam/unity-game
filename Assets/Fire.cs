using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Fire : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float bulletSpeed = 12f;

    [Header("Audio Settings")]
    [SerializeField] private AudioClip fireSound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float volume = 1f;

    [Header("Haptic Feedback")]
    [SerializeField, Range(0f, 1f)] private float hapticIntensity = 0.5f;
    [SerializeField, Range(0f, 1f)] private float hapticDuration = 0.1f;

    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    public void FireBullet()
    {
        GameObject newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * bulletSpeed;
        Destroy(newBullet, 5f);

        audioSource.PlayOneShot(fireSound, volume);

        TriggerHapticFeedback();
    }

    private void TriggerHapticFeedback()
    {
        IXRSelectInteractor interactor = grabInteractable.firstInteractorSelecting;

        if (interactor is XRDirectInteractor directInteractor)
        {
            ActionBasedController controller = directInteractor.GetComponent<ActionBasedController>();
            if (controller != null)
            {
                controller.SendHapticImpulse(hapticIntensity, hapticDuration);
            }
        }
    }
}