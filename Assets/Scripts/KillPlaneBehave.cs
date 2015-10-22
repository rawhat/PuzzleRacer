using UnityEngine;
using System.Collections;

public class KillPlaneBehave : MonoBehaviour {

	public GameObject killTarget; 
	public GameObject startPiece;
	[SerializeField] private Vector3 checkpointPos;
	private Vector3 colliderSize;

	// Use this for initialization
	void Start () {
		checkpointPos = killTarget.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		FollowKillTarget();
		if((killTarget.transform.position.y) <= (transform.position.y + 1))
			ResetPlayer();
	
	}

	void OnCollisionEnter(Collision collision)
	{
		ResetPlayer();
	}

	void ResetPlayer()
	{
		GameObject.Instantiate(startPiece, checkpointPos, Quaternion.identity);
		killTarget.transform.position = new Vector3(checkpointPos.x, checkpointPos.y + 3, checkpointPos.z);

	}

	public void SetCheckpointPos(Vector3 pos)
	{
		checkpointPos = pos;
	}

	void FollowKillTarget()
	{
		transform.position = new Vector3(killTarget.transform.position.x, transform.position.y, killTarget.transform.position.z);
	}
}
