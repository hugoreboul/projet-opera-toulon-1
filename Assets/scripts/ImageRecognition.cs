using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal.XR;
using UnityEngine.XR.ARFoundation;
using System;
using UnityEngine.UI;

public class ImageRecognition : MonoBehaviour
{
    private ARTrackedImageManager arTrackedImageManager;

    [SerializeField]
    private GameObject[] objectsToInstantied;

    [SerializeField]
    private Vector3[] ObjectPositions;

    private List<GameObject> arObjects = new List<GameObject>();

    public Text imgpos;

    private void Awake()
    {
        // Returns the first active loaded object of Type type.
        // it will found the Object AR Session Origine in the scene
        arTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();

        // instantiate all objects and keep the instance in an array
        foreach(GameObject arObject in objectsToInstantied)
        {
            GameObject newARObject = Instantiate(arObject, Vector3.zero, Quaternion.identity);
            newARObject.name = arObject.name;
            newARObject.SetActive(false);
            arObjects.Add(newARObject);
        }
    }

    // called when the object linked with this script is enable
    public void OnEnable()
    {
        arTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    // called when the object linked with this script is desable
    private void OnDisable()
    {
        arTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    // called when we track an image target
    public void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        // tracked Image is the image which is trigerred
        foreach (var trackedImage in args.added)
        {
            Debug.Log(trackedImage.name);
            UpdateARImage(trackedImage);
        }
        
        // when we retracked the image or when the tracked image change
        foreach (var trackedImage in args.updated)
        {
            UpdateARImage(trackedImage);
        }

        // do something when we lost the traked image ??
        foreach (var trackedImage in args.removed)
        {
         /*   foreach (GameObject arObject in arObjects)
            {
                arObject.SetActive(false);
            }
         */
        }
    }

    // display the objects in the scene and set their position according to the tracked image's position
    private void UpdateARImage(ARTrackedImage trackedImage)
    {
        imgpos.text = trackedImage.transform.position.ToString();
        for(int i=0; i< arObjects.Count; i++ )
        {
            arObjects[i].SetActive(true);
            arObjects[i].transform.position = trackedImage.transform.position;
            arObjects[i].transform.Translate(ObjectPositions[i]);
        }
    }
}
