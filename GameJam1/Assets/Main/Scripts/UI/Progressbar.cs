using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Enums;

public class Progressbar : MonoBehaviour
{
    public Image topLayer;
    public TMP_Text percentageText;

    [SerializeField]
    StatSystem statSystem;

    [SerializeField]
    Gradient gradient;

    [SerializeField]
    Stat stat;

    float maxStat;
    float currentStat;


    private void Update()
    {
        SetStatToUse();
        var percentage = currentStat / maxStat;
        topLayer.fillAmount = percentage;
        topLayer.color = gradient.Evaluate(topLayer.fillAmount);
        percentageText.text = (percentage * 100f).ToString() + " %";
    }

    public void SetMaxHealth(int health)
    {
        topLayer.fillAmount = 1f;
        gradient.Evaluate(1f);
    }

    public void SetStatToUse()
    {
        switch (stat)
        {
            case Stat.Health:
                maxStat = statSystem.GetMaxHealth;
                currentStat = statSystem.GetHealth;
                break;
            case Stat.Mana:
                maxStat = statSystem.GetMaxMana;
                currentStat = statSystem.GetMana;
                break;
            case Stat.Stamina:
                maxStat = statSystem.GetMaxStamina;
                currentStat = statSystem.GetStamina;
                break;
        }
    }
}
