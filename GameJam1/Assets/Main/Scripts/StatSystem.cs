using UnityEngine;

public class StatSystem : MonoBehaviour
{
    [SerializeField]
    float maxHealth = 100;
    float currentHealth;

    [SerializeField]
    float maxStamina = 100;
    float currentStamina;

    [SerializeField]
    float maxMana = 100;
    float currentMana;

    [Tooltip("Armor is a percentage, 10 armor = 10% armor")]
    [SerializeField]
    float ArmorPercentage = 10;


    void Start()
    {
        ResetStats();
    }

    void ResetStats()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
        currentMana = maxMana;
    }
    public float GetArmourPercent()
    {
        return (ArmorPercentage / 100f);
    }

    public void DecreaseHealth(float incomingDamage)
    {
        //calculates how much damage to negate depending on armor
        var damageNegation = GetArmourPercent() * incomingDamage;
        var newDamage = incomingDamage - damageNegation;
        Mathf.Clamp(currentHealth -= newDamage, 0, maxHealth);

        if (currentHealth <= 0)
        {
            //do death stuff here bro
            print("You Died");
        }
    }

    public void DecreaseMana(float manaCost)
    {
        Mathf.Clamp(currentMana -= manaCost, 0, maxMana);
    }

    public void DecreaseStamina(float staminaDrain)
    {
        Mathf.Clamp(currentStamina -= staminaDrain, 0, maxStamina);
    }

    // Setters Getters

    public float GetHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }

    public float GetStamina
    {
        get { return currentStamina; }
        set { currentStamina = value; }
    }

    public float GetMana
    {
        get { return currentMana; }
        set { currentMana = value; }
    }
}
