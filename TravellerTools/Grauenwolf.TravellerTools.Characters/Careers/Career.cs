using System.Collections.Generic;
using System.Collections.Immutable;

namespace Grauenwolf.TravellerTools.Characters.Careers
{
    public abstract class CareerBase
    {
        protected CareerBase(string career, string? assignment, Book book)
        {
            Book = book;
            Career = career;
            Assignment = assignment;
        }

        public string? Assignment { get; }

        public string Career { get; }

        public string Key
        {
            get { return Assignment ?? Career; }
        }

        internal Book Book { get; }

        protected ImmutableArray<SkillTemplate> RandomSkills
        {
            get { return Book.RandomSkills; }
        }

        public override string ToString()
        {
            if (Assignment == null)
                return Career;
            else
                return $"{Assignment} ({Career})";
        }

        internal virtual decimal MedicalPaymentPercentage(Character character, Dice dice)
        {
            return 0;
        }

        internal abstract bool Qualify(Character character, Dice dice);

        internal abstract void Run(Character character, Dice dice);

        protected void Injury(Character character, Dice dice, bool severe, int age) => Book.Injury(character, dice, this, severe, age);

        protected void Injury(Character character, Dice dice, int age) => Book.Injury(character, dice, this, false, age);

        protected void InjuryRollAge(Character character, Dice dice, bool severe) => Book.Injury(character, dice, this, severe, character.Age + dice.D(4));

        protected void InjuryRollAge(Character character, Dice dice) => Book.Injury(character, dice, this, false, character.Age + dice.D(4));

        protected void LifeEvent(Character character, Dice dice) => Book.LifeEvent(character, dice, this);

        protected List<SkillTemplate> SpecialtiesFor(string skillName) => Book.SpecialtiesFor(skillName);

        protected void UnusualLifeEvent(Character character, Dice dice) => Book.UnusualLifeEvent(character, dice);
    }
}
