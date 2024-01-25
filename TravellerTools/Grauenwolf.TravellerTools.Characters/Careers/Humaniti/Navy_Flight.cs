﻿namespace Grauenwolf.TravellerTools.Characters.Careers.Humaniti;

class Navy_Flight(SpeciesCharacterBuilder speciesCharacterBuilder) : Navy("Flight", speciesCharacterBuilder)
{
    protected override string AdvancementAttribute => "Edu";

    protected override int AdvancementTarget => 5;

    protected override string SurvivalAttribute => "Dex";

    protected override int SurvivalTarget => 7;

    internal override void AssignmentSkills(Character character, Dice dice)
    {
        switch (dice.D(6))
        {
            case 1:
                character.Skills.Increase(dice.Choose(SpecialtiesFor(character, "Pilot")));
                return;

            case 2:
                character.Skills.Increase(dice.Choose(SpecialtiesFor(character, "Flyer")));
                return;

            case 3:
                character.Skills.Increase(dice.Choose(SpecialtiesFor(character, "Gunner")));
                return;

            case 4:
                character.Skills.Increase("Pilot", "Small craft");
                return;

            case 5:
                character.Skills.Increase("Astrogation");
                return;

            case 6:
                character.Skills.Increase(dice.Choose(SpecialtiesFor(character, "Electronics")));
                return;
        }
    }
}
