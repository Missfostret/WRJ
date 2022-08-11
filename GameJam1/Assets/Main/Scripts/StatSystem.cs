using UnityEngine;
using Helpers;

public class StatSystem : MonoBehaviour
{
    [SerializeField]
    float maxHealth = 100f;
    float currentHealth;

    [SerializeField]
    float maxStamina = 100f;
    float currentStamina;

    [SerializeField]
    float maxMana = 100f;
    float currentMana;

    [Tooltip("Armor is a percentage, 10 armor = 10% armor")]
    [SerializeField]
    float ArmorPercentage = 10f;

    [SerializeField]
    Enums.EntityState entityState = Enums.EntityState.Player;

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
        currentHealth = Mathf.Clamp(currentHealth - newDamage, 0, maxHealth);
        print("Taking Damage: " + currentHealth);
        currentHealth = FunctionLibrary.RoundTo1D(currentHealth);

        if (currentHealth <= 0)
        {
            //do death stuff here bro
            print("You Died");
        }
    }

    public void IncreaseHealth(float incomingHeal)
    {
        currentHealth = Mathf.Clamp(currentHealth + incomingHeal, 0, maxHealth);
        print("healing: " + currentHealth);
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

    public float GetMaxHealth
    {
        get { return maxHealth; }
    }

    public float GetStamina
    {
        get { return currentStamina; }
        set { currentStamina = value; }
    }

    public float GetMaxStamina
    {
        get { return maxStamina; }
        set { maxStamina = value; }
    }

    public float GetMana
    {
        get { return currentMana; }
        set { currentMana = value; }
    }

    public float GetMaxMana
    {
        get { return maxMana; }
        set { currentMana = value; }
    }

    public Enums.EntityState GetEntityState
    {
        get { return entityState; }
        private set { entityState = value; }
    }
}
