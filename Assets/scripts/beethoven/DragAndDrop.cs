using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class DragAndDrop : MonoBehaviour
{
    private ARRaycastManager rayManager;

    private Camera arCamera;

    private bool isGrabbed = false;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Start()
    {
        arCamera = FindObjectOfType<Camera>();
        rayManager = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 touchPosition = Input.touches[0].position;
        if (Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(Input.touches[0].position);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
                    if (hitObject.transform == this.transform) {
                        isGrabbed = true;
                    }
                }
            }

            if (Input.touches[0].phase == TouchPhase.Ended)
            {
                isGrabbed = false;
            }
        }

        if (this.isGrabbed && (rayManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon)))
        {
            this.transform.position = hits[0].pose.position;
        }
    }
}
