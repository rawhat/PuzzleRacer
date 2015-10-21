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

    void Start()
    {
        currentLifetime = deathTimer;
        shakeStrength = new Vector3(.25f, 0f, .25f);
    }

    void Update()
    {
        currentLifetime -= Time.deltaTime;
        if (currentLifetime <= 0f)
        {
            Debug.Log("Dying");
            this.DOKill();
            // first lower track piece, then destroy it
            this.transform.DOMoveY(fallLength, fallTimer).OnComplete(() => Destroy(gameObject));
        }
        else if (currentLifetime <= shakeThreshold)
        {
            this.transform.DOShakePosition(shakeDuration, shakeStrength, shakeVibrato);
        }
    }
}
