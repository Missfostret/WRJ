using UnityEngine;

public class StatSystem : MonoBehaviour
{
    [SerializeField]
    int maxHealth = 100;
    int currentHealth;

    [SerializeField]
    int maxStamina = 100;
    int currentStamina;

    [SerializeField]
    int maxMana = 100;
    int currentMana;

    [Tooltip("Armor is a percentage, 10 armor = 10% armor")]
    [SerializeField]
    int ArmorPercentage = 10;


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
    int GetArmourPercent()
    {
        return (int)(ArmorPercentage / 100);
    }

    void DecreaseHealth(int incomingDamage)
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

    void DecreaseMana(int manaCost)
    {
        Mathf.Clamp(currentMana -= manaCost, 0, maxMana);
    }

    void DecreaseStamina(int staminaDrain)
    {
        Mathf.Clamp(currentStamina -= staminaDrain, 0, maxStamina);
    }

    // Setters Getters

    public int GetHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }

    public int GetStamina
    {
        get { return currentStamina; }
        set { currentStamina = value; }
    }

    public int GetMana
    {
        get { return currentMana; }
        set { currentMana = value; }
    }
}
