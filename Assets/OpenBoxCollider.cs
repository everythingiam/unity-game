using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBoxCollider : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject canvas;

    public void Open()
    {
        platform.GetComponent<BoxCollider>().enabled = false;
        canvas.SetActive(false);
    }

}
