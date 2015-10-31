using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    // make this a dictionary later with reference ID for falling track pieces
    public GameObject[] trackPieceArray;
    public GameObject player;
    public Text distanceText;
    private GameObject currentTrackPiece;

    private bool playerInputReceived;
    DisappearAfterTime disappearScript;

    private TrackController trackController;
    private GameObject killPlane;
    [SerializeField] private float totalDistanceTraveled;
    [SerializeField] private float startingPosition;
    private float checkpointIncrement;
    [SerializeField] private float nextCheckpoint;

    private Vector3 initialPosition;
    public GameObject initialTrackPiece;

    void Awake()
    {
        initialPosition = player.transform.position;
    }

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
            ResetGame();
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
        distanceText.text = ((int) totalDistanceTraveled).ToString() + " m";
    }

    void IncrementCheckpoint()
    {
        killPlane.GetComponent<KillPlaneBehave>().SetCheckpointPos(nextCheckpoint);
        nextCheckpoint += checkpointIncrement;
    }

    void ResetGame()
    {
        foreach (GameObject trackPiece in GameObject.FindGameObjectsWithTag("TrackPiece"))
        {
            Destroy(trackPiece);
        }
        playerInputReceived = false;
        totalDistanceTraveled = 0f;
        Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
        playerRigidbody.velocity = Vector3.zero;
        playerRigidbody.angularVelocity = Vector3.zero;
        player.transform.position = initialPosition;
        currentTrackPiece = Instantiate(initialTrackPiece) as GameObject;
        trackController.SetCurrentTrackPiece(currentTrackPiece);
        disappearScript = currentTrackPiece.GetComponent<DisappearAfterTime>();
        disappearScript.enabled = false;
    }
}