using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class floorPosition : MonoBehaviour
{

    private ARRaycastManager rayManager;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    // Start is called before the first frame update
    void Start()
    {
        rayManager = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.down);

        RaycastHit hitObject;

        if (Physics.Raycast(transform.position, fwd, out hitObject, 50))
        {
            transform.position = new Vector3(transform.position.x, hitObject.transform.position.y, transform.position.z);
        }
    }
}
