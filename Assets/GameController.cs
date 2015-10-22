using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    // make this a dictionary later with reference ID for falling track pieces
    public GameObject[] trackPieceArray;
    public GameObject player;
    private GameObject currentTrackPiece;
    private TrackController trackController;
    private GameObject killPlane;
    [SerializeField] private float totalDistanceTraveled;
    [SerializeField] private float startingPosition;
    private float checkpointIncrement;
    [SerializeField] private float nextCheckpoint;

    void Start()
    {
        totalDistanceTraveled = 0;
        startingPosition = player.transform.position.z;
        checkpointIncrement = 50f;
        nextCheckpoint =  player.transform.position.z + checkpointIncrement;
        trackController = GameObject.FindObjectOfType<TrackController>();
        killPlane = GameObject.Find("KillPlane");
    }

    void Update()
    {
        IncrementDistanceTraveled();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            trackController.SendMessage("SetNextTrackPiece", trackPieceArray[0]);
        }
    }

    void IncrementDistanceTraveled()
    {
        totalDistanceTraveled = player.transform.position.z - startingPosition;
        if(totalDistanceTraveled >= nextCheckpoint)
            IncrementCheckpoint();
    }

    void IncrementCheckpoint()
    {
        killPlane.GetComponent<KillPlaneBehave>().SetCheckpointPos(nextCheckpoint);
        nextCheckpoint += checkpointIncrement;
    }
}