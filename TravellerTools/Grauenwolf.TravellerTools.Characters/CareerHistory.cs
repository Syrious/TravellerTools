﻿namespace Grauenwolf.TravellerTools.Characters;

public class CareerHistory(string career, string? assignment, int rank, int commissionRank = 0)
{
    public string? Assignment { get; set; } = assignment;
    public string Career { get; set; } = career;
    public int CommissionRank { get; set; } = commissionRank;

    public string LongName
    {
        get
        {
            if (Assignment == null)
                return Career;
            else
                return $"{Career} ({Assignment})";
        }
    }

    public int Rank { get; set; } = rank;

    public string ShortName => Assignment ?? Career;
    public int Terms { get; set; }
    public string? Title { get; set; }
}
