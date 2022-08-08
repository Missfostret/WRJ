using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progressbar : MonoBehaviour
{
    public Image topLayer;

    [SerializeField]
    StatSystem statSystem;

    [SerializeField]
    Gradient gradient;

    private void Update()
    {
        topLayer.fillAmount = statSystem.GetHealth / statSystem.GetMaxHealth;
        topLayer.color = gradient.Evaluate(topLayer.fillAmount);
    }

    public void SetMaxHealth(int health)
    {
        topLayer.fillAmount = 1f;
        gradient.Evaluate(1f);
    }
}
