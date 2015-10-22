using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    // make this a dictionary later with reference ID for falling track pieces
    public GameObject[] trackPieceArray;

    private GameObject currentTrackPiece;
    private TrackController trackController;

    void Start()
    {
        trackController = GameObject.FindObjectOfType<TrackController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            trackController.SendMessage("SetNextTrackPiece", trackPieceArray[0]);
        }
    }
}
