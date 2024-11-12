namespace Model.Spells
{
    public class RageSpell : Spell
    {
        public float CountOfSpeedUp => Config.CountOfSpeedUp;

        public override void Accept(ISpellVisitor spellVisitor)
        {
            spellVisitor.UseSpell(this);
        }
    }
}