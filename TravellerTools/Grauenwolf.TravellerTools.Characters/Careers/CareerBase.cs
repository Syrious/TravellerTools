using System.Collections.Immutable;

namespace Grauenwolf.TravellerTools.Characters.Careers;

public abstract class CareerBase(string career, string? assignment, SpeciesCharacterBuilder speciesCharacterBuilder)
{
    readonly SpeciesCharacterBuilder m_SpeciesCharacterBuilder = speciesCharacterBuilder;
    public string? Assignment { get; } = assignment;
    public string Career { get; } = career;
    public string Key => Assignment ?? Career;

    /// <summary>
    /// Gets the assignment. If that is null, returns the career.
    /// </summary>
    public string ShortName => Assignment ?? Career;

    internal virtual bool RankCarryover { get; } = false;
    protected virtual int QualifyDM => 0;

    public void AddOneRandomSkill(Character character, Dice dice)
    {
        var skillList = new SkillTemplateCollection(RandomSkills(character));
        skillList.RemoveOverlap(character.Skills, 1);
        if (skillList.Count > 0)
            character.Skills.Add(dice.Choose(skillList), 1);
    }

    /// <summary>
    /// Adds the one skill at level 1.
    /// </summary>
    /// <returns>Returns false if the character already has all of the skills.</returns>
    public bool AddOneSkill(Character character, Dice dice, params string[] skills)
    {
        var skillList = new SkillTemplateCollection();
        foreach (var skill in skills)
        {
            if (skill.Contains("|"))
            {
                var parts = skill.Split('|');
                skillList.Add(parts[0], parts[1]);
            }
            else
                skillList.AddRange(SpecialtiesFor(character, skill));
        }

        skillList.RemoveOverlap(character.Skills, 1);
        if (skillList.Count == 0)
            return false;

        character.Skills.Add(dice.Choose(skillList), 1);
        return true;
    }

    /*
    /// <summary>
    /// Adds a benefit or a one skill at level 1.
    /// </summary>
    /// <returns>Returns false if the character already has all of the skills.</returns>
    public void AddOneSkillOrBenefit(Character character, Dice dice, Action benefiit, params string[] skills)
    {
        var skillList = new SkillTemplateCollection();
        foreach (var skill in skills)
        {
            if (skill.Contains("|"))
            {
                var parts = skill.Split('|');
                skillList.Add(parts[0], parts[1]);
            }
            else
                skillList.AddRange(SpecialtiesFor(character, skill));
        }

        skillList.RemoveOverlap(character.Skills, 1);
        if (skillList.Count == 0 || dice.NextBoolean())
            benefiit();
        else
            character.Skills.Add(dice.Choose(skillList), 1);
    }
    */

    /// <summary>
    /// Increases one skill by 1 level.
    /// </summary>
    public void IncreaseOneSkill(Character character, Dice dice, params string[] skills)
    {
        var skillList = new SkillTemplateCollection();
        foreach (var skill in skills)
        {
            if (skill.Contains("|"))
            {
                var parts = skill.Split('|');
                skillList.Add(parts[0], parts[1]);
            }
            else
                skillList.AddRange(SpecialtiesFor(character, skill));
        }

        character.Skills.Increase(dice.Choose(skillList), 1);
    }

    public override string ToString()
    {
        if (Assignment == null)
            return Career;
        else
            return $"{Assignment} ({Career})";
    }

    internal virtual decimal MedicalPaymentPercentage(Character character, Dice dice) => 0;

    /// <summary>
    /// Qualifies the specified character.
    /// </summary>
    /// <param name="isPrecheck">Pretend the character rolled an 8. Used to determine which careers to try.</param>
    internal abstract bool Qualify(Character character, Dice dice, bool isPrecheck);

    internal abstract void Run(Character character, Dice dice);

    protected void FixupSkills(Character character, Dice dice) => m_SpeciesCharacterBuilder.FixupSkills(character, dice);

    protected void Injury(Character character, Dice dice, bool severe, int age) => m_SpeciesCharacterBuilder.Injury(character, dice, this, severe, age);

    protected void Injury(Character character, Dice dice, int age) => m_SpeciesCharacterBuilder.Injury(character, dice, this, false, age);

    protected void InjuryRollAge(Character character, Dice dice, bool severe) => m_SpeciesCharacterBuilder.Injury(character, dice, this, severe, character.Age + dice.D(4));

    protected void InjuryRollAge(Character character, Dice dice) => m_SpeciesCharacterBuilder.Injury(character, dice, this, false, character.Age + dice.D(4));

    protected void LifeEvent(Character character, Dice dice) => m_SpeciesCharacterBuilder.LifeEvent(character, dice, this);

    protected void PreCareerEvents(Character character, Dice dice, CareerBase career, SkillTemplateCollection skills) => m_SpeciesCharacterBuilder.PreCareerEvents(character, dice, career, skills);

    protected ImmutableArray<PsionicSkillTemplate> PsionicTalents(Character character) => m_SpeciesCharacterBuilder.Book(character).PsionicTalents;

    /// <summary>
    /// Gets the list of random skills. Skills needing specialization will be excluded. For example, "Art (Performer)" will be included but just "Art" will not.
    /// </summary>
    protected ImmutableArray<SkillTemplate> RandomSkills(Character character) => m_SpeciesCharacterBuilder.Book(character).RandomSkills;

    protected CareerBase RollDraft(Character character, Dice dice) => m_SpeciesCharacterBuilder.RollDraft(character, dice);

    /// <summary>
    /// Returns all the specialities for a skill. If it has no specialities, then just return the skill.
    /// </summary>
    protected List<SkillTemplate> SpecialtiesFor(Character character, string skillName) => m_SpeciesCharacterBuilder.Book(character).SpecialtiesFor(skillName);

    protected void TestPsionic(Character character, Dice dice, int age) => m_SpeciesCharacterBuilder.TestPsionic(character, dice, age);

    protected void UnusualLifeEvent(Character character, Dice dice) => m_SpeciesCharacterBuilder.UnusualLifeEvent(character, dice);
}
