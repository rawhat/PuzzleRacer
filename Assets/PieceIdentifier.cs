using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PieceIdentifier : MonoBehaviour {

    public enum TrackSurface 
    {
        Normal,
        Comet,
        Ice,
    }

    public int pieceIdentifier;
    public Texture trackTexture;
    public TrackSurface pieceSurface;
    public string pieceColor;
}
