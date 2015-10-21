using UnityEngine;
using System.Collections;

public class ResetOnFall : MonoBehaviour {

    private Rigidbody carRigidbody;
    private Quaternion initialRotation;
    private Vector3 initialPosition;
    private GameObject currentTrackPiece;
    private TrackController trackController;

    void Start()
    {
        carRigidbody = GetComponent<Rigidbody>();
        initialRotation = carRigidbody.transform.rotation;
        trackController = GameObject.FindObjectOfType<TrackController>();
    }

    /*
    void OnCollisionStay(Collision carCollision)
    {
        if (carCollision.gameObject.CompareTag("TrackPiece"))
        {
            initialPosition = carCollision.gameObject.GetComponentInChildren<Transform>().position;
            currentTrackPiece = carCollision.gameObject;
            trackController.SendMessage("SetCurrentTrackPiece", currentTrackPiece);
        }
    }*/

    /*
    void OnTriggerEnter(Collider boundaryBox)
    {
        trackController.SendMessage("ResetTrack");
        transform.position = initialPosition;
    }*/
}
