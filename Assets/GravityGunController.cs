using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class GravityGunController : MonoBehaviour {

    public float energyCooldown;

    public Slider energySlider;
    public Slider refreshSlider;

    public float refreshScaler;

    public float energyTweenTimer;

    public float energyLevel;
    private float refreshLevel;

    private bool energyDepleted = false;
    private GeneratePieceGrid generateGrid;

    void Start()
    {
        generateGrid = GameObject.FindObjectOfType<GeneratePieceGrid>();
        energyLevel = 100f;
        refreshLevel = 0f;
    }

    void Update()
    {
        refreshLevel += Time.deltaTime * refreshScaler;
        refreshSlider.value = refreshLevel;
        //energySlider.value = energyLevel;

        if (refreshLevel >= 100f)
        {
            generateGrid.GenerateGrid();
            refreshLevel = 0f;
        }
    }

    public void DecreaseEnergy()
    {
        energyLevel = energyLevel - 50f;
        energySlider.DOValue(energySlider.value - 50f, energyTweenTimer);
    }
}
