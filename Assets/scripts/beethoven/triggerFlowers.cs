using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerFlowers : MonoBehaviour
{
    [SerializeField]
    private GameObject croustiPute;

    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("panel").SetActive(true);
    }
}
