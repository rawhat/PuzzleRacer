using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropTrackPiece : MonoBehaviour, IDropHandler {


    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("dropped: " + eventData.pointerPress.name);
        Destroy(eventData.pointerPress);
    }
}
