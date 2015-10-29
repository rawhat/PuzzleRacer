﻿using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class PuzzleController : MonoBehaviour {
	private GameObject container1;
	private GameObject container2;
	private GameObject container3;
	public GameObject pieceTemplate;
	private FallingPieceController pController;


	// Use this for initialization
	void Start () {
		container1 = transform.GetChild (0).gameObject;
		container2 = transform.GetChild (1).gameObject;
		container3 = transform.GetChild (2).gameObject;
		pController = GameObject.Find("FallingPiecePanel").GetComponent<FallingPieceController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddPuzzlePiece()
	{
		if(container1.transform.childCount < 1)
		{
			GameObject newPiece = (GameObject)Instantiate(pieceTemplate);
			PieceIdentifier id = newPiece.GetComponent<PieceIdentifier>();
        	id.pieceIdentifier = 0;
        	newPiece.transform.SetParent(container1.transform, false);
        	RawImage pieceRawImage = newPiece.GetComponent<RawImage>();
        	pieceRawImage.texture = pController.trackPieces[0];
        	//pieceRawImage.DOFade(0f, 0f).OnComplete(()=>pieceRawImage.DOFade(1f, .25f));

        	RectTransform pieceRectTransform = newPiece.GetComponent<RectTransform>();
        	pieceRectTransform.anchoredPosition = new Vector2(-300f, 0f);
        	pieceRectTransform.sizeDelta = new Vector2(40f, 80f);
			//GameObject pieceOne = puzzlePiece;
			newPiece.name = "PieceOne";
			//newPiece.transform.parent = container1.transform;
			newPiece.transform.position = container1.transform.position;
			//Destroy(puzzlePiece);
			return;
		}

		else if(container2.transform.childCount < 1)
		{
			GameObject newPiece = (GameObject)Instantiate(pieceTemplate);
			PieceIdentifier id = newPiece.GetComponent<PieceIdentifier>();
        	id.pieceIdentifier = 0;
        	newPiece.transform.SetParent(container2.transform, false);
        	RawImage pieceRawImage = newPiece.GetComponent<RawImage>();
        	pieceRawImage.texture = pController.trackPieces[0];
        	//pieceRawImage.DOFade(0f, 0f).OnComplete(()=>pieceRawImage.DOFade(1f, .25f));

        	RectTransform pieceRectTransform = newPiece.GetComponent<RectTransform>();
        	pieceRectTransform.anchoredPosition = new Vector2(-300f, 0f);
        	pieceRectTransform.sizeDelta = new Vector2(40f, 80f);
			//GameObject pieceOne = puzzlePiece;
			newPiece.name = "PieceTwo";
			//newPiece.transform.parent = container1.transform;
			newPiece.transform.position = container2.transform.position;
			//Destroy(puzzlePiece);
			return;
		}

		else if(container3.transform.childCount < 1)
		{
			GameObject newPiece = (GameObject)Instantiate(pieceTemplate);
			PieceIdentifier id = newPiece.GetComponent<PieceIdentifier>();
        	id.pieceIdentifier = 0;
        	newPiece.transform.SetParent(container3.transform, false);
        	RawImage pieceRawImage = newPiece.GetComponent<RawImage>();
        	pieceRawImage.texture = pController.trackPieces[0];
        	//pieceRawImage.DOFade(0f, 0f).OnComplete(()=>pieceRawImage.DOFade(1f, .25f));

        	RectTransform pieceRectTransform = newPiece.GetComponent<RectTransform>();
        	pieceRectTransform.anchoredPosition = new Vector2(-300f, 0f);
        	pieceRectTransform.sizeDelta = new Vector2(40f, 80f);
			//GameObject pieceOne = puzzlePiece;
			newPiece.name = "PieceThree";
			//newPiece.transform.parent = container1.transform;
			newPiece.transform.position = container2.transform.position;
			//Destroy(puzzlePiece);
			return;

		}

	}
}