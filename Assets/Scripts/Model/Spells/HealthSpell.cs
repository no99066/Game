namespace Model.Spells
{
    public class HealthSpell : Spell
    {
        public float CountOfRestoreHealth => Config.CountOfRestoreHealth;

        public override void Accept(ISpellVisitor spellVisitor)
        {
            spellVisitor.UseSpell(this);
        }
    }
}