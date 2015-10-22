using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class FallingPieceController : MonoBehaviour {

    public float fallDelay;
    public float fallSpeed;

    public RawImage[] trackPieces;

    private float fallTimer;

    void Start()
    {
        fallTimer = fallDelay;
    }

    void Update()
    {
        fallTimer -= Time.deltaTime;

        if (fallTimer <= 0f)
        {

        }
    }

    void AddPiece()
    {

    }
}
