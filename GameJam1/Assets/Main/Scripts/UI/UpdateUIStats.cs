using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateUIStats : MonoBehaviour
{
    [SerializeField]
    StatSystem playerStats;

    public TMP_Text healthText;
    public TMP_Text manaText;
    public TMP_Text staminaText;

    private void Update()
    {
        var flatHealth = Mathf.Floor(playerStats.GetHealth);
        var flatMana = Mathf.Floor(playerStats.GetMana);
        var flatStamina = Mathf.Floor(playerStats.GetStamina);

        healthText.SetText("Health: " + flatHealth.ToString());
        manaText.SetText("Mana : " + flatMana.ToString());
        staminaText.SetText("Stamina : " + flatStamina.ToString());
    }
}
