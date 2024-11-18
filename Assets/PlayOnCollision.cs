using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnCollision : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClipWood;
    [SerializeField] private AudioClip audioClipMetal;
    [SerializeField] private AudioClip audioClipWeapon;
    [SerializeField] private float volume;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wood"))
        {
            audioSource.PlayOneShot(audioClipWood, volume);
            return;
        }

        if (other.gameObject.CompareTag("Metal"))
        {
            audioSource.PlayOneShot(audioClipMetal, volume);
            return;
        }if (other.gameObject.CompareTag("Weapon"))
        {
            audioSource.PlayOneShot(audioClipWeapon, volume);
            return;
        }
    }
}