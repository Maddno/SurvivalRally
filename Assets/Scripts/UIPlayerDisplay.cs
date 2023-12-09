using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] private HealthHolder player;

    [Header("Progress")]
    [SerializeField] private Slider progressSlider;
    [SerializeField] private TextMeshProUGUI progressText;
    [SerializeField] private int lvlGoal = 500;

    CarMovement carMovement;
    CanvaControle canvaControle;

    private void Awake()
    {
        player = FindObjectOfType<HealthHolder>();
        carMovement = FindObjectOfType<CarMovement>();
        canvaControle = FindObjectOfType<CanvaControle>();
        progressSlider.maxValue = lvlGoal;
        healthSlider.maxValue = player.GetHealth();
    }

    private void Update()
    {
        progressText.text = carMovement.GetDistanvce().ToString();
        if(carMovement.GetDistanvce() >= lvlGoal)
        {
            canvaControle.GameWin();
        }
        healthSlider.value = player.GetHealth();
        progressSlider.value = carMovement.GetDistanvce();
    }
}
