using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageTracked : MonoBehaviour
{
    private ARTrackedImageManager arTrackedImageManager;

    [System.Serializable]
    public struct objStruct
    {
        public GameObject obj;
        public Vector3 position;
    }

    public objStruct[] objectsToInstantied;

    private Vector3 tableauPos;

    private List<GameObject> arObjects = new List<GameObject>();

    private bool tableauFind;

    void Awake()
    {
        arTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        tableauFind = false;

        foreach (objStruct arObject in objectsToInstantied)
        {
            GameObject newARObject = Instantiate(arObject.obj, Vector3.zero, Quaternion.identity);
          
            newARObject.SetActive(false);
            arObjects.Add(newARObject);
        }
    }

    public void OnEnable()
    {
        arTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnDisable()
    {
        arTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    public void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        // tracked Image is the image which is trigerred
        foreach (var trackedImage in args.added)
        {
            tableauPos = trackedImage.transform.position;
            if (!tableauFind)
            {
                tableauFind = true;
                foreach (GameObject arObject in arObjects)
                {
                    UpdatePosition();
                    arObject.SetActive(true);
                }                
            }
        }

        // when we retracked the image or when the tracked image change
        foreach (var trackedImage in args.updated)
        {
            tableauPos = trackedImage.transform.position;
        }
    }

    public void UpdatePosition()
    {
        if (tableauFind)
        {
            for (int i = 0; i < arObjects.Count; i++)
            {
                arObjects[i].transform.position = tableauPos;
                arObjects[i].transform.Translate(objectsToInstantied[i].position);
            }
        }
    }

    void Update()
    {
        UpdatePosition();
    }
}
