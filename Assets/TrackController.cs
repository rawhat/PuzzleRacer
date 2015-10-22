﻿using UnityEngine;
using System.Collections;

public class TrackController : MonoBehaviour {

    public GameObject initialTrackPiece;

    private GameObject currentTrackPiece;
    private GameObject nextTrackPiece;
    private TrackPieceStatus currentTrackPieceStatus;
    private TrackPieceStatus nextTrackPieceStatus;

    void Start()
    {
        currentTrackPiece = initialTrackPiece;
        currentTrackPieceStatus = currentTrackPiece.GetComponent<TrackPieceStatus>();
        Debug.Log("tag: " + currentTrackPiece.tag);
    }

    /*
    void ResetTrack()
    {
        Instantiate(currentTrackPiece);
    }*/

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

    void SetCurrentTrackPiece(GameObject trackPiece)
    {
        currentTrackPiece = trackPiece;
    }

    void SetNextTrackPiece(GameObject trackPiece)
    {
        nextTrackPiece = trackPiece;
        nextTrackPieceStatus = nextTrackPiece.GetComponent<TrackPieceStatus>();
    }

    void SpawnNextTrackPiece()
    {
        Vector3 pieceSpawnLocation = currentTrackPieceStatus.spawnLocation.position;
        pieceSpawnLocation.z += nextTrackPiece.transform.localScale.z / 2f;

        GameObject next = Instantiate(nextTrackPiece, pieceSpawnLocation, Quaternion.identity) as GameObject;
        currentTrackPieceStatus = next.GetComponent<TrackPieceStatus>();
        currentTrackPiece = next;
    }
}
