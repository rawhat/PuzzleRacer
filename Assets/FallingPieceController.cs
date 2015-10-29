using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class FallingPieceController : MonoBehaviour {

    public float fallDelay;
    public float timeToCrossScreen;

    public float spawnToDestroyDistance;

    public GameObject newPieceTemplate;
    public Transform spawnLocation;
    public GameObject parentPanel;

    public Texture[] trackPieces;

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
            AddPiece();
            fallTimer = fallDelay;
        }
    }

    void AddPiece()
    {
        GameObject newPiece = Instantiate(newPieceTemplate) as GameObject;
        PieceIdentifier id = newPiece.GetComponent<PieceIdentifier>();
        id.pieceIdentifier = 0;
        newPiece.transform.SetParent(parentPanel.transform, false);
        RawImage pieceRawImage = newPiece.GetComponent<RawImage>();
        pieceRawImage.texture = trackPieces[0];
        pieceRawImage.DOFade(0f, 0f).OnComplete(()=>pieceRawImage.DOFade(1f, .25f));

        RectTransform pieceRectTransform = newPiece.GetComponent<RectTransform>();
        pieceRectTransform.anchoredPosition = new Vector2(-300f, 0f);
        pieceRectTransform.sizeDelta = new Vector2(40f, 80f);
        pieceRectTransform.DOAnchorPosX(spawnToDestroyDistance, timeToCrossScreen).OnComplete(()=>Destroy(newPiece));

    }
}
