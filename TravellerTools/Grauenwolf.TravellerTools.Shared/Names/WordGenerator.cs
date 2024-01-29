﻿using System.Collections.Immutable;
using static Grauenwolf.TravellerTools.Shared.Names.LanguageType;

namespace Grauenwolf.TravellerTools.Shared.Names;

static class WordGenerator
{
    static readonly ImmutableDictionary<LanguageType, Syllable[]> AlternateSyllables =
        SupportedLanguages()
        .Select(key => new { key, value = BuildAlternateSyllables(key) })
        .ToImmutableDictionary(x => x.key, x => x.value);

    static readonly ImmutableDictionary<LanguageType, Syllable[]> BasicSyllables =
        SupportedLanguages()
        .Select(key => new { key, value = BuildBasicSyllables(key) })
        .ToImmutableDictionary(x => x.key, x => x.value);

    static readonly ImmutableDictionary<LanguageType, Syllable[]> FinalConsonants =
        SupportedLanguages()
        .Select(key => new { key, value = BuildFinalConsonants(key) })
        .ToImmutableDictionary(x => x.key, x => x.value);

    static readonly ImmutableDictionary<LanguageType, Syllable[]> InitialConsonants =
        SupportedLanguages()
        .Select(key => new { key, value = BuildInitialConsonants(key) })
        .ToImmutableDictionary(x => x.key, x => x.value);

    static readonly ImmutableDictionary<LanguageType, Syllable[]> Vowels =
        SupportedLanguages()
        .Select(key => new { key, value = BuildVowels(key) })
        .ToImmutableDictionary(x => x.key, x => x.value);

    public static string GenerateName(LanguageType languageType, Dice dice)
    {
        while (true)
        {
            var result = dice.D(6) switch
            {
                1 => GetCapitalizedWord(languageType, dice),
                <= 5 => GetCapitalizedWord(languageType, dice) + " " + GetCapitalizedWord(languageType, dice),
                _ => GetCapitalizedWord(languageType, dice) + " " + GetCapitalizedWord(languageType, dice) + " " + GetCapitalizedWord(languageType, dice),
            };

            result = result.Replace("- ", "-");
            if (result.Length > 2 && result.EndsWith('-'))
                result = result[0..^2];

            if (result.Length <= 3)
                continue;

            return result;
        }
    }

    static Syllable[] BuildAlternateSyllables(LanguageType languageType)
    {
        return languageType switch
        {
            Aslan => [("v", 15), ("vc", 36)],
            Darrian => [("vc", 27), ("v", 36)],
            Droyne => [("v", 6), ("cv", 12), ("vc", 18), ("cvc", 36)],
            Ithklur => [("cv", 36)],
            KKree => [("cv", 18), ("vc", 23), ("cvc", 36)],
            Vargr => [("cv", 18), ("cvc", 36)],
            Vilani => [("cv", 21), ("cvc", 36)],
            Zhodani => [("v", 6), ("cv", 12), ("vc", 18), ("cvc", 36)],
            Hiver => [("v", 6), ("cv", 8), ("vc", 22), ("cvc", 36)],
            AelYael => [("cv", 36)],
            NeoIcelandic => [("vc", 3), ("cv", 14), ("cvc", 36)],
            Bwap => [("cv", 13), ("cvc", 25), ("vc", 34), ("v", 36)],
            Kehuu => [("v", 6), ("cv", 23), ("vc", 33), ("cvc", 36)],
            Ushi => [("v", 4), ("cv", 14), ("vc", 32), ("cvc", 36)],
            Loes => [("v", 10), ("cv", 28), ("vc", 32), ("cvc", 36)],
            Galanglic => [("cv", 15), ("cvc", 29), ("vc", 35), ("cvc", 36)],
            _ => throw new ArgumentOutOfRangeException(nameof(languageType)),
        };
    }

    static Syllable[] BuildBasicSyllables(LanguageType languageType)
    {
        return languageType switch
        {
            Aslan => [("v", 13), ("cv", 22), ("vc", 30), ("cvc", 36)],
            Darrian => [("cvc", 27), ("cv", 36)],
            Droyne => [("v", 7), ("cv", 18), ("vc", 29), ("cvc", 36)],
            Ithklur => [("cv", 36)],
            KKree => [("v", 6), ("cv", 21), ("vc", 27), ("cvc", 36)],
            Vargr => [("v", 4), ("vc", 18), ("cv", 22), ("cvc", 36)],
            Vilani => [("v", 6), ("cv", 21), ("vc", 29), ("cvc", 36)],
            Zhodani => [("v", 3), ("cv", 6), ("vc", 15), ("cvc", 36)],
            Hiver => [("cv", 12), ("vc", 24), ("cvc", 36)],
            AelYael => [("vc", 3), ("cv", 30), ("cvc", 36)],
            NeoIcelandic => [("v", 1), ("vc", 6), ("cv", 14), ("cvc", 36)],
            Bwap => [("cv", 13), ("cvc", 25), ("vc", 34), ("v", 36)],
            Kehuu => [("v", 1), ("cv", 8), ("vc", 21), ("cvc", 36)],
            Ushi => [("v", 4), ("cv", 16), ("vc", 26), ("cvc", 36)],
            Loes => [("v", 8), ("cv", 22), ("vc", 30), ("cvc", 36)],
            Galanglic => [("cv", 15), ("cvc", 29), ("vc", 35), ("cvc", 36)],
            _ => throw new ArgumentOutOfRangeException(nameof(languageType)),
        };
    }

    static Syllable[] BuildFinalConsonants(LanguageType languageType)
    {
        return languageType switch
        {
            Aslan => [("h", 46),
                ("kh", 64),
                ("l", 96),
                ("lr", 110),
                ("r", 133),
                ("rl", 151),
                ("s", 175),
                ("w", 199),
                ("\'", 216)],
            Darrian => [("bh", 9),
                ("dh", 18),
                ("gh", 24),
                ("p", 30),
                ("t", 36),
                ("k", 45),
                ("n", 66),
                ("ng", 78),
                ("l", 109),
                ("r", 138),
                ("s", 156),
                ("m", 171),
                ("mb", 177),
                ("nd", 183),
                ("ngg", 186),
                ("yr", 192),
                ("ly", 195),
                ("ny", 198),
                ("lbh", 201),
                ("lz", 207),
                ("ld", 216)],
            Droyne => [("b", 6),
                ("d", 17),
                ("f", 22),
                ("h", 28),
                ("k", 36),
                ("l", 40),
                ("lb", 42),
                ("ld", 49),
                ("lk", 53),
                ("lm", 56),
                ("ln", 57),
                ("lp", 58),
                ("ls", 60),
                ("lt", 62),
                ("m", 73),
                ("n", 80),
                ("p", 92),
                ("r", 101),
                ("rd", 104),
                ("rf", 106),
                ("rk", 111),
                ("rm", 115),
                ("rn", 118),
                ("rp", 119),
                ("rs", 123),
                ("rt", 128),
                ("rv", 130),
                ("s", 153),
                ("sk", 160),
                ("ss", 167),
                ("st", 172),
                ("t", 184),
                ("th", 190),
                ("ts", 200),
                ("v", 204),
                ("x", 216)],
            Ithklur => [("d", 15),
                ("f", 24),
                ("g", 30),
                ("gh", 42),
                ("h", 48),
                ("hz", 54),
                ("j", 60),
                ("jj", 63),
                ("jz", 69),
                ("k", 81),
                ("kk", 90),
                ("ks", 99),
                ("kz", 108),
                ("l", 116),
                ("ll", 120),
                ("m", 126),
                ("n", 132),
                ("q", 141),
                ("r", 150),
                ("rr", 156),
                ("rs", 162),
                ("rz", 168),
                ("ss", 180),
                ("th", 186),
                ("x", 192),
                ("xx", 198),
                ("z", 207),
                ("zz", 216)],
            KKree => [("b", 5),
                ("g", 11),
                ("d", 15),
                ("gh", 20),
                ("gr", 25),
                ("k", 57),
                ("kr", 72),
                ("l", 82),
                ("m", 87),
                ("n", 97),
                ("ng", 112),
                ("p", 117),
                ("r", 159),
                ("rr", 181),
                ("t", 196),
                ("x", 211),
                ("xk", 216)],
            Vargr => [("dh", 5),
                ("dz", 10),
                ("g", 25),
                ("gh", 35),
                ("ghz", 40),
                ("gz", 45),
                ("k", 55),
                ("kh", 65),
                ("khs", 70),
                ("ks", 76),
                ("l", 86),
                ("ll", 91),
                ("n", 116),
                ("ng", 141),
                ("r", 156),
                ("rr", 171),
                ("rrg", 176),
                ("rrgh", 181),
                ("rs", 186),
                ("rz", 191),
                ("s", 196),
                ("th", 201),
                ("ts", 106),
                ("z", 216)],
            Vilani => [("r", 75),
                ("n", 102),
                ("m", 139),
                ("sh", 165),
                ("g", 180),
                ("s", 191),
                ("d", 204),
                ("p", 210),
                ("k", 216)],
            Zhodani => [("b", 2),
                ("bl", 9),
                ("br", 16),
                ("ch", 21),
                ("d", 25),
                ("dl", 32),
                ("dr", 39),
                ("f", 44),
                ("fl", 49),
                ("fr", 54),
                ("j", 58),
                ("k", 60),
                ("kl", 64),
                ("kr", 66),
                ("l", 78),
                ("m", 80),
                ("n", 82),
                ("nch", 89),
                ("nj", 94),
                ("ns", 99),
                ("nsh", 106),
                ("nt", 110),
                ("nts", 114),
                ("nz", 119),
                ("nzh", 126),
                ("p", 128),
                ("pl", 135),
                ("pr", 142),
                ("q", 144),
                ("ql", 146),
                ("qr", 148),
                ("r", 153),
                ("sh", 160),
                ("t", 164),
                ("ts", 171),
                ("tl", 180),
                ("v", 185),
                ("vl", 189),
                ("vr", 194),
                ("z", 203),
                ("zh", 210),
                ("\'", 216)],
            Hiver => [("c", 12),
                ("ck", 18),
                ("d", 21),
                ("f", 27),
                ("ft", 30),
                ("g", 33),
                ("h", 36),
                ("k", 39),
                ("l", 57),
                ("ld", 60),
                ("m", 66),
                ("n", 102),
                ("nsk", 105),
                ("nt", 108),
                ("p", 114),
                ("phl", 117),
                ("q", 126),
                ("r", 149),
                ("rk", 151),
                ("rn", 157),
                ("rt", 159),
                ("s", 162),
                ("sk", 174),
                ("st", 177),
                ("t", 192),
                ("th", 195),
                ("v", 198),
                ("x", 216)],
            AelYael => [("l", 216)],
            NeoIcelandic => [("b", 3),
                ("d", 12),
                ("dd", 13),
                ("f", 15),
                ("g", 27),
                ("gg", 29),
                ("gn", 30),
                ("gs", 31),
                ("gt", 32),
                ("k", 44),
                ("kk", 49),
                ("ks", 50),
                ("kt", 51),
                ("l", 72),
                ("ld", 73),
                ("ll", 74),
                ("lm", 75),
                ("lp", 76),
                ("lt", 78),
                ("lv", 79),
                ("m", 85),
                ("n", 110),
                ("nd", 112),
                ("ndt", 113),
                ("ng", 126),
                ("nn", 131),
                ("nsk", 132),
                ("nt", 134),
                ("p", 139),
                ("psk", 140),
                ("r", 170),
                ("rd", 173),
                ("rk", 174),
                ("rsk", 175),
                ("rt", 177),
                ("rv", 178),
                ("s", 182),
                ("sk", 184),
                ("sp", 185),
                ("st", 187),
                ("t", 210),
                ("tt", 215),
                ("v", 216)],
            Bwap => [("-", 72),
                ("b", 150),
                ("s", 174),
                ("t", 186),
                ("th", 198),
                ("k", 204),
                ("r", 210),
                ("p", 216)],
            Kehuu => [("d", 8),
                ("h", 22),
                ("k", 29),
                ("l", 46),
                ("m", 50),
                ("n", 84),
                ("p", 98),
                ("r", 105),
                ("s", 135),
                ("t", 156),
                ("v", 167),
                ("z", 171),
                ("ll", 182),
                ("mm", 189),
                ("nn", 196),
                ("nj", 206),
                ("ss", 209),
                ("tt", 216)],
            Ushi => [("c", 6),
                ("ch", 14),
                ("ck", 18),
                ("ct", 22),
                ("d", 28),
                ("f", 32),
                ("gh", 40),
                ("l", 48),
                ("lk", 54),
                ("ll", 60),
                ("lm", 64),
                ("lp", 70),
                ("lt", 76),
                ("m", 82),
                ("mm", 84),
                ("n", 90),
                ("nd", 96),
                ("ng", 106),
                ("nn", 111),
                ("nt", 121),
                ("nj", 122),
                ("p", 126),
                ("r", 130),
                ("rd", 132),
                ("rk", 136),
                ("rm", 140),
                ("rn", 144),
                ("rp", 148),
                ("rs", 154),
                ("rt", 160),
                ("s", 168),
                ("sk", 174),
                ("ss", 182),
                ("st", 188),
                ("t", 194),
                ("th", 200),
                ("tt", 204),
                ("w", 208),
                ("wn", 213),
                ("v", 214),
                ("x", 215),
                ("z", 216)],
            Loes => [("b", 4),
                ("c", 10),
                ("ch", 18),
                ("ck", 22),
                ("ct", 26),
                ("d", 32),
                ("f", 36),
                ("gh", 44),
                ("hn", 54),
                ("l", 60),
                ("lk", 66),
                ("lf", 72),
                ("lm", 76),
                ("lb", 82),
                ("lt", 88),
                ("m", 96),
                ("mp", 102),
                ("n", 108),
                ("nd", 114),
                ("ng", 120),
                ("p", 126),
                ("r", 132),
                ("rd", 138),
                ("rk", 140),
                ("rm", 144),
                ("rn", 148),
                ("rp", 152),
                ("rs", 158),
                ("rt", 164),
                ("s", 172),
                ("sk", 178),
                ("ss", 182),
                ("st", 186),
                ("t", 194),
                ("th", 200),
                ("v", 206),
                ("w", 209),
                ("wn", 214),
                ("z", 216)],
            Galanglic => [("c", 10),
                ("ch", 15),
                ("d", 29),
                ("k", 34),
                ("l", 66),
                ("ll", 70),
                ("m", 80),
                ("n", 138),
                ("nd", 142),
                ("p", 151),
                ("r", 178),
                ("rb", 182),
                ("rs", 186),
                ("rt", 190),
                ("s", 200),
                ("st", 205),
                ("tw", 209),
                ("v", 213),
                ("z", 216)],
            _ => throw new ArgumentOutOfRangeException(nameof(languageType)),
        };
    }

    static Syllable[] BuildInitialConsonants(LanguageType languageType)
    {
        return languageType switch
        {
            Aslan => [("f", 12),
                ("ft", 22),
                ("h", 40),
                ("hf", 45),
                ("hk", 57),
                ("hl", 65),
                ("hr", 72),
                ("ht", 84),
                ("hw", 89),
                ("k", 106),
                ("kh", 121),
                ("kht", 132),
                ("kt", 142),
                ("l", 147),
                ("r", 154),
                ("s", 164),
                ("st", 171),
                ("t", 191),
                ("tl", 196),
                ("tr", 201),
                ("w", 216)],
            Darrian => [("b", 17),
                ("d", 39),
                ("g", 46),
                ("p", 58),
                ("t", 66),
                ("th", 73),
                ("k", 78),
                ("m", 88),
                ("n", 110),
                ("z", 132),
                ("l", 142),
                ("r", 156),
                ("y", 162),
                ("zb", 166),
                ("zd", 171),
                ("zg", 174),
                ("zl", 177),
                ("mb", 182),
                ("nd", 187),
                ("ngg", 190),
                ("ry", 195),
                ("ly", 198),
                ("ny", 204),
                ("lz", 209),
                ("ld", 216)],
            Droyne => [("b", 8),
                ("br", 12),
                ("d", 24),
                ("dr", 29),
                ("f", 42),
                ("h", 55),
                ("k", 68),
                ("kr", 71),
                ("l", 20),
                ("m", 94),
                ("n", 108),
                ("p", 120),
                ("pr", 122),
                ("r", 133),
                ("s", 157),
                ("ss", 167),
                ("st", 170),
                ("t", 180),
                ("th", 186),
                ("tr", 189),
                ("ts", 198),
                ("tw", 207),
                ("v", 216)],
            Ithklur => [("d", 12),
                ("f", 24),
                ("g", 30),
                ("gh", 36),
                ("h", 42),
                ("hz", 48),
                ("j", 54),
                ("jj", 60),
                ("jz", 66),
                ("k", 75),
                ("kk", 80),
                ("kl", 85),
                ("ks", 90),
                ("kz", 95),
                ("l", 102),
                ("ll", 105),
                ("mm", 111),
                ("n", 117),
                ("q", 126),
                ("r", 130),
                ("rr", 136),
                ("rs", 139),
                ("rz", 142),
                ("s", 148),
                ("ss", 156),
                ("th", 165),
                ("tr", 170),
                ("x", 183),
                ("xx", 195),
                ("z", 201),
                ("zz", 207),
                ("\'", 216)],
            KKree => [("b", 2),
                ("g", 10),
                ("gh", 24),
                ("gn", 33),
                ("gr", 37),
                ("gz", 39),
                ("hk", 43),
                ("k", 96),
                ("kr", 118),
                ("kt", 120),
                ("l", 131),
                ("m", 135),
                ("mb", 137),
                ("n", 147),
                ("p", 149),
                ("r", 175),
                ("rr", 182),
                ("t", 197),
                ("tr", 201),
                ("x", 210),
                ("xk", 212),
                ("xr", 214),
                ("xt", 216)],
            Vargr => [("d", 9),
                ("dh", 18),
                ("dz", 23),
                ("f", 30),
                ("g", 48),
                ("gh", 59),
                ("gn", 62),
                ("gv", 69),
                ("gz", 73),
                ("k", 91),
                ("kf", 96),
                ("kh", 107),
                ("kn", 113),
                ("ks", 120),
                ("l", 124),
                ("ll", 132),
                ("n", 139),
                ("ng", 144),
                ("r", 155),
                ("rr", 163),
                ("s", 174),
                ("t", 181),
                ("th", 190),
                ("ts", 194),
                ("v", 204),
                ("z", 216)],
            Vilani => [("k", 39),
                ("g", 78),
                ("m", 99),
                ("d", 120),
                ("l", 141),
                ("sh", 162),
                ("kh", 180),
                ("n", 190),
                ("s", 200),
                ("p", 204),
                ("b", 208),
                ("z", 212),
                ("r", 216)],
            Zhodani => [("b", 6),
                ("bl", 8),
                ("br", 13),
                ("ch", 25),
                ("cht", 32),
                ("d", 41),
                ("dl", 48),
                ("dr", 53),
                ("f", 58),
                ("fl", 61),
                ("fr", 64),
                ("j", 71),
                ("jd", 76),
                ("k", 81),
                ("kl", 83),
                ("kr", 85),
                ("l", 88),
                ("m", 90),
                ("n", 98),
                ("p", 105),
                ("pl", 112),
                ("pr", 115),
                ("q", 117),
                ("ql", 119),
                ("qr", 121),
                ("r", 126),
                ("s", 133),
                ("sh", 140),
                ("sht", 147),
                ("t", 152),
                ("st", 159),
                ("tl", 169),
                ("ts", 172),
                ("v", 177),
                ("vl", 179),
                ("vr", 181),
                ("y", 184),
                ("z", 189),
                ("zd", 199),
                ("zh", 206),
                ("zhd", 216)],
            Hiver => [("bl", 6),
                ("c", 12),
                ("d", 24),
                ("dr", 30),
                ("f", 36),
                ("g", 54),
                ("gl", 58),
                ("h", 62),
                ("k", 86),
                ("kl", 90),
                ("l", 102),
                ("ld", 105),
                ("ly", 108),
                ("m", 116),
                ("n", 138),
                ("p", 150),
                ("phl", 158),
                ("q", 162),
                ("r", 171),
                ("s", 174),
                ("sl", 180),
                ("sp", 186),
                ("t", 192),
                ("th", 195),
                ("tr", 202),
                ("v", 206),
                ("w", 208),
                ("wr", 214),
                ("z", 216)],
            AelYael => [("h", 54), ("j", 72), ("l", 90), ("y", 216)],
            NeoIcelandic => [("b", 12),
                ("bl", 14),
                ("br", 16),
                ("d", 31),
                ("f", 45),
                ("fl", 46),
                ("fr", 47),
                ("g", 51),
                ("gj", 52),
                ("gr", 54),
                ("h", 61),
                ("j", 67),
                ("k", 78),
                ("kj", 79),
                ("kl", 81),
                ("l", 97),
                ("m", 108),
                ("n", 120),
                ("p", 128),
                ("pr", 129),
                ("r", 145),
                ("s", 160),
                ("sj", 161),
                ("sk", 164),
                ("sl", 166),
                ("sm", 167),
                ("sn", 168),
                ("sp", 170),
                ("st", 175),
                ("sv", 177),
                ("t", 196),
                ("tr", 200),
                ("v", 216)],
            Bwap => [("p", 42),
                ("w", 108),
                ("s", 132),
                ("t", 156),
                ("d", 162),
                ("k", 192),
                ("b", 207),
                ("f", 216)],
            Kehuu => [("c", 8),
                ("d", 15),
                ("h", 33),
                ("j", 44),
                ("k", 68),
                ("l", 82),
                ("m", 112),
                ("n", 120),
                ("p", 131),
                ("r", 138),
                ("s", 160),
                ("t", 190),
                ("v", 201),
                ("kk", 205),
                ("ll", 212),
                ("ss", 216)],
            Ushi => [("b", 8),
                ("bl", 15),
                ("br", 20),
                ("c", 28),
                ("cl", 23),
                ("cr", 38),
                ("d", 46),
                ("dr", 50),
                ("f", 58),
                ("fl", 62),
                ("fr", 66),
                ("g", 71),
                ("gl", 73),
                ("gr", 76),
                ("h", 84),
                ("j", 87),
                ("k", 93),
                ("kk", 96),
                ("l", 104),
                ("m", 112),
                ("n", 118),
                ("p", 122),
                ("pl", 126),
                ("pr", 130),
                ("qu", 131),
                ("r", 139),
                ("s", 149),
                ("ss", 153),
                ("st", 159),
                ("t", 173),
                ("th", 181),
                ("tr", 187),
                ("tw", 189),
                ("v", 192),
                ("w", 196),
                ("wh", 205),
                ("wr", 214),
                ("ll", 216)],
            Loes => [("b", 8),
                ("bl", 10),
                ("br", 16),
                ("c", 27),
                ("ch", 31),
                ("cl", 37),
                ("cr", 41),
                ("d", 54),
                ("dr", 60),
                ("f", 73),
                ("fl", 77),
                ("fr", 81),
                ("g", 84),
                ("gl", 88),
                ("gr", 92),
                ("gw", 95),
                ("h", 104),
                ("j", 107),
                ("k", 115),
                ("kl", 119),
                ("l", 127),
                ("m", 131),
                ("mk", 132),
                ("n", 138),
                ("p", 146),
                ("ph", 152),
                ("pl", 154),
                ("pr", 158),
                ("r", 165),
                ("s", 171),
                ("sl", 179),
                ("st", 185),
                ("t", 189),
                ("th", 197),
                ("tr", 203),
                ("tw", 206),
                ("v", 209),
                ("w", 212),
                ("z", 216)],
            Galanglic => [("b", 5),
                ("c", 15),
                ("ch", 18),
                ("d", 23),
                ("f", 33),
                ("fr", 36),
                ("g", 48),
                ("gh", 51),
                ("h", 59),
                ("j", 64),
                ("k", 69),
                ("kn", 72),
                ("l", 80),
                ("m", 92),
                ("n", 107),
                ("p", 120),
                ("phl", 121),
                ("q", 125),
                ("r", 140),
                ("s", 152),
                ("sh", 155),
                ("st", 158),
                ("t", 176),
                ("th", 184),
                ("tr", 187),
                ("v", 192),
                ("w", 200),
                ("wh", 203),
                ("y", 211),
                ("z", 216)],
            _ => throw new ArgumentOutOfRangeException(nameof(languageType)),
        };
    }

    static Syllable[] BuildVowels(LanguageType languageType)
    {
        return languageType switch
        {
            Aslan => [("a", 41),
                ("ai", 52),
                ("ao", 60),
                ("au", 64),
                ("e", 90),
                ("ea", 114),
                ("ei", 127),
                ("i", 143),
                ("iy", 155),
                ("o", 163),
                ("oa", 167),
                ("oi", 175),
                ("ou", 180),
                ("u", 184),
                ("ua", 188),
                ("ui", 195),
                ("ya", 200),
                ("ye", 208),
                ("yo", 212),
                ("yu", 216)],
            Darrian => [("a", 47),
                ("e", 94),
                ("eh", 123),
                ("i", 152),
                ("ih", 175),
                ("o", 204),
                ("u", 216)],
            Droyne => [("a", 24),
                ("ay", 42),
                ("e", 84),
                ("i", 114),
                ("o", 138),
                ("oy", 150),
                ("u", 189),
                ("ya", 198),
                ("yo", 205),
                ("yu", 216)],
            Ithklur => [("a", 30),
                ("aa", 36),
                ("ae", 42),
                ("e", 66),
                ("ee", 72),
                ("i", 102),
                ("ii", 117),
                ("o", 144),
                ("ou", 150),
                ("u", 174),
                ("ue", 186),
                ("uu", 196),
                ("y", 201),
                ("yu", 204),
                ("yy", 207),
                ("\'t\'", 216)],
            KKree => [("a", 68),
                ("aa", 75),
                ("e", 86),
                ("ee", 100),
                ("i", 122),
                ("ii", 129),
                ("o", 133),
                ("oo", 140),
                ("u", 162),
                ("uu", 169),
                ("\'", 197),
                ("!", 208),
                ("!!", 212),
                ("!\'", 216)],
            Vargr => [("a", 42),
                ("ae", 76),
                ("e", 92),
                ("i", 102),
                ("o", 136),
                ("oe", 152),
                ("ou", 168),
                ("u", 192),
                ("ue", 216)],
            Vilani => [("a", 67),
                ("e", 84),
                ("i", 143),
                ("u", 183),
                ("aa", 192),
                ("ii", 208),
                ("uu", 216)],
            Zhodani => [("a", 43),
                ("e", 105),
                ("i", 140),
                ("ia", 168),
                ("ie", 192),
                ("o", 210),
                ("r", 216)],
            Hiver => [("a", 72),
                ("e", 108),
                ("i", 138),
                ("o", 168),
                ("oo", 180),
                ("u", 204),
                ("ua", 212),
                ("y", 216)],
            AelYael => [("ae", 66),
                ("a", 116),
                ("e", 166),
                ("i", 200),
                ("u", 216)],
            NeoIcelandic => [("au", 1),
                ("ie", 2),
                ("øy", 4),
                ("ø", 11),
                ("æ", 13),
                ("å", 18),
                ("a", 60),
                ("e", 126),
                ("i", 168),
                ("o", 193),
                ("u", 207),
                ("y", 216)],
            Bwap => [("a", 132),
                ("e", 204),
                ("o", 216)],
            Kehuu => [("a", 63),
                ("e", 105),
                ("i", 144),
                ("o", 173),
                ("u", 188),
                ("y", 192),
                ("aa", 196),
                ("ai", 198),
                ("ee", 204),
                ("ii", 206),
                ("ia", 208),
                ("ie", 210),
                ("oo", 212),
                ("oi", 214),
                ("uu", 216)],
            Ushi => [("a", 52),
                ("ai", 54),
                ("aa", 56),
                ("ia", 58),
                ("ay", 68),
                ("e", 133),
                ("i", 145),
                ("ii", 147),
                ("o", 162),
                ("oo", 167),
                ("ou", 178),
                ("oy", 188),
                ("u", 203),
                ("uu", 208),
                ("uy", 214),
                ("y", 216)],
            Loes => [("a", 54),
                ("e", 95),
                ("i", 128),
                ("o", 153),
                ("oe", 163),
                ("oo", 173),
                ("ou", 183),
                ("u", 214),
                ("y", 216)],
            Galanglic => [("a", 38),
                ("ae", 41),
                ("e", 111),
                ("i", 145),
                ("ie", 148),
                ("io", 151),
                ("o", 187),
                ("ou", 194),
                ("u", 206),
                ("ua", 209),
                ("y", 216)],
            _ => throw new ArgumentOutOfRangeException(nameof(languageType)),
        };
    }

    static string GetCapitalizedWord(LanguageType languageType, Dice dice)
    {
        var name = GetWord(languageType, dice);
        return char.ToUpperInvariant(name[0]) + name[1..];
    }

    static string GetRandomLetter(Syllable[] letters, Dice dice)
    {
        var r = dice.D(216);

        for (var i = 0; i < letters.Length; i++)
            if (r <= letters[i].Frequency)
                return letters[i].Value;

        throw new ArgumentException(nameof(letters) + " doesn't have the necessary frequency");
    }

    static string GetRandomSyllable(Syllable[] syllables, Dice dice)
    {
        var r = dice.D(36);

        for (var i = 0; i < syllables.Length; i++)
            if (r <= syllables[i].Frequency)
                return syllables[i].Value;

        throw new ArgumentException(nameof(syllables) + " doesn't have the necessary frequency");
    }

    static string GetWord(LanguageType languageType, Dice dice)
    {
        var basicSyllables = BasicSyllables[languageType];
        var alternateSyllables = AlternateSyllables[languageType];
        var initialConsonants = InitialConsonants[languageType];
        var finalConsonants = FinalConsonants[languageType];
        var vowels = Vowels[languageType];

        var randomSyllables = GetRandomSyllable(basicSyllables, dice);

        var result = "";
        var syllableCount = RandomNumberOfSyllables(languageType, dice);

        for (var i = 0; i < syllableCount; i++)
        {
            result += MakeSyllable(randomSyllables, vowels, initialConsonants, finalConsonants, dice);

            if (randomSyllables[^1] == 'v')
                randomSyllables = GetRandomSyllable(basicSyllables, dice);
            else
                randomSyllables = GetRandomSyllable(alternateSyllables, dice);
        }
        return result;
    }

    static string MakeSyllable(string sylcode, Syllable[] vowels, Syllable[] initconst, Syllable[] finalconst, Dice dice)
    {
        var results = "";

        for (var i = 0; i < sylcode.Length; i++)
        {
            results += sylcode[i] switch
            {
                'v' => GetRandomLetter(vowels, dice),
                'c' when i == 0 => GetRandomLetter(initconst, dice),
                'c' => GetRandomLetter(finalconst, dice),
                _ => ""
            };
        }
        return results;
    }

    static int RandomNumberOfSyllables(LanguageType langtype, Dice dice)
    {
        var result = 1;
        var maxsyllables = langtype switch
        {
            AelYael or Ushi => 3,
            Kehuu => 5,
            _ => 4,
        };

        if (maxsyllables > 1)
            result += dice.D(2) - 1;
        if (maxsyllables > 2)
            result += dice.D(2) - 1;
        if (maxsyllables > 3)
            result += dice.D(2) - 1;
        if (maxsyllables > 4)
            result += dice.D(2) - 1;
        if (maxsyllables > 5)
            result += dice.D(2) - 1;
        if (maxsyllables > 6)
            result += dice.D(2) - 1;

        return result;
    }

    static IEnumerable<LanguageType> SupportedLanguages() => Enumerable.Range(1, 16).Cast<LanguageType>();

    record struct Syllable(string Value, int Frequency)
    {
        public static implicit operator Syllable(ValueTuple<string, int> v) => new Syllable(v.Item1, v.Item2);
    }
}
