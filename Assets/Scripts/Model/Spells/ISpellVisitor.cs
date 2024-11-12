namespace Model.Spells
{
    public interface ISpellVisitor
    {
        void UseSpell(HealthSpell healthSpell);
        void UseSpell(RageSpell rageSpell);
    }
}