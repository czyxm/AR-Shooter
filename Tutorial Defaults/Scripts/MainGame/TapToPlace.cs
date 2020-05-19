using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class TapToPlace : MonoBehaviour
{
    public GameObject objectToPlaced;
    private ARRaycastManager aRRaycastManager;
    private GameObject placedObject;
    // Start is called before the first frame update
    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        List<ARRaycastHit> hitResults = new List<ARRaycastHit>();
        if (Input.touchCount > 0)
        {
            if(aRRaycastManager.Raycast(Input.GetTouch(0).position, hitResults, TrackableType.PlaneWithinPolygon) && hitResults.Count > 0)
            {
                placedObject = Instantiate(objectToPlaced, hitResults[0].pose.position, hitResults[0].pose.rotation);
                placedObject.transform.Rotate(new Vector3(-90.0f, 0.0f, 0.0f));
                ARPlaneManager aRPlaneManager = FindObjectOfType<ARPlaneManager>();
                aRPlaneManager.enabled = false;
                foreach (var plane in aRPlaneManager.trackables)
                {
                    plane.gameObject.SetActive(false);
                }
                this.enabled = false;
                GetComponent<TapToShoot>().enabled = true;
            }
        }
    }
}
