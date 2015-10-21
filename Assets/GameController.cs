using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject trackPiece;

    private GameObject currentTrackPiece;
    private TrackController trackController;

    void Start()
    {
        trackController = GameObject.FindObjectOfType<TrackController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            trackController.SendMessage("SetNextTrackPiece", trackPiece);
        }
    }
}
