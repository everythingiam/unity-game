using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FixedXRGrabInteractable : XRGrabInteractable
{
    [SerializeField] private Transform leftHandAttachTransform;
    [SerializeField] private Transform rightHandAttachTransform;

    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("LeftHand"))
        {
            attachTransform = leftHandAttachTransform;
        }
        else if (args.interactorObject.transform.CompareTag("RightHand"))
        {
            attachTransform = rightHandAttachTransform;
        }

        base.OnSelectEntering(args);
    }
}
