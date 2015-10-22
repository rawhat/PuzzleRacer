using UnityEngine;
using System.Collections;

public class TrackController : MonoBehaviour {

    public GameObject initialTrackPiece;

    private GameObject currentTrackPiece;
    private GameObject nextTrackPiece;
    private TrackPieceStatus currentTrackPieceStatus;

    void Start()
    {
        currentTrackPiece = initialTrackPiece;
        currentTrackPieceStatus = currentTrackPiece.GetComponent<TrackPieceStatus>();
    }

    void Update()
    {
        /*
        if (currentTrackPieceStatus.isFalling)
        {
            SpawnNextTrackPiece();
        }*/

        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnNextTrackPiece();
        }
    }

    public void SetCurrentTrackPiece(GameObject trackPiece)
    {
        currentTrackPiece = trackPiece;
        currentTrackPieceStatus = currentTrackPiece.GetComponent<TrackPieceStatus>();
    }

    void SetNextTrackPiece(GameObject trackPiece)
    {
        nextTrackPiece = trackPiece;
    }

    void SpawnNextTrackPiece()
    {
        Vector3 pieceSpawnLocation = currentTrackPieceStatus.spawnLocation.position;
        pieceSpawnLocation.z += nextTrackPiece.transform.localScale.z / 2f;

        GameObject next = Instantiate(nextTrackPiece, pieceSpawnLocation, Quaternion.identity) as GameObject;
        currentTrackPieceStatus = next.GetComponent<TrackPieceStatus>();
        currentTrackPiece = next;
    }

    public Vector3 GetTrackPieceSpawn()
    {
        return currentTrackPieceStatus.spawnLocation.position;
    }
}
