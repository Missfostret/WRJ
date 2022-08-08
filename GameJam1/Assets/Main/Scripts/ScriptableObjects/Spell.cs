using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/Attacks")]
public class Spell : ScriptableObject
{
    public string attackName;
    public SpellTypes spellType;
    [Tooltip("This also acts like tick damage")]
    public float spellDamage;
    public float healTickAmount;
    public float manaCost;
    public GameObject spellPrefab;
}
