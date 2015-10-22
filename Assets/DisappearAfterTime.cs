using UnityEngine;
using System.Collections;
using DG.Tweening;

public class DisappearAfterTime : MonoBehaviour {

    public float deathTimer;
    public float shakeThreshold;
    public float shakeDuration;

    // default 10
    public int shakeVibrato;

    public float fallTimer;
    public float fallLength;
    public float fadeTimer;

    private float currentLifetime;

    // default (1, 1, 1)
    private Vector3 shakeStrength;

    private TrackPieceStatus thisStatus;

    void Start()
    {
        currentLifetime = deathTimer;
        thisStatus = GetComponent<TrackPieceStatus>();
        shakeStrength = new Vector3(.25f, .1f, .25f);
    }

    void Update()
    {
        currentLifetime -= Time.deltaTime;
        if (currentLifetime <= 0f)
        {
            this.DOKill();
            // first lower track piece, then destroy it
            thisStatus.isFalling = true;
            this.transform.DOMoveY(fallLength, fallTimer).OnComplete(() => Destroy(gameObject));
        }
        else if (currentLifetime <= shakeThreshold)
        {
            this.transform.DOShakePosition(shakeDuration, shakeStrength, shakeVibrato);
        }
    }
}
