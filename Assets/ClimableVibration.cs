using UnityEngine;
using UnityEngine.XR;

public class Climbable : MonoBehaviour
{
    [SerializeField] private float vibrationStrength = 0.3f;
    [SerializeField] private float vibrationDuration = 0.1f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("LeftHand") || collision.gameObject.CompareTag("RightHand"))
        {
            TriggerHapticFeedback();
        }
    }

    private void TriggerHapticFeedback()
    {
        InputDevice leftHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        InputDevice rightHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        if (leftHandDevice.isValid)
        {
            leftHandDevice.SendHapticImpulse(0, vibrationStrength, vibrationDuration);
        }
        if (rightHandDevice.isValid)
        {
            rightHandDevice.SendHapticImpulse(0, vibrationStrength, vibrationDuration);
        }
    }
}