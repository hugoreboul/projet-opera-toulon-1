using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{

    private ARRaycastManager rayManager;
    public GameObject objetToSpawn;

    //private bool isSpawn = false;
    private int nbSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        rayManager = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && /*!isSpawn*/ nbSpawn < 1)
        {
            PlaceObject(Input.touches[0].position);
            //PlaceObject(new Vector2(Screen.width / 2, Screen.height / 2));
        }
    }

    void PlaceObject(Vector2 touchScreen)
    {

        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        rayManager.Raycast(touchScreen, hits, TrackableType.Planes);

        if (hits.Count > 0)
        {
            Instantiate(objetToSpawn, hits[0].pose.position, hits[0].pose.rotation);
            nbSpawn++;
            //isSpawn = true;
        }
    }
}
