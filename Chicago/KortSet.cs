using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chicago
{
    static class KortSet
    {
        // ett par, två par,Triss , Fyrtal, Kåk, Stege, Färg, Färg Stege, Royal Flush, Royal Straight Flush
        public static List<string> OmvandlaKortlek(List<string> kortlek)
        {
            List<string> omvandlad = new List<string>();
            foreach (string s in kortlek)
            {
                char c = s[1];
                if (Char.IsDigit(c)) omvandlad.Add(s);
                else
                {
                    switch (c)
                    {
                        case 'T': omvandlad.Add(s[0].ToString() + "10"); break;
                        case 'J': omvandlad.Add(s[0].ToString() + "11"); break;
                        case 'Q': omvandlad.Add(s[0].ToString() + "12"); break;
                        case 'K': omvandlad.Add(s[0].ToString() + "13"); break;
                        case 'A': omvandlad.Add(s[0].ToString() + "14"); break;
                    }
                }
            }
            return omvandlad;
        }
        private static int GetNumber(string kort)
        {
            return int.Parse(kort.Substring(1));
        }

        private static string GetColor(string kort)
        {
            return kort[0].ToString();
        }
        private static bool RoyalStraightFlush(List<string> spelarhand)
        {
            int längd = 5;
            var sortedHand = spelarhand.OrderBy(card => GetNumber(card));
            var sekvens = sortedHand.Select((card, index) => new { Card = card, Index = index })
                                    .GroupBy(pair => new { Number = GetNumber(pair.Card) - pair.Index, Color = GetColor(pair.Card) })
                                    .Where(group => group.All(pair => GetNumber(pair.Card) >= 10 && GetNumber(pair.Card) <= 14) && group.Count() >= längd)
                                    .SelectMany(group => group.Select(pair => pair.Card).Take(längd));
            if (sekvens.Any()) return true;
            else return false;
        }
        private static bool StraightFlush(List<string> spelarhand)
        {
            int längd = 5;
            var sortedHand = spelarhand.OrderBy(card => GetNumber(card));
            var sekvens = sortedHand.Select((card, index) => new { Card = card, Index = index })
                        .GroupBy(pair => new { Number = GetNumber(pair.Card) - pair.Index, Color = GetColor(pair.Card) })
                        .Where(group => group.Count() >= längd)
                        .SelectMany(group => group.Select(pair => pair.Card).Take(längd));
            if (sekvens.Any()) return true;
            else return false;
        }

        private static bool Fyrtal(List<string> spelarhand)
        {
            int längd = 4;
            var sortedHand = spelarhand.OrderBy(card => GetNumber(card));

            var groups = sortedHand.GroupBy(card => GetNumber(card));

            bool hasFourOfAKind = groups.Any(group => group.Count() >= längd);

            return hasFourOfAKind;
        }

        private static bool Kåk(List<string> spelarhand)
        {
            int längd = 5;
            var sortedHand = spelarhand.OrderBy(card => GetNumber(card));

            var groups = sortedHand.Select((card, index) => new { Card = card, Number = GetNumber(card) })
                                   .GroupBy(pair => pair.Number)
                                   .Where(group => group.Count() >= 2);

            bool hasThreeOfAKind = false;
            bool hasPair = false;

            foreach (var group in groups)
            {
                if (group.Count() == 3)
                {
                    hasThreeOfAKind = true;
                }
                else if (group.Count() == 2)
                {
                    hasPair = true;
                }
            }

            bool hasCorrectCombination = hasThreeOfAKind && hasPair;

            return hasCorrectCombination;
        }
        private static bool Färg(List<string> spelarhand)
        {
            int längd = 5;
            var sekvens = spelarhand.Select((card, index) => new { Card = card, Index = index })
                                    .GroupBy(pair => GetColor(pair.Card))
                                    .Where(group => group.Count() >= längd && group.Count() == group.Select(pair => pair.Card).Distinct().Count())
                                    .SelectMany(group => group.Select(pair => pair.Card).Take(längd));
            if (sekvens.Any()) return true;
            else return false;
        }

        private static bool Stege(List<string> spelarhand)
        {
            int längd = 5;
            var sortedHand = spelarhand.OrderBy(card => GetNumber(card));
            var sekvens = sortedHand.Select((card, index) => new { Card = card, Index = index })
                                    .GroupBy(pair => GetNumber(pair.Card) - pair.Index)
                                    .Where(group => group.Count() >= längd)
                                    .SelectMany(group => group.Select(pair => pair.Card).Take(längd));

            if (sekvens.Any()) return true;
            else return false;
        }

        private static bool Triss(List<string> spelarhand)
        {
            int längd = 3;
            var sortedHand = spelarhand.OrderBy(card => GetNumber(card));

            var groups = sortedHand.GroupBy(card => GetNumber(card));

            bool hasFourOfAKind = groups.Any(group => group.Count() >= längd);

            return hasFourOfAKind;
        }
        private static bool TvåPar(List<string> spelarhand)
        {
            int längd = 5;
            var sortedHand = spelarhand.OrderBy(card => GetNumber(card));

            var groups = sortedHand.Select((card, index) => new { Card = card, Number = GetNumber(card) })
                                   .GroupBy(pair => pair.Number)
                                   .Where(group => group.Count() == 2);

            int twoCardGroupCount = groups.Count();

            bool hasTwoDifferentCombinations = twoCardGroupCount >= 2;

            return hasTwoDifferentCombinations;
        }

        private static bool Par(List<string> spelarhand)
        {
            int längd = 2;
            var sortedHand = spelarhand.OrderBy(card => GetNumber(card));

            var groups = sortedHand.GroupBy(card => GetNumber(card));

            bool hasFourOfAKind = groups.Any(group => group.Count() >= längd);

            return hasFourOfAKind;
        }
        public static int KollaKombinationer(List<string> spelarhand)
        {
            if (RoyalStraightFlush(spelarhand)) return 9;
            else if (StraightFlush(spelarhand)) return 8;
            else if (Fyrtal(spelarhand)) return 7;
            else if (Kåk(spelarhand)) return 6;
            else if (Färg(spelarhand)) return 5;
            else if (Stege(spelarhand)) return 4;
            else if (Triss(spelarhand)) return 3;
            else if (TvåPar(spelarhand)) return 2;
            else if (Par(spelarhand)) return 1;
            else return 0;
        }
    }
}
