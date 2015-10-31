using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class GeneratePieceGrid : MonoBehaviour {

    public GameObject pieceVector1;
    public GameObject pieceVector2;
    public GameObject pieceVector3;
    public GameObject pieceVector4;
    public GameObject pieceVector5;
    public GameObject pieceVector6;

    public Texture[] VectorImageArray;

    public float pieceFadeTimer;

    public void GenerateGrid()
    {
        foreach (GameObject puzzlePiece in GameObject.FindGameObjectsWithTag("PuzzlePiece"))
        {
            puzzlePiece.GetComponent<RawImage>().DOFade(0f, pieceFadeTimer).OnComplete(() => Destroy(puzzlePiece));
        }

        for (int i = 0; i < 6; i++)
        {

        }
    }
}
