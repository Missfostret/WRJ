using Enums;

public struct SpellStruct
{
    public string attackName;
    public SpellTypes spellType;

    public void SetValue(string iAttackName, SpellTypes iSpellType)
    {
        attackName = iAttackName;
        spellType = iSpellType;
    }
}