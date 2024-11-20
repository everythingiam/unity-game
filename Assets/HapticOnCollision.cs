using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticOnCollision : MonoBehaviour
{
    [Header("Haptic Settings")]
    [Range(0f, 1f)] public float intensity = 0.2f; // Интенсивность вибрации
    [Range(0f, 1f)] public float duration = 0.1f; // Длительность вибрации

    private ActionBasedController activeController; // Текущий контроллер, взаимодействующий с мечом

    private void OnCollisionEnter(Collision collision)
    {
        TriggerHapticFeedback(activeController);
    }

    public void SetActiveController(SelectEnterEventArgs args)
    {
        activeController = args.interactorObject.transform.GetComponent<ActionBasedController>();
    }

    public void ClearActiveController()
    {
        activeController = null;
    }

    private void TriggerHapticFeedback(ActionBasedController controller)
    {
        if (controller != null)
        {
            controller.SendHapticImpulse(intensity, duration);
        }
    }
}