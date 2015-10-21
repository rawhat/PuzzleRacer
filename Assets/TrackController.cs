using UnityEngine;
using System.Collections;

public class TrackController : MonoBehaviour {

    public GameObject initialTrackPiece;

    private GameObject currentTrackPiece;
    private GameObject nextTrackPiece;

    void Start()
    {
        currentTrackPiece = initialTrackPiece;
    }

    /*
    void ResetTrack()
    {
        Instantiate(currentTrackPiece);
    }*/

    void Update()
    {
        if (currentTrackPiece.transform.position.y < 0f)
        {
            SpawnNextTrackPiece();
        }
    }

    void SetCurrentTrackPiece(GameObject trackPiece)
    {
        currentTrackPiece = trackPiece;
    }

    void SetNextTrackPiece(GameObject trackPiece)
    {
        Debug.Log("setting next track piece");
        nextTrackPiece = trackPiece;
    }

    void SpawnNextTrackPiece()
    {
        Instantiate(nextTrackPiece);
    }
}
