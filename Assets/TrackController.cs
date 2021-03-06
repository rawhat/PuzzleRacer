﻿using UnityEngine;
using System.Collections;

public class TrackController : MonoBehaviour {

    public GameObject initialTrackPiece;

    private GameObject currentTrackPiece;
    private GameObject nextTrackPiece;
    private TrackPieceStatus currentTrackPieceStatus;
    private GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        currentTrackPiece = initialTrackPiece;
        currentTrackPieceStatus = currentTrackPiece.GetComponent<TrackPieceStatus>();
    }

    void Update()
    {
        /*
        if (currentTrackPieceStatus.isFalling)
        {
            SpawnNextTrackPiece();
        }
        */

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetNextTrackPiece(currentTrackPiece);
        }

        // for testing purposes
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

    public void SetNextTrackPiece(GameObject trackPiece)
    {
        nextTrackPiece = trackPiece;
    }

    public void SetNextTrackPieceById(int id)
    {
        //SetNextTrackPiece(gameController.trackPieceArray[id]);

        // making random for testing
        SetNextTrackPiece(gameController.trackPieceArray[Random.Range(0, gameController.trackPieceArray.Length)]);
    }

    public void SpawnNextTrackPiece()
    {
        Vector3 pieceSpawnLocation = currentTrackPieceStatus.spawnLocation.position;
        Vector3 placementLocation = nextTrackPiece.GetComponent<TrackPieceStatus>().placementLocation.position;

        Vector3 meshSize = nextTrackPiece.GetComponent<Renderer>().bounds.size;
        pieceSpawnLocation.z += meshSize.z / 2f;

        pieceSpawnLocation.y -= (placementLocation.y - nextTrackPiece.transform.position.y);

        GameObject next = Instantiate(nextTrackPiece, pieceSpawnLocation, currentTrackPieceStatus.spawnLocation.rotation) as GameObject;
        SetCurrentTrackPiece(next);

        //currentTrackPieceStatus = next.GetComponent<TrackPieceStatus>();
        //currentTrackPiece = next;
    }

    public Vector3 GetTrackPieceSpawn()
    {
        return currentTrackPieceStatus.spawnLocation.position;
    }
}
