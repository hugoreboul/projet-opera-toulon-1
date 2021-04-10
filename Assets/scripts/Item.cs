using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    public Vector3[] position;
    [SerializeField]
    new public bool enabled = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Enable(bool ena)
    {
        gameObject.SetActive(ena);
        enabled = ena;
    }
}
