using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PieceInputController : MonoBehaviour {

    public Transform lockedPosition;
    public float lockPieceSensitivity;
    public float lockSpeed;

    private bool pieceLocked;
    private bool followMouse;
   // private Vector3 lockLocation;
    private GameObject lockedPiece;
    private Vector3 screenPoint;
    private Vector3 offset;

    void Start()
    {
        pieceLocked = false;
        //lockLocation = lockedPosition.position;

        // adjusting for width of reticule
        //lockLocation.x -= 40f * .0025f;
    }

    public void LockPuzzlePiece()
    {
        if (!pieceLocked)
        {
            GameObject[] puzzlePieces = GameObject.FindGameObjectsWithTag("PuzzlePiece");

            GameObject pieceToLock = null;

            foreach (GameObject piece in puzzlePieces)
            {
                float dist = (Vector3.Distance(piece.transform.position, lockedPosition.position));
                if (dist < lockPieceSensitivity)
                {
                    pieceToLock = piece;
                    break;
                }
            }

            if (pieceToLock != null)
            {
                pieceToLock.transform.DOKill();
                pieceToLock.transform.DOMoveX(lockedPosition.position.x - 40f * .0025f, 1f * lockSpeed);
                pieceLocked = true;
                lockedPiece = pieceToLock;
            }
        }
        else
        {
            followMouse = true;
        }
    }

    public void BeginDrag()
    {
        screenPoint = Camera.main.WorldToScreenPoint(lockedPiece.transform.position);

        offset = lockedPiece.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    public void DragPiece()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        lockedPiece.transform.position = curPosition;
    }

    public void EndDrag()
    {
        lockedPiece.transform.DOMove(new Vector3(lockedPosition.position.x - 40f * .0025f, lockedPosition.position.y, lockedPosition.position.z), .25f);
    }
}
