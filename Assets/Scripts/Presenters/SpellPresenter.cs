using System.Collections.Generic;
using System.Linq;
using Model;
using Model.Spells;

namespace Presenters
{
    public class SpellPresenter : IPresenter
    {
        private readonly Spell _spell;
        private readonly SpellView _spellView;
        private readonly IEnumerable<Hero> _heroes;

        public SpellPresenter(Spell spell, SpellView spellView, IEnumerable<Hero> heroes)
        {
            _spell = spell;
            _spellView = spellView;
            _heroes = heroes;
        }

        public void Enable()
        {
            _spellView.Add(OnClick);
        }

        public void Disable()
        {
            _spellView.Remove(OnClick);
        }

        private void OnClick()
        {
            var aliveHeroes = _heroes.Where(hero => hero.IsAlive);

            foreach (var hero in aliveHeroes)
                hero.UseSpell(_spell);
        }
    }
}