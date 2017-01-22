﻿using System;

namespace Grauenwolf.TravellerTools.Characters.Careers
{
    abstract class Drifter : NormalCareer
    {
        public Drifter(string assignment) : base("Drifter", assignment)
        {

        }

        protected override int AdvancedEductionMin
        {
            get { return int.MaxValue; }
        }

        protected override bool RankCarryover
        {
            get { return false; }
        }

        public override bool Qualify(Character character, Dice dice)
        {
            return !character.LongTermBenefits.Retired;
        }

        internal override void Event(Character character, Dice dice)
        {
            switch (dice.D(2, 6))
            {
                case 2:
                    Mishap(character, dice);
                    character.NextTermBenefits.MusterOut = false;
                    return;
                case 3:
                    character.AddHistory("Offered job by a patron. Now owe him a favor.");
                    character.NextTermBenefits.MusterOut = true;
                    character.NextTermBenefits.QualificationDM += 4;
                    return;
                case 4:
                    var skills = new SkillTemplateCollection();
                    skills.Add("Jack-of-All-Trades");
                    skills.Add("Survival");
                    skills.Add("Streetwise");
                    skills.AddRange(CharacterBuilder.SpecialtiesFor("Melee"));
                    character.Skills.Increase(dice.Choose(skills));
                    return;
                case 5:
                    character.AddHistory("Find valuable salvage.");
                    character.BenefitRollDMs.Add(1);
                    return;
                case 6:
                    CharacterBuilder.UnusualLifeEvent(character, dice);
                    return;
                case 7:
                    CharacterBuilder.LifeEvent(character, dice);
                    return;
                case 8:
                    var bestSkill = character.Skills.BestSkillLevel("Melee", "Gun Combat", "Stealth");
                    if (dice.RollHigh(bestSkill, 8))
                    {
                        character.AddHistory("Attacked by enemies that you easily defeat.");
                    }
                    else
                    {
                        character.AddHistory("Attacked by enemies and injured.");
                        CharacterBuilder.Injury(character, dice);
                    }
                    character.AddHistory("Gain Enemy if you don't already have one.");
                    return;
                case 9:
                    {
                        var roll = dice.D(6);
                        if (roll == 1)
                        {
                            character.AddHistory("Attempted a risky adventure and was injured.");
                            CharacterBuilder.Injury(character, dice);
                        }
                        else if (roll == 2)
                        {
                            character.AddHistory("Attempted a risky adventure and was sent to prison.");
                            character.NextTermBenefits.MustEnroll = "Prisoner";
                        }
                        else if (roll < 5)
                        {
                            character.AddHistory("Survived a risky adventure but gained nothing.");
                        }
                        else
                        {
                            character.AddHistory("Attempted a risky adventure and was wildly successful.");
                            character.BenefitRollDMs.Add(4);
                        }
                    }
                    return;
                case 10:
                    dice.Choose(character.Skills).Level += 1;
                    return;
                case 11:
                    character.NextTermBenefits.MusterOut = true;
                    character.NextTermBenefits.MustEnroll = CharacterBuilder.RollDraft(dice);
                    character.AddHistory("Drafted into " + character.NextTermBenefits.MustEnroll);
                    return;
                case 12:
                    character.CurrentTermBenefits.AdvancementDM += 100;
                    return;
            }
        }

        internal override void Mishap(Character character, Dice dice)
        {
            switch (dice.D(6))
            {
                case 1:
                    CharacterBuilder.Injury(character, dice, true);
                    return;
                case 2:
                    CharacterBuilder.Injury(character, dice);
                    return;
                case 3:
                    character.AddHistory("run afoul of a criminal gang, corrupt bureaucrat or other foe. Gain an Enemy.");
                    return;

                case 4:
                    character.AddHistory("Suffer from a life-threatening illness.");
                    character.Endurance -= 1;
                    return;
                case 5:
                    character.AddHistory("Betrayed by a friend. One of your Contacts or Allies betrays you, ending your career. That Contact or Ally becomes a Rival or Enemy.");
                    if (dice.D(2, 12) == 2)
                        character.NextTermBenefits.MustEnroll = "Prisoner";
                    return;
                case 6:
                    character.AddHistory("You do not know what happened to you. There is a gap in your memory.");
                    return;
            }
        }

        protected override void AdvancedEducation(Character character, Dice dice, int roll, bool level0)
        {
            throw new NotImplementedException();
        }

        protected override void BasicTraining(Character character, Dice dice, bool firstCareer)
        {
            if (firstCareer)
                for (var i = 1; i < 7; i++)
                    AssignmentSkills(character, dice, i, true);
            else
                AssignmentSkills(character, dice, dice.D(6), true);
        }
        protected override void PersonalDevelopment(Character character, Dice dice, int roll, bool level0)
        {
            switch (roll)
            {
                case 1:
                    character.Strength += 1;
                    return;
                case 2:
                    character.Endurance += 1;
                    return;
                case 3:
                    character.Dexterity += 1;
                    return;
                case 4:
                    character.Skills.Increase(dice.Choose(CharacterBuilder.SpecialtiesFor("Language")));
                    return;
                case 5:
                    character.Skills.Increase(dice.Choose(CharacterBuilder.SpecialtiesFor("Profession")));
                    return;
                case 6:
                    character.Skills.Increase("Jack-of-All-Trades");
                    return;
            }
        }

        protected override void ServiceSkill(Character character, Dice dice, int roll, bool level0)
        {
            switch (roll)
            {
                case 1:
                    character.Skills.Increase(dice.Choose(CharacterBuilder.SpecialtiesFor("Athletics")));
                    return;
                case 2:
                    character.Skills.Increase("Melee", "Unarmed");
                    return;
                case 3:
                    character.Skills.Increase("Recon");
                    return;
                case 4:
                    character.Skills.Increase("Streetwise");
                    return;
                case 5:
                    character.Skills.Increase("Stealth");
                    return;
                case 6:
                    character.Skills.Increase("Survival");
                    return;
            }
        }
    }
}

