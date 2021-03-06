﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using DG.Tweening;

public class BlockController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler {

    public static GameObject puzzlePiece;
    public float snapBackTimer;

    private RectTransform pieceRectTransform;

    private Vector3 startPos;
    private Transform parentPanel;

    private PuzzleController puzzleController;

    private Vector3 screenPoint;
    private Vector3 offset;

    void Start()
    {
        puzzleController = GameObject.FindObjectOfType<PuzzleController>();
    }


    /*
	void OnMouseDown()
	{
        Debug.Log("clicked: " + gameObject.transform.parent.name);
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	public void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
	}
     * 
     * */



    public void OnBeginDrag(PointerEventData eventData)
    {
        puzzlePiece = gameObject;
        startPos = gameObject.transform.position;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        gameObject.transform.DOMove(startPos, snapBackTimer);
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == -2)
        {
            puzzleController.SendMessage("AcceptPiece", gameObject);
        }
    }
}
