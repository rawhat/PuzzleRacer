using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;
using DG.Tweening;

public class WormholeController : MonoBehaviour {

    public GameObject player;
    public float dragTimer;

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            Debug.Log("player entered wormhole");
            Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.angularVelocity = Vector3.zero;
            player.GetComponent<CarController>().enabled = false;
            foreach(GameObject trackPiece in GameObject.FindGameObjectsWithTag("TrackPiece")){
                Destroy(trackPiece); 
            }
            player.transform.DOMove(transform.position, dragTimer);
        }
    }
}
