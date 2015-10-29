using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    // make this a dictionary later with reference ID for falling track pieces
    public GameObject[] trackPieceArray;
    public GameObject player;
    private GameObject currentTrackPiece;

    private bool playerInputReceived;
    DisappearAfterTime disappearScript;

    private TrackController trackController;
    private GameObject killPlane;
    [SerializeField] private float totalDistanceTraveled;
    [SerializeField] private float startingPosition;
    private float checkpointIncrement;
    [SerializeField] private float nextCheckpoint;

    void Start()
    {
        currentTrackPiece = GameObject.FindGameObjectWithTag("TrackPiece");
        disappearScript = currentTrackPiece.GetComponent<DisappearAfterTime>();
        disappearScript.enabled = false;
        playerInputReceived = false;
        totalDistanceTraveled = 0;
        startingPosition = player.transform.position.z;
        checkpointIncrement = 50f;
        nextCheckpoint =  player.transform.position.z + checkpointIncrement;
        trackController = GameObject.FindObjectOfType<TrackController>();
        killPlane = GameObject.Find("KillPlane");
    }

    void Update()
    {
        if (Input.anyKeyDown && !playerInputReceived)
        {
            disappearScript.enabled = true;
            playerInputReceived = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        IncrementDistanceTraveled();

        /*
        if (Input.GetKeyDown(KeyCode.Q))
        {
            trackController.SendMessage("SetNextTrackPiece", trackPieceArray[Random.Range(0, trackPieceArray.Length)]);
        }*/
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