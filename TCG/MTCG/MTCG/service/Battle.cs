using System;
using System.Collections.Generic;

namespace MonsterCardGame
{
    public class Battle
    {
        private User player1;
        private User player2;
        private Random random;

        public Battle(User player1, User player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            random = new Random();
        }

        // Starte den Kampf
        public string StartBattle()
        {
            int rounds = 0;
            string battleLog = "Battle started between " + player1.Username + " and " + player2.Username + "\n";
            while (rounds < 100 && player1.Deck.Count > 0 && player2.Deck.Count > 0)
            {
                // Zufällige Karte von jedem Spieler auswählen
                Card card1 = GetRandomCard(player1.Deck);
                Card card2 = GetRandomCard(player2.Deck);

                // Kampf zwischen den beiden Karten
                battleLog += PerformRound(card1, card2);

                rounds++;
            }

            // Prüfe, wer gewonnen hat
            if (player1.Deck.Count > 0 && player2.Deck.Count == 0)
            {
                battleLog += player1.Username + " gewinnt den Kampf!\n";
                UpdateElo(player1, player2);  // Gewinner ist player1
            }
            else if (player2.Deck.Count > 0 && player1.Deck.Count == 0)
            {
                battleLog += player2.Username + " gewinnt den Kampf!\n";
                UpdateElo(player2, player1);  // Gewinner ist player2
            }
            else
            {
                battleLog += "Der Kampf endet unentschieden.\n";
                // Kein Update des ELO bei einem Unentschieden
            }


            return battleLog;
        }

        // Eine Runde zwischen zwei Karten durchführen
        private string PerformRound(Card card1, Card card2)
        {
            string roundLog = "\nRound: " + card1.Name + " vs " + card2.Name + "\n";

            // Sonderfälle überprüfen
            if (card1.MonsterType == MonsterType.Goblin && card2.MonsterType == MonsterType.Dragon)
            {
                return roundLog + "Goblin is too afraid to attack the Dragon.\n" + card2.Name + " wins!\n";
            }
            if (card1.MonsterType == MonsterType.Wizard && card2.MonsterType == MonsterType.Orc)
            {
                return roundLog + "Wizard controls the Orc. " + card2.Name + " cannot attack!\n" + card1.Name + " wins!\n";
            }
            if (card1.MonsterType == MonsterType.Knight && card2.Type == "Spell" && card2.Element == "Water")
            {
                return roundLog + "Knight drowns from Water Spell.\n" + card2.Name + " wins!\n";
            }
            if (card1.MonsterType == MonsterType.Kraken && card2.Type == "Spell")
            {
                return roundLog + "Kraken is immune to spells.\n" + card1.Name + " wins!\n";
            }
            if (card1.MonsterType == MonsterType.FireElf && card2.MonsterType == MonsterType.Dragon)
            {
                return roundLog + "Fire Elf evades the Dragon's attack.\n" + card1.Name + " wins!\n";
            }

            // Normaler Kampf zwischen Karten (Schaden vergleichen)
            int damage1 = CalculateDamage(card1, card2);
            int damage2 = CalculateDamage(card2, card1);

            if (damage1 > damage2)
            {
                roundLog += card1.Name + " wins the round!\n";
                player2.Deck.Remove(card2);  // Karte des Verlierers wird entfernt
            }
            else if (damage2 > damage1)
            {
                roundLog += card2.Name + " wins the round!\n";
                player1.Deck.Remove(card1);
            }
            else
            {
                roundLog += "It's a draw!\n";
            }

            return roundLog;
        }

        // Schaden basierend auf Elementen berechnen
        private int CalculateDamage(Card card1, Card card2)
        {
            if (card1.Type == "Spell" || card2.Type == "Spell")
            {
                return CalculateElementEffect(card1, card2);
            }

            return card1.Damage;  // Bei reinen Monsterkämpfen wird der Schaden unverändert verglichen
        }

        // Effektivität der Elemente berücksichtigen
        private int CalculateElementEffect(Card attackingCard, Card defendingCard)
        {
            if (attackingCard.Element == "Water" && defendingCard.Element == "Fire")
            {
                return attackingCard.Damage * 2;  // Wasser ist gegen Feuer effektiv
            }
            if (attackingCard.Element == "Fire" && defendingCard.Element == "Normal")
            {
                return attackingCard.Damage * 2;  // Feuer ist gegen Normal effektiv
            }
            if (attackingCard.Element == "Normal" && defendingCard.Element == "Water")
            {
                return attackingCard.Damage * 2;  // Normal ist gegen Wasser effektiv
            }
            if (attackingCard.Element == "Fire" && defendingCard.Element == "Water")
            {
                return attackingCard.Damage / 2;  // Feuer ist gegen Wasser ineffektiv
            }
            if (attackingCard.Element == "Water" && defendingCard.Element == "Normal")
            {
                return attackingCard.Damage / 2;  // Wasser ist gegen Normal ineffektiv
            }
            if (attackingCard.Element == "Normal" && defendingCard.Element == "Fire")
            {
                return attackingCard.Damage / 2;  // Normal ist gegen Feuer ineffektiv
            }

            return attackingCard.Damage;  // Keine Änderung, wenn kein Vorteil
        }

        // Zufällige Karte aus dem Deck wählen
        private Card GetRandomCard(List<Card> deck)
        {
            int index = random.Next(deck.Count);
            return deck[index];
        }

        // ELO-Update nach dem Kampf
        private void UpdateElo(User winner, User loser)
        {
            if (winner != null)
            {
                winner.AddElo(3);
                loser.RemoveElo(5);
            }
            else
            {
                // Unentschieden, keine Änderung am ELO
            }
        }

    }
}
