namespace Model.Spells
{
    public abstract class Spell : Entity
    {
        public abstract void Accept(ISpellVisitor spellVisitor);
    }
}