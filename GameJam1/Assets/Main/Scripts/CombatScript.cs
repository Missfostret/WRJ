using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour
{
    [SerializeField]
    List<Spell> spells;

    [SerializeField]
    StatSystem stats;

    private void Start()
    {
        if (stats == null)
        {
            stats = gameObject.GetComponent<StatSystem>();
        }
    }

    public void SpawnAttack(int spellButtonID)
    {
        if (spells.Count >= spellButtonID - 1)
        {
            var selectedSpell = spells[spellButtonID - 1];

            if (stats.GetMana >= selectedSpell.manaCost)
            {
                if (selectedSpell.spellPrefab)
                {
                    Instantiate(selectedSpell.spellPrefab, transform.position, transform.rotation);
                    stats.GetMana -= selectedSpell.manaCost;
                    print("Casting : " + selectedSpell.attackName);
                }
            }
            else
            {
                print("Tried to cast: " + selectedSpell.attackName + " but mana too low");
            }
        }
    }
}
