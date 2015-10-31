using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropTrackPiece : MonoBehaviour, IDropHandler {

    private GravityGunController gravGunController;

    void Start()
    {
        gravGunController = GameObject.FindObjectOfType<GravityGunController>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (gravGunController.energyLevel >= 50f)
        {
            gravGunController.DecreaseEnergy();
            Destroy(eventData.pointerPress);
        }
    }
}
