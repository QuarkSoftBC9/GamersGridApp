using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Core.ApiAcountsDtos
{
    public class Awards
    {
        public double cards { get; set; }
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsSilver { get; set; }
        public double medalsGold { get; set; }
    }

    public class Assists
    {
        public double defensiveAssists { get; set; }
        public double healingDone { get; set; }
        public double offensiveAssists { get; set; }
    }

    public class Average
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double healingDoneAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best
    {
        public double allDamageDoneMostInGame { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double defensiveAssistsMostInGame { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double healingDoneMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double killsStreakBest { get; set; }
        public double multikillsBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double offensiveAssistsMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
    }

    public class Combat
    {
        public double barrierDamageDone { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double multikills { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public double soloKills { get; set; }
        public string timeSpentOnFire { get; set; }
    }

    public class Game
    {
        public double gamesLost { get; set; }
        public double gamesPlayed { get; set; }
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards
    {
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class AllHeroes
    {
        public Assists assists { get; set; }
        public Average average { get; set; }
        public Best best { get; set; }
        public Combat combat { get; set; }
        public object deaths { get; set; }
        public object heroSpecific { get; set; }
        public Game game { get; set; }
        public MatchAwards matchAwards { get; set; }
        public object miscellaneous { get; set; }
    }

    public class Assists2
    {
        public double defensiveAssists { get; set; }
        public double defensiveAssistsAvgPer10Min { get; set; }
        public double defensiveAssistsMostInGame { get; set; }
        public double healingDone { get; set; }
        public double healingDoneMostInGame { get; set; }
        public double offensiveAssists { get; set; }
        public double offensiveAssistsAvgPer10Min { get; set; }
        public double offensiveAssistsMostInGame { get; set; }
    }

    public class Average2
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double healingDoneAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
    }

    public class Best2
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat2
    {
        public double barrierDamageDone { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific
    {
        public double bioticGrenadeKills { get; set; }
        public double enemiesSlept { get; set; }
        public double enemiesSleptAvgPer10Min { get; set; }
        public double enemiesSleptMostInGame { get; set; }
        public double healingAmplified { get; set; }
        public double healingAmplifiedAvgPer10Min { get; set; }
        public double healingAmplifiedMostInGame { get; set; }
        public double nanoBoostAssists { get; set; }
        public double nanoBoostAssistsAvgPer10Min { get; set; }
        public double nanoBoostAssistsMostInGame { get; set; }
        public double nanoBoostsApplied { get; set; }
        public double nanoBoostsAppliedAvgPer10Min { get; set; }
        public double nanoBoostsAppliedMostInGame { get; set; }
        public string scopedAccuracy { get; set; }
        public string scopedAccuracyBestInGame { get; set; }
        public double selfHealing { get; set; }
        public double selfHealingAvgPer10Min { get; set; }
        public double selfHealingMostInGame { get; set; }
        public string unscopedAccuracy { get; set; }
        public string unscopedAccuracyBestInGame { get; set; }
    }

    public class Game2
    {
        public double gamesLost { get; set; }
        public double gamesPlayed { get; set; }
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
        public string winPercentage { get; set; }
    }

    public class MatchAwards2
    {
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Ana
    {
        public Assists2 assists { get; set; }
        public Average2 average { get; set; }
        public Best2 best { get; set; }
        public Combat2 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific heroSpecific { get; set; }
        public Game2 game { get; set; }
        public MatchAwards2 matchAwards { get; set; }
        public object miscellaneous { get; set; }
    }

    public class Average3
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double criticalHitsAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best3
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double criticalHitsMostInGame { get; set; }
        public double criticalHitsMostInLife { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat3
    {
        public double barrierDamageDone { get; set; }
        public double criticalHits { get; set; }
        public string criticalHitsAccuracy { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public string quickMeleeAccuracy { get; set; }
        public double soloKills { get; set; }
        public string timeSpentOnFire { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific2
    {
        public double dragonstrikeKills { get; set; }
        public double dragonstrikeKillsAvgPer10Min { get; set; }
        public double dragonstrikeKillsMostInGame { get; set; }
        public double stormArrowKills { get; set; }
        public double stormArrowKillsAvgPer10Min { get; set; }
        public double stormArrowKillsMostInGame { get; set; }
    }

    public class Game3
    {
        public double gamesLost { get; set; }
        public double gamesPlayed { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards3
    {
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
    }

    public class Hanzo
    {
        public object assists { get; set; }
        public Average3 average { get; set; }
        public Best3 best { get; set; }
        public Combat3 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific2 heroSpecific { get; set; }
        public Game3 game { get; set; }
        public MatchAwards3 matchAwards { get; set; }
        public object miscellaneous { get; set; }
    }

    public class Average4
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double criticalHitsAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
    }

    public class Best4
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double criticalHitsMostInGame { get; set; }
        public double criticalHitsMostInLife { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat4
    {
        public double barrierDamageDone { get; set; }
        public double criticalHits { get; set; }
        public string criticalHitsAccuracy { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double heroDamageDone { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class Game4
    {
        public double gamesLost { get; set; }
        public double gamesPlayed { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards4
    {
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
    }

    public class Mccree
    {
        public object assists { get; set; }
        public Average4 average { get; set; }
        public Best4 best { get; set; }
        public Combat4 combat { get; set; }
        public object deaths { get; set; }
        public object heroSpecific { get; set; }
        public Game4 game { get; set; }
        public MatchAwards4 matchAwards { get; set; }
        public object miscellaneous { get; set; }
    }

    public class Assists3
    {
        public double defensiveAssists { get; set; }
        public double defensiveAssistsAvgPer10Min { get; set; }
        public double defensiveAssistsMostInGame { get; set; }
        public double healingDone { get; set; }
        public double healingDoneMostInGame { get; set; }
    }

    public class Average5
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double healingDoneAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best5
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double multikillsBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
    }

    public class Combat5
    {
        public double barrierDamageDone { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double multikills { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public string quickMeleeAccuracy { get; set; }
        public string timeSpentOnFire { get; set; }
    }

    public class HeroSpecific3
    {
        public double coalescenceHealing { get; set; }
        public double coalescenceHealingAvgPer10Min { get; set; }
        public double coalescenceHealingMostInGame { get; set; }
        public double coalescenceKills { get; set; }
        public double coalescenceKillsAvgPer10Min { get; set; }
        public double coalescenceKillsMostInGame { get; set; }
        public string secondaryFireAccuracy { get; set; }
        public double selfHealing { get; set; }
        public double selfHealingAvgPer10Min { get; set; }
        public double selfHealingMostInGame { get; set; }
    }

    public class Game5
    {
        public double gamesLost { get; set; }
        public double gamesPlayed { get; set; }
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
        public string winPercentage { get; set; }
    }

    public class MatchAwards5
    {
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Moira
    {
        public Assists3 assists { get; set; }
        public Average5 average { get; set; }
        public Best5 best { get; set; }
        public Combat5 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific3 heroSpecific { get; set; }
        public Game5 game { get; set; }
        public MatchAwards5 matchAwards { get; set; }
        public object miscellaneous { get; set; }
    }

    public class Average6
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
    }

    public class Best6
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat6
    {
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double heroDamageDone { get; set; }
        public string objectiveTime { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific4
    {
        public double healthRecovered { get; set; }
        public double healthRecoveredAvgPer10Min { get; set; }
        public double healthRecoveredMostInGame { get; set; }
        public double selfHealing { get; set; }
        public double selfHealingAvgPer10Min { get; set; }
        public double selfHealingMostInGame { get; set; }
    }

    public class Game6
    {
        public double gamesLost { get; set; }
        public double gamesPlayed { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards6
    {
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
    }

    public class Tracer
    {
        public object assists { get; set; }
        public Average6 average { get; set; }
        public Best6 best { get; set; }
        public Combat6 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific4 heroSpecific { get; set; }
        public Game6 game { get; set; }
        public MatchAwards6 matchAwards { get; set; }
        public object miscellaneous { get; set; }
    }

    public class Assists4
    {
        public double defensiveAssists { get; set; }
        public double defensiveAssistsAvgPer10Min { get; set; }
        public double defensiveAssistsMostInGame { get; set; }
        public double healingDone { get; set; }
        public double healingDoneMostInGame { get; set; }
        public double offensiveAssists { get; set; }
        public double offensiveAssistsAvgPer10Min { get; set; }
        public double offensiveAssistsMostInGame { get; set; }
    }

    public class Average7
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double criticalHitsAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double healingDoneAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
    }

    public class Best7
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double criticalHitsMostInGame { get; set; }
        public double criticalHitsMostInLife { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat7
    {
        public double barrierDamageDone { get; set; }
        public double criticalHits { get; set; }
        public string criticalHitsAccuracy { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double heroDamageDone { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific5
    {
        public double selfHealing { get; set; }
        public double selfHealingAvgPer10Min { get; set; }
        public double selfHealingMostInGame { get; set; }
        public double transcendenceHealing { get; set; }
        public double transcendenceHealingBest { get; set; }
    }

    public class Game7
    {
        public double gamesLost { get; set; }
        public double gamesPlayed { get; set; }
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
        public string winPercentage { get; set; }
    }

    public class MatchAwards7
    {
        public double medals { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Zenyatta
    {
        public Assists4 assists { get; set; }
        public Average7 average { get; set; }
        public Best7 best { get; set; }
        public Combat7 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific5 heroSpecific { get; set; }
        public Game7 game { get; set; }
        public MatchAwards7 matchAwards { get; set; }
        public object miscellaneous { get; set; }
    }

    public class CareerStats
    {
        public AllHeroes allHeroes { get; set; }
        public Ana ana { get; set; }
        public Hanzo hanzo { get; set; }
        public Mccree mccree { get; set; }
        public Moira moira { get; set; }
        public Tracer tracer { get; set; }
        public Zenyatta zenyatta { get; set; }
    }

    public class Games
    {
        public double played { get; set; }
        public double won { get; set; }
    }

    public class Ana2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Hanzo2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Mccree2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Moira2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Tracer2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Zenyatta2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class TopHeroes
    {
        public Ana2 ana { get; set; }
        public Hanzo2 hanzo { get; set; }
        public Mccree2 mccree { get; set; }
        public Moira2 moira { get; set; }
        public Tracer2 tracer { get; set; }
        public Zenyatta2 zenyatta { get; set; }
    }

    public class CompetitiveStats
    {
        public Awards awards { get; set; }
        public CareerStats careerStats { get; set; }
        public Games games { get; set; }
        public TopHeroes topHeroes { get; set; }
    }

    public class Awards2
    {
        public double cards { get; set; }
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsSilver { get; set; }
        public double medalsGold { get; set; }
    }

    public class Assists5
    {
        public double defensiveAssists { get; set; }
        public double healingDone { get; set; }
        public double offensiveAssists { get; set; }
        public double reconAssists { get; set; }
    }

    public class Average8
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double healingDoneAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best8
    {
        public double allDamageDoneMostInGame { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double defensiveAssistsMostInGame { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double environmentalKillsMostInGame { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double healingDoneMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double killsStreakBest { get; set; }
        public double meleeFinalBlowsMostInGame { get; set; }
        public double multikillsBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double offensiveAssistsMostInGame { get; set; }
        public double reconAssistsMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public double teleporterPadsDestroyedMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
        public double turretsDestroyedMostInGame { get; set; }
    }

    public class Combat8
    {
        public double barrierDamageDone { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double environmentalKills { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double meleeFinalBlows { get; set; }
        public double multikills { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public double soloKills { get; set; }
        public string timeSpentOnFire { get; set; }
    }

    public class Game8
    {
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards8
    {
        public double cards { get; set; }
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Miscellaneous
    {
        public double teleporterPadsDestroyed { get; set; }
        public double turretsDestroyed { get; set; }
    }

    public class AllHeroes2
    {
        public Assists5 assists { get; set; }
        public Average8 average { get; set; }
        public Best8 best { get; set; }
        public Combat8 combat { get; set; }
        public object deaths { get; set; }
        public object heroSpecific { get; set; }
        public Game8 game { get; set; }
        public MatchAwards8 matchAwards { get; set; }
        public Miscellaneous miscellaneous { get; set; }
    }

    public class Assists6
    {
        public double defensiveAssists { get; set; }
        public double defensiveAssistsAvgPer10Min { get; set; }
        public double defensiveAssistsMostInGame { get; set; }
        public double healingDone { get; set; }
        public double healingDoneMostInGame { get; set; }
        public double offensiveAssists { get; set; }
        public double offensiveAssistsAvgPer10Min { get; set; }
        public double offensiveAssistsMostInGame { get; set; }
    }

    public class Average9
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double healingDoneAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double meleeFinalBlowsAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best9
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double meleeFinalBlowsMostInGame { get; set; }
        public double multikillsBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat9
    {
        public double barrierDamageDone { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double meleeFinalBlows { get; set; }
        public double multikills { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public string quickMeleeAccuracy { get; set; }
        public double soloKills { get; set; }
        public string timeSpentOnFire { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific6
    {
        public double bioticGrenadeKills { get; set; }
        public double enemiesSlept { get; set; }
        public double enemiesSleptAvgPer10Min { get; set; }
        public double enemiesSleptMostInGame { get; set; }
        public double healingAmplified { get; set; }
        public double healingAmplifiedAvgPer10Min { get; set; }
        public double healingAmplifiedMostInGame { get; set; }
        public double nanoBoostAssists { get; set; }
        public double nanoBoostAssistsAvgPer10Min { get; set; }
        public double nanoBoostAssistsMostInGame { get; set; }
        public double nanoBoostsApplied { get; set; }
        public double nanoBoostsAppliedAvgPer10Min { get; set; }
        public double nanoBoostsAppliedMostInGame { get; set; }
        public string scopedAccuracy { get; set; }
        public string scopedAccuracyBestInGame { get; set; }
        public double selfHealing { get; set; }
        public double selfHealingAvgPer10Min { get; set; }
        public double selfHealingMostInGame { get; set; }
        public string unscopedAccuracy { get; set; }
        public string unscopedAccuracyBestInGame { get; set; }
    }

    public class Game9
    {
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards9
    {
        public double cards { get; set; }
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Miscellaneous2
    {
        public double teleporterPadsDestroyed { get; set; }
        public double turretsDestroyed { get; set; }
    }

    public class Ana3
    {
        public Assists6 assists { get; set; }
        public Average9 average { get; set; }
        public Best9 best { get; set; }
        public Combat9 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific6 heroSpecific { get; set; }
        public Game9 game { get; set; }
        public MatchAwards9 matchAwards { get; set; }
        public Miscellaneous2 miscellaneous { get; set; }
    }

    public class Average10
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double criticalHitsAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best10
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double criticalHitsMostInGame { get; set; }
        public double criticalHitsMostInLife { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat10
    {
        public double barrierDamageDone { get; set; }
        public double criticalHits { get; set; }
        public string criticalHitsAccuracy { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public double soloKills { get; set; }
        public string timeSpentOnFire { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific7
    {
        public double bobKills { get; set; }
        public double bobKillsAvgPer10Min { get; set; }
        public double bobKillsMostInGame { get; set; }
        public double coachGunKills { get; set; }
        public double coachGunKillsAvgPer10Min { get; set; }
        public double coachGunKillsMostInGame { get; set; }
        public double dynamiteKills { get; set; }
        public double dynamiteKillsAvgPer10Min { get; set; }
        public double dynamiteKillsMostInGame { get; set; }
        public string scopedAccuracy { get; set; }
        public string scopedAccuracyBestInGame { get; set; }
        public double scopedCriticalHits { get; set; }
        public string scopedCriticalHitsAccuracy { get; set; }
        public double scopedCriticalHitsAvgPer10Min { get; set; }
        public double scopedCriticalHitsKills { get; set; }
        public double scopedCriticalHitsKillsAvgPer10Min { get; set; }
        public double scopedCriticalHitsMostInGame { get; set; }
    }

    public class Game10
    {
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards10
    {
        public double cards { get; set; }
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Miscellaneous3
    {
        public double turretsDestroyed { get; set; }
    }

    public class Ashe
    {
        public object assists { get; set; }
        public Average10 average { get; set; }
        public Best10 best { get; set; }
        public Combat10 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific7 heroSpecific { get; set; }
        public Game10 game { get; set; }
        public MatchAwards10 matchAwards { get; set; }
        public Miscellaneous3 miscellaneous { get; set; }
    }

    public class Assists7
    {
        public double defensiveAssists { get; set; }
        public double defensiveAssistsAvgPer10Min { get; set; }
        public double defensiveAssistsMostInGame { get; set; }
        public double healingDone { get; set; }
        public double healingDoneMostInGame { get; set; }
    }

    public class Average11
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double criticalHitsAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double healingDoneAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best11
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double criticalHitsMostInGame { get; set; }
        public double criticalHitsMostInLife { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat11
    {
        public double barrierDamageDone { get; set; }
        public double criticalHits { get; set; }
        public string criticalHitsAccuracy { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public string objectiveTime { get; set; }
        public string timeSpentOnFire { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific8
    {
        public double amplificationMatrixCasts { get; set; }
        public double amplificationMatrixCastsAvgPer10Min { get; set; }
        public double amplificationMatrixCastsMostInGame { get; set; }
        public double damageAmplified { get; set; }
        public double damageAmplifiedAvgPer10Min { get; set; }
        public double damageAmplifiedMostInGame { get; set; }
        public string healingAccuracy { get; set; }
        public string healingAccuracyBestInGame { get; set; }
        public double immortalityFieldDeathsPrevented { get; set; }
        public double immortalityFieldDeathsPreventedAvgPer10Min { get; set; }
        public double immortalityFieldDeathsPreventedMostInGame { get; set; }
        public double selfHealing { get; set; }
        public double selfHealingAvgPer10Min { get; set; }
        public double selfHealingMostInGame { get; set; }
    }

    public class Game11
    {
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards11
    {
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Baptiste
    {
        public Assists7 assists { get; set; }
        public Average11 average { get; set; }
        public Best11 best { get; set; }
        public Combat11 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific8 heroSpecific { get; set; }
        public Game11 game { get; set; }
        public MatchAwards11 matchAwards { get; set; }
        public object miscellaneous { get; set; }
    }

    public class Average12
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double criticalHitsAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double healingDoneAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best12
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double criticalHitsMostInGame { get; set; }
        public double criticalHitsMostInLife { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double multikillsBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat12
    {
        public double barrierDamageDone { get; set; }
        public double criticalHits { get; set; }
        public string criticalHitsAccuracy { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double multikills { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public string quickMeleeAccuracy { get; set; }
        public double soloKills { get; set; }
        public string timeSpentOnFire { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific9
    {
        public double reconKills { get; set; }
        public double reconKillsAvgPer10Min { get; set; }
        public double reconKillsMostInGame { get; set; }
        public double selfHealing { get; set; }
        public double selfHealingAvgPer10Min { get; set; }
        public double selfHealingMostInGame { get; set; }
        public double sentryKills { get; set; }
        public double sentryKillsAvgPer10Min { get; set; }
        public double sentryKillsMostInGame { get; set; }
        public double tankKills { get; set; }
        public double tankKillsAvgPer10Min { get; set; }
        public double tankKillsMostInGame { get; set; }
    }

    public class Game12
    {
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards12
    {
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Miscellaneous4
    {
        public double turretsDestroyed { get; set; }
    }

    public class Bastion
    {
        public object assists { get; set; }
        public Average12 average { get; set; }
        public Best12 best { get; set; }
        public Combat12 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific9 heroSpecific { get; set; }
        public Game12 game { get; set; }
        public MatchAwards12 matchAwards { get; set; }
        public Miscellaneous4 miscellaneous { get; set; }
    }

    public class Assists8
    {
        public double defensiveAssists { get; set; }
        public double defensiveAssistsAvgPer10Min { get; set; }
        public double healingDone { get; set; }
        public double offensiveAssists { get; set; }
        public double offensiveAssistsAvgPer10Min { get; set; }
    }

    public class Average13
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double healingDoneAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best13
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
    }

    public class Combat13
    {
        public double barrierDamageDone { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public double soloKills { get; set; }
        public string timeSpentOnFire { get; set; }
    }

    public class HeroSpecific10
    {
        public double armorProvided { get; set; }
        public double armorProvidedAvgPer10Min { get; set; }
        public double armorProvidedMostInGame { get; set; }
        public double damageBlocked { get; set; }
        public double damageBlockedAvgPer10Min { get; set; }
        public double damageBlockedMostInGame { get; set; }
        public string inspireUptimePercentage { get; set; }
        public double selfHealing { get; set; }
        public double selfHealingAvgPer10Min { get; set; }
    }

    public class Game13
    {
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards13
    {
        public double cards { get; set; }
        public double medals { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Brigitte
    {
        public Assists8 assists { get; set; }
        public Average13 average { get; set; }
        public Best13 best { get; set; }
        public Combat13 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific10 heroSpecific { get; set; }
        public Game13 game { get; set; }
        public MatchAwards13 matchAwards { get; set; }
        public object miscellaneous { get; set; }
    }

    public class Average14
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double criticalHitsAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double healingDoneAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double meleeFinalBlowsAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best14
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double criticalHitsMostInGame { get; set; }
        public double criticalHitsMostInLife { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double meleeFinalBlowsMostInGame { get; set; }
        public double multikillsBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat14
    {
        public double barrierDamageDone { get; set; }
        public double criticalHits { get; set; }
        public string criticalHitsAccuracy { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double meleeFinalBlows { get; set; }
        public double multikills { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public string quickMeleeAccuracy { get; set; }
        public double soloKills { get; set; }
        public string timeSpentOnFire { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific11
    {
        public double damageBlocked { get; set; }
        public double damageBlockedAvgPer10Min { get; set; }
        public double damageBlockedMostInGame { get; set; }
        public double mechDeaths { get; set; }
        public double mechsCalled { get; set; }
        public double mechsCalledAvgPer10Min { get; set; }
        public double mechsCalledMostInGame { get; set; }
        public double selfDestructKills { get; set; }
        public double selfDestructKillsAvgPer10Min { get; set; }
        public double selfDestructKillsMostInGame { get; set; }
    }

    public class Game14
    {
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards14
    {
        public double cards { get; set; }
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Miscellaneous5
    {
        public double turretsDestroyed { get; set; }
    }

    public class DVa
    {
        public object assists { get; set; }
        public Average14 average { get; set; }
        public Best14 best { get; set; }
        public Combat14 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific11 heroSpecific { get; set; }
        public Game14 game { get; set; }
        public MatchAwards14 matchAwards { get; set; }
        public Miscellaneous5 miscellaneous { get; set; }
    }

    public class Average15
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best15
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat15
    {
        public double barrierDamageDone { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double environmentalKills { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public double soloKills { get; set; }
        public string timeSpentOnFire { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific12
    {
        public double abilityDamageDone { get; set; }
        public double abilityDamageDoneAvgPer10Min { get; set; }
        public double abilityDamageDoneMostInGame { get; set; }
        public double meteorStrikeKills { get; set; }
        public double meteorStrikeKillsAvgPer10Min { get; set; }
        public double meteorStrikeKillsMostInGame { get; set; }
        public double shieldsCreated { get; set; }
        public double shieldsCreatedAvgPer10Min { get; set; }
        public double shieldsCreatedMostInGame { get; set; }
    }

    public class Game15
    {
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards15
    {
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Miscellaneous6
    {
        public double turretsDestroyed { get; set; }
    }

    public class Doomfist
    {
        public object assists { get; set; }
        public Average15 average { get; set; }
        public Best15 best { get; set; }
        public Combat15 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific12 heroSpecific { get; set; }
        public Game15 game { get; set; }
        public MatchAwards15 matchAwards { get; set; }
        public Miscellaneous6 miscellaneous { get; set; }
    }

    public class Average16
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double criticalHitsAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double meleeFinalBlowsAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best16
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double criticalHitsMostInGame { get; set; }
        public double criticalHitsMostInLife { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double meleeFinalBlowsMostInGame { get; set; }
        public double multikillsBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat16
    {
        public double barrierDamageDone { get; set; }
        public double criticalHits { get; set; }
        public string criticalHitsAccuracy { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double meleeFinalBlows { get; set; }
        public double multikills { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public string quickMeleeAccuracy { get; set; }
        public double soloKills { get; set; }
        public string timeSpentOnFire { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific13
    {
        public double damageReflected { get; set; }
        public double damageReflectedAvgPer10Min { get; set; }
        public double damageReflectedMostInGame { get; set; }
        public double deflectionKills { get; set; }
        public double dragonbladesKills { get; set; }
        public double dragonbladesKillsAvgPer10Min { get; set; }
        public double dragonbladesKillsMostInGame { get; set; }
    }

    public class Game16
    {
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards16
    {
        public double cards { get; set; }
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Miscellaneous7
    {
        public double teleporterPadsDestroyed { get; set; }
        public double turretsDestroyed { get; set; }
    }

    public class Genji
    {
        public object assists { get; set; }
        public Average16 average { get; set; }
        public Best16 best { get; set; }
        public Combat16 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific13 heroSpecific { get; set; }
        public Game16 game { get; set; }
        public MatchAwards16 matchAwards { get; set; }
        public Miscellaneous7 miscellaneous { get; set; }
    }

    public class Assists9
    {
        public double reconAssists { get; set; }
        public double reconAssistsAvgPer10Min { get; set; }
        public double reconAssistsMostInGame { get; set; }
    }

    public class Average17
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double criticalHitsAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double meleeFinalBlowsAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best17
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double criticalHitsMostInGame { get; set; }
        public double criticalHitsMostInLife { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double meleeFinalBlowsMostInGame { get; set; }
        public double multikillsBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat17
    {
        public double barrierDamageDone { get; set; }
        public double criticalHits { get; set; }
        public string criticalHitsAccuracy { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double meleeFinalBlows { get; set; }
        public double multikills { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public string quickMeleeAccuracy { get; set; }
        public double soloKills { get; set; }
        public string timeSpentOnFire { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific14
    {
        public double dragonstrikeKills { get; set; }
        public double dragonstrikeKillsAvgPer10Min { get; set; }
        public double dragonstrikeKillsMostInGame { get; set; }
        public double scatterArrowKills { get; set; }
        public double scatterArrowKillsAvgPer10Min { get; set; }
        public double scatterArrowKillsMostInGame { get; set; }
        public double stormArrowKills { get; set; }
        public double stormArrowKillsAvgPer10Min { get; set; }
        public double stormArrowKillsMostInGame { get; set; }
    }

    public class Game17
    {
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards17
    {
        public double cards { get; set; }
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Miscellaneous8
    {
        public double turretsDestroyed { get; set; }
    }

    public class Hanzo3
    {
        public Assists9 assists { get; set; }
        public Average17 average { get; set; }
        public Best17 best { get; set; }
        public Combat17 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific14 heroSpecific { get; set; }
        public Game17 game { get; set; }
        public MatchAwards17 matchAwards { get; set; }
        public Miscellaneous8 miscellaneous { get; set; }
    }

    public class Assists10
    {
        public double offensiveAssists { get; set; }
        public double offensiveAssistsAvgPer10Min { get; set; }
        public double offensiveAssistsMostInGame { get; set; }
    }

    public class Average18
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best18
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat18
    {
        public double barrierDamageDone { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public double soloKills { get; set; }
        public string timeSpentOnFire { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific15
    {
        public double concussionMineKills { get; set; }
        public double concussionMineKillsAvgPer10Min { get; set; }
        public double concussionMineKillsMostInGame { get; set; }
        public double enemiesTrapped { get; set; }
        public double enemiesTrappedAvgPer10Min { get; set; }
        public double enemiesTrappedMostInGame { get; set; }
        public double ripTireKills { get; set; }
        public double ripTireKillsAvgPer10Min { get; set; }
        public double ripTireKillsMostInGame { get; set; }
    }

    public class Game18
    {
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards18
    {
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Miscellaneous9
    {
        public double turretsDestroyed { get; set; }
    }

    public class Junkrat
    {
        public Assists10 assists { get; set; }
        public Average18 average { get; set; }
        public Best18 best { get; set; }
        public Combat18 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific15 heroSpecific { get; set; }
        public Game18 game { get; set; }
        public MatchAwards18 matchAwards { get; set; }
        public Miscellaneous9 miscellaneous { get; set; }
    }

    public class Assists11
    {
        public double defensiveAssists { get; set; }
        public double defensiveAssistsAvgPer10Min { get; set; }
        public double defensiveAssistsMostInGame { get; set; }
        public double healingDone { get; set; }
        public double healingDoneMostInGame { get; set; }
        public double offensiveAssists { get; set; }
        public double offensiveAssistsAvgPer10Min { get; set; }
        public double offensiveAssistsMostInGame { get; set; }
    }

    public class Average19
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double criticalHitsAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double healingDoneAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double meleeFinalBlowsAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best19
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double criticalHitsMostInGame { get; set; }
        public double criticalHitsMostInLife { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double meleeFinalBlowsMostInGame { get; set; }
        public double multikillsBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat19
    {
        public double barrierDamageDone { get; set; }
        public double criticalHits { get; set; }
        public string criticalHitsAccuracy { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double environmentalKills { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double meleeFinalBlows { get; set; }
        public double multikills { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public string quickMeleeAccuracy { get; set; }
        public double soloKills { get; set; }
        public string timeSpentOnFire { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific16
    {
        public double selfHealing { get; set; }
        public double selfHealingAvgPer10Min { get; set; }
        public double selfHealingMostInGame { get; set; }
        public double soundBarriersProvided { get; set; }
        public double soundBarriersProvidedAvgPer10Min { get; set; }
        public double soundBarriersProvidedMostInGame { get; set; }
    }

    public class Game19
    {
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards19
    {
        public double cards { get; set; }
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Miscellaneous10
    {
        public double turretsDestroyed { get; set; }
    }

    public class Lucio
    {
        public Assists11 assists { get; set; }
        public Average19 average { get; set; }
        public Best19 best { get; set; }
        public Combat19 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific16 heroSpecific { get; set; }
        public Game19 game { get; set; }
        public MatchAwards19 matchAwards { get; set; }
        public Miscellaneous10 miscellaneous { get; set; }
    }

    public class Average20
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double criticalHitsAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double meleeFinalBlowsAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best20
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double criticalHitsMostInGame { get; set; }
        public double criticalHitsMostInLife { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double meleeFinalBlowsMostInGame { get; set; }
        public double multikillsBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat20
    {
        public double barrierDamageDone { get; set; }
        public double criticalHits { get; set; }
        public string criticalHitsAccuracy { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double meleeFinalBlows { get; set; }
        public double multikills { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public string quickMeleeAccuracy { get; set; }
        public double soloKills { get; set; }
        public string timeSpentOnFire { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific17
    {
        public double deadeyeKills { get; set; }
        public double deadeyeKillsAvgPer10Min { get; set; }
        public double deadeyeKillsMostInGame { get; set; }
        public double fanTheHammerKills { get; set; }
        public double fanTheHammerKillsAvgPer10Min { get; set; }
        public double fanTheHammerKillsMostInGame { get; set; }
    }

    public class Game20
    {
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards20
    {
        public double cards { get; set; }
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Miscellaneous11
    {
        public double turretsDestroyed { get; set; }
    }

    public class Mccree3
    {
        public object assists { get; set; }
        public Average20 average { get; set; }
        public Best20 best { get; set; }
        public Combat20 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific17 heroSpecific { get; set; }
        public Game20 game { get; set; }
        public MatchAwards20 matchAwards { get; set; }
        public Miscellaneous11 miscellaneous { get; set; }
    }

    public class Assists12
    {
        public double offensiveAssists { get; set; }
        public double offensiveAssistsAvgPer10Min { get; set; }
        public double offensiveAssistsMostInGame { get; set; }
    }

    public class Average21
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double criticalHitsAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double healingDoneAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
    }

    public class Best21
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double criticalHitsMostInGame { get; set; }
        public double criticalHitsMostInLife { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat21
    {
        public double barrierDamageDone { get; set; }
        public double criticalHits { get; set; }
        public string criticalHitsAccuracy { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public string quickMeleeAccuracy { get; set; }
        public double soloKills { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific18
    {
        public double blizzardKills { get; set; }
        public double blizzardKillsAvgPer10Min { get; set; }
        public double blizzardKillsMostInGame { get; set; }
        public double damageBlocked { get; set; }
        public double damageBlockedAvgPer10Min { get; set; }
        public double damageBlockedMostInGame { get; set; }
        public double enemiesFrozen { get; set; }
        public double enemiesFrozenAvgPer10Min { get; set; }
        public double enemiesFrozenMostInGame { get; set; }
        public double selfHealing { get; set; }
        public double selfHealingAvgPer10Min { get; set; }
        public double selfHealingMostInGame { get; set; }
    }

    public class Game21
    {
        public string timePlayed { get; set; }
    }

    public class MatchAwards21
    {
        public double cards { get; set; }
        public double medalBronze { get; set; }
        public double medals { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Miscellaneous12
    {
        public double turretsDestroyed { get; set; }
    }

    public class Mei
    {
        public Assists12 assists { get; set; }
        public Average21 average { get; set; }
        public Best21 best { get; set; }
        public Combat21 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific18 heroSpecific { get; set; }
        public Game21 game { get; set; }
        public MatchAwards21 matchAwards { get; set; }
        public Miscellaneous12 miscellaneous { get; set; }
    }

    public class Assists13
    {
        public double defensiveAssists { get; set; }
        public double defensiveAssistsAvgPer10Min { get; set; }
        public double defensiveAssistsMostInGame { get; set; }
        public double healingDone { get; set; }
        public double healingDoneMostInGame { get; set; }
        public double offensiveAssists { get; set; }
        public double offensiveAssistsAvgPer10Min { get; set; }
        public double offensiveAssistsMostInGame { get; set; }
    }

    public class Average22
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double criticalHitsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double healingDoneAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
    }

    public class Best22
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double criticalHitsMostInGame { get; set; }
        public double criticalHitsMostInLife { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat22
    {
        public double criticalHits { get; set; }
        public string criticalHitsAccuracy { get; set; }
        public double damageDone { get; set; }
        public double eliminations { get; set; }
        public double heroDamageDone { get; set; }
        public string objectiveTime { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific19
    {
        public double blasterKills { get; set; }
        public double blasterKillsAvgPer10Min { get; set; }
        public double blasterKillsMostInGame { get; set; }
        public double damageAmplified { get; set; }
        public double damageAmplifiedAvgPer10Min { get; set; }
        public double damageAmplifiedMostInGame { get; set; }
        public double playersResurrected { get; set; }
        public double playersResurrectedAvgPer10Min { get; set; }
        public double playersResurrectedMostInGame { get; set; }
        public double selfHealing { get; set; }
        public double selfHealingAvgPer10Min { get; set; }
        public double selfHealingMostInGame { get; set; }
    }

    public class Game22
    {
        public double gameWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards22
    {
        public double cards { get; set; }
        public double medal { get; set; }
        public double medalGold { get; set; }
    }

    public class Mercy
    {
        public Assists13 assists { get; set; }
        public Average22 average { get; set; }
        public Best22 best { get; set; }
        public Combat22 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific19 heroSpecific { get; set; }
        public Game22 game { get; set; }
        public MatchAwards22 matchAwards { get; set; }
        public object miscellaneous { get; set; }
    }

    public class Assists14
    {
        public double defensiveAssists { get; set; }
        public double defensiveAssistsAvgPer10Min { get; set; }
        public double defensiveAssistsMostInGame { get; set; }
        public double healingDone { get; set; }
        public double healingDoneMostInGame { get; set; }
    }

    public class Average23
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double healingDoneAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double meleeFinalBlowsAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best23
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double meleeFinalBlowsMostInGame { get; set; }
        public double multikillsBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
    }

    public class Combat23
    {
        public double barrierDamageDone { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double meleeFinalBlows { get; set; }
        public double multikills { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public string quickMeleeAccuracy { get; set; }
        public double soloKills { get; set; }
        public string timeSpentOnFire { get; set; }
    }

    public class HeroSpecific20
    {
        public double coalescenceHealing { get; set; }
        public double coalescenceHealingAvgPer10Min { get; set; }
        public double coalescenceHealingMostInGame { get; set; }
        public double coalescenceKills { get; set; }
        public double coalescenceKillsAvgPer10Min { get; set; }
        public double coalescenceKillsMostInGame { get; set; }
        public string secondaryFireAccuracy { get; set; }
        public double selfHealing { get; set; }
        public double selfHealingAvgPer10Min { get; set; }
        public double selfHealingMostInGame { get; set; }
    }

    public class Game23
    {
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards23
    {
        public double cards { get; set; }
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Miscellaneous13
    {
        public double teleporterPadsDestroyed { get; set; }
        public double turretsDestroyed { get; set; }
    }

    public class Moira3
    {
        public Assists14 assists { get; set; }
        public Average23 average { get; set; }
        public Best23 best { get; set; }
        public Combat23 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific20 heroSpecific { get; set; }
        public Game23 game { get; set; }
        public MatchAwards23 matchAwards { get; set; }
        public Miscellaneous13 miscellaneous { get; set; }
    }

    public class Average24
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
    }

    public class Best24
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat24
    {
        public double barrierDamageDone { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public string objectiveTime { get; set; }
        public string quickMeleeAccuracy { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific21
    {
        public double damageAmplified { get; set; }
        public double damageAmplifiedAvgPer10Min { get; set; }
        public double damageAmplifiedMostInGame { get; set; }
        public double damageBlocked { get; set; }
        public double damageBlockedAvgPer10Min { get; set; }
        public double damageBlockedMostInGame { get; set; }
    }

    public class Game24
    {
        public string timePlayed { get; set; }
    }

    public class MatchAwards24
    {
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Orisa
    {
        public object assists { get; set; }
        public Average24 average { get; set; }
        public Best24 best { get; set; }
        public Combat24 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific21 heroSpecific { get; set; }
        public Game24 game { get; set; }
        public MatchAwards24 matchAwards { get; set; }
        public object miscellaneous { get; set; }
    }

    public class Average25
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best25
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat25
    {
        public double barrierDamageDone { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double environmentalKills { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public double soloKills { get; set; }
        public string timeSpentOnFire { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific22
    {
        public double barrageKills { get; set; }
        public double barrageKillsAvgPer10Min { get; set; }
        public double barrageKillsMostInGame { get; set; }
        public string directHitsAccuracy { get; set; }
        public double rocketDirectHits { get; set; }
        public double rocketDirectHitsAvgPer10Min { get; set; }
        public double rocketDirectHitsMostInGame { get; set; }
    }

    public class Game25
    {
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards25
    {
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Miscellaneous14
    {
        public double turretsDestroyed { get; set; }
    }

    public class Pharah
    {
        public object assists { get; set; }
        public Average25 average { get; set; }
        public Best25 best { get; set; }
        public Combat25 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific22 heroSpecific { get; set; }
        public Game25 game { get; set; }
        public MatchAwards25 matchAwards { get; set; }
        public Miscellaneous14 miscellaneous { get; set; }
    }

    public class Average26
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double criticalHitsAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double healingDoneAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best26
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double criticalHitsMostInGame { get; set; }
        public double criticalHitsMostInLife { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat26
    {
        public double barrierDamageDone { get; set; }
        public double criticalHits { get; set; }
        public string criticalHitsAccuracy { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public double soloKills { get; set; }
        public string timeSpentOnFire { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific23
    {
        public double deathsBlossomKills { get; set; }
        public double deathsBlossomKillsAvgPer10Min { get; set; }
        public double deathsBlossomKillsMostInGame { get; set; }
        public double selfHealing { get; set; }
        public double selfHealingAvgPer10Min { get; set; }
        public double selfHealingMostInGame { get; set; }
    }

    public class Game26
    {
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards26
    {
        public double cards { get; set; }
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Miscellaneous15
    {
        public double turretsDestroyed { get; set; }
    }

    public class Reaper
    {
        public object assists { get; set; }
        public Average26 average { get; set; }
        public Best26 best { get; set; }
        public Combat26 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific23 heroSpecific { get; set; }
        public Game26 game { get; set; }
        public MatchAwards26 matchAwards { get; set; }
        public Miscellaneous15 miscellaneous { get; set; }
    }

    public class Assists15
    {
        public double offensiveAssists { get; set; }
        public double offensiveAssistsAvgPer10Min { get; set; }
        public double offensiveAssistsMostInGame { get; set; }
    }

    public class Average27
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best27
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double multikillsBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
    }

    public class Combat27
    {
        public double barrierDamageDone { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double environmentalKills { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double multikills { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public double soloKills { get; set; }
        public string timeSpentOnFire { get; set; }
    }

    public class HeroSpecific24
    {
        public double chargeKills { get; set; }
        public double chargeKillsAvgPer10Min { get; set; }
        public double chargeKillsMostInGame { get; set; }
        public double damageBlocked { get; set; }
        public double damageBlockedAvgPer10Min { get; set; }
        public double damageBlockedMostInGame { get; set; }
        public double earthshatterKills { get; set; }
        public double earthshatterKillsAvgPer10Min { get; set; }
        public double earthshatterKillsMostInGame { get; set; }
        public double fireStrikeKills { get; set; }
        public double fireStrikeKillsAvgPer10Min { get; set; }
        public double fireStrikeKillsMostInGame { get; set; }
        public string rocketHammerMeleeAccuracy { get; set; }
    }

    public class Game27
    {
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards27
    {
        public double cards { get; set; }
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Miscellaneous16
    {
        public double turretsDestroyed { get; set; }
    }

    public class Reinhardt
    {
        public Assists15 assists { get; set; }
        public Average27 average { get; set; }
        public Best27 best { get; set; }
        public Combat27 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific24 heroSpecific { get; set; }
        public Game27 game { get; set; }
        public MatchAwards27 matchAwards { get; set; }
        public Miscellaneous16 miscellaneous { get; set; }
    }

    public class Assists16
    {
        public double offensiveAssists { get; set; }
        public double offensiveAssistsAvgPer10Min { get; set; }
        public double offensiveAssistsMostInGame { get; set; }
    }

    public class Average28
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double criticalHitsAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double healingDoneAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double meleeFinalBlowsAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best28
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double criticalHitsMostInGame { get; set; }
        public double criticalHitsMostInLife { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double meleeFinalBlowsMostInGame { get; set; }
        public double multikillsBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat28
    {
        public double barrierDamageDone { get; set; }
        public double criticalHits { get; set; }
        public string criticalHitsAccuracy { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double environmentalKills { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double meleeFinalBlows { get; set; }
        public double multikills { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public string quickMeleeAccuracy { get; set; }
        public double soloKills { get; set; }
        public string timeSpentOnFire { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific25
    {
        public double enemiesHooked { get; set; }
        public double enemiesHookedAvgPer10Min { get; set; }
        public double enemiesHookedMostInGame { get; set; }
        public string hookAccuracy { get; set; }
        public string hookAccuracyBestInGame { get; set; }
        public double hooksAttempted { get; set; }
        public double selfHealing { get; set; }
        public double selfHealingAvgPer10Min { get; set; }
        public double selfHealingMostInGame { get; set; }
        public double wholeHogKills { get; set; }
        public double wholeHogKillsAvgPer10Min { get; set; }
        public double wholeHogKillsMostInGame { get; set; }
    }

    public class Game28
    {
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards28
    {
        public double cards { get; set; }
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Miscellaneous17
    {
        public double turretsDestroyed { get; set; }
    }

    public class Roadhog
    {
        public Assists16 assists { get; set; }
        public Average28 average { get; set; }
        public Best28 best { get; set; }
        public Combat28 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific25 heroSpecific { get; set; }
        public Game28 game { get; set; }
        public MatchAwards28 matchAwards { get; set; }
        public Miscellaneous17 miscellaneous { get; set; }
    }

    public class Assists17
    {
        public double defensiveAssists { get; set; }
        public double defensiveAssistsAvgPer10Min { get; set; }
        public double defensiveAssistsMostInGame { get; set; }
        public double healingDone { get; set; }
        public double healingDoneMostInGame { get; set; }
    }

    public class Average29
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double criticalHitsAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double healingDoneAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best29
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double criticalHitsMostInGame { get; set; }
        public double criticalHitsMostInLife { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double multikillsBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat29
    {
        public double barrierDamageDone { get; set; }
        public double criticalHits { get; set; }
        public string criticalHitsAccuracy { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double multikills { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public string quickMeleeAccuracy { get; set; }
        public double soloKills { get; set; }
        public string timeSpentOnFire { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific26
    {
        public double bioticFieldHealingDone { get; set; }
        public double bioticFieldsDeployed { get; set; }
        public double helixRocketKills { get; set; }
        public double helixRocketKillsAvgPer10Min { get; set; }
        public double helixRocketKillsMostInGame { get; set; }
        public double selfHealing { get; set; }
        public double selfHealingAvgPer10Min { get; set; }
        public double selfHealingMostInGame { get; set; }
        public double tacticalVisorKills { get; set; }
        public double tacticalVisorKillsAvgPer10Min { get; set; }
        public double tacticalVisorKillsMostInGame { get; set; }
    }

    public class Game29
    {
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards29
    {
        public double cards { get; set; }
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Miscellaneous18
    {
        public double turretsDestroyed { get; set; }
    }

    public class Soldier76
    {
        public Assists17 assists { get; set; }
        public Average29 average { get; set; }
        public Best29 best { get; set; }
        public Combat29 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific26 heroSpecific { get; set; }
        public Game29 game { get; set; }
        public MatchAwards29 matchAwards { get; set; }
        public Miscellaneous18 miscellaneous { get; set; }
    }

    public class Assists18
    {
        public double offensiveAssists { get; set; }
        public double offensiveAssistsAvgPer10Min { get; set; }
        public double offensiveAssistsMostInGame { get; set; }
    }

    public class Average30
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double criticalHitsAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double healingDoneAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best30
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat30
    {
        public double barrierDamageDone { get; set; }
        public double criticalHits { get; set; }
        public string criticalHitsAccuracy { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public double soloKills { get; set; }
        public string timeSpentOnFire { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific27
    {
        public double enemiesEmpd { get; set; }
        public double enemiesEmpdAvgPer10Min { get; set; }
        public double enemiesEmpdMostInGame { get; set; }
        public double enemiesHacked { get; set; }
        public double enemiesHackedAvgPer10Min { get; set; }
        public double enemiesHackedMostInGame { get; set; }
    }

    public class Game30
    {
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards30
    {
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Sombra
    {
        public Assists18 assists { get; set; }
        public Average30 average { get; set; }
        public Best30 best { get; set; }
        public Combat30 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific27 heroSpecific { get; set; }
        public Game30 game { get; set; }
        public MatchAwards30 matchAwards { get; set; }
        public object miscellaneous { get; set; }
    }

    public class Average31
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best31
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat31
    {
        public double barrierDamageDone { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public double soloKills { get; set; }
        public string timeSpentOnFire { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific28
    {
        public double damageBlocked { get; set; }
        public double damageBlockedAvgPer10Min { get; set; }
        public double damageBlockedMostInGame { get; set; }
        public double playersTeleported { get; set; }
        public double playersTeleportedAvgPer10Min { get; set; }
        public double playersTeleportedMostInGame { get; set; }
        public string primaryFireAccuracy { get; set; }
        public double secondaryDirectHitsAvgPer10Min { get; set; }
        public double sentryTurretsKills { get; set; }
        public double sentryTurretsKillsAvgPer10Min { get; set; }
        public double sentryTurretsKillsMostInGame { get; set; }
    }

    public class Game31
    {
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards31
    {
        public double cards { get; set; }
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Miscellaneous19
    {
        public double turretsDestroyed { get; set; }
    }

    public class Symmetra
    {
        public object assists { get; set; }
        public Average31 average { get; set; }
        public Best31 best { get; set; }
        public Combat31 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific28 heroSpecific { get; set; }
        public Game31 game { get; set; }
        public MatchAwards31 matchAwards { get; set; }
        public Miscellaneous19 miscellaneous { get; set; }
    }

    public class Average32
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double criticalHitsAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best32
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double criticalHitsMostInGame { get; set; }
        public double criticalHitsMostInLife { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat32
    {
        public double barrierDamageDone { get; set; }
        public double criticalHits { get; set; }
        public string criticalHitsAccuracy { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public double soloKills { get; set; }
        public string timeSpentOnFire { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific29
    {
        public double armorPacksCreated { get; set; }
        public double armorPacksCreatedAvgPer10Min { get; set; }
        public double armorPacksCreatedMostInGame { get; set; }
        public double moltenCoreKills { get; set; }
        public double moltenCoreKillsAvgPer10Min { get; set; }
        public double moltenCoreKillsMostInGame { get; set; }
        public double overloadKills { get; set; }
        public double overloadKillsMostInGame { get; set; }
        public double torbjornKills { get; set; }
        public double torbjornKillsAvgPer10Min { get; set; }
        public double torbjornKillsMostInGame { get; set; }
        public double turretsDamageAvgPer10Min { get; set; }
        public double turretsKills { get; set; }
        public double turretsKillsAvgPer10Min { get; set; }
        public double turretsKillsMostInGame { get; set; }
    }

    public class Game32
    {
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards32
    {
        public double cards { get; set; }
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Miscellaneous20
    {
        public double turretsDestroyed { get; set; }
    }

    public class Torbjorn
    {
        public object assists { get; set; }
        public Average32 average { get; set; }
        public Best32 best { get; set; }
        public Combat32 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific29 heroSpecific { get; set; }
        public Game32 game { get; set; }
        public MatchAwards32 matchAwards { get; set; }
        public Miscellaneous20 miscellaneous { get; set; }
    }

    public class Average33
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double criticalHitsAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double meleeFinalBlowsAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best33
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double criticalHitsMostInGame { get; set; }
        public double criticalHitsMostInLife { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double meleeFinalBlowsMostInGame { get; set; }
        public double multikillsBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat33
    {
        public double barrierDamageDone { get; set; }
        public double criticalHits { get; set; }
        public string criticalHitsAccuracy { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double meleeFinalBlows { get; set; }
        public double multikills { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public string quickMeleeAccuracy { get; set; }
        public double soloKills { get; set; }
        public string timeSpentOnFire { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific30
    {
        public double healthRecovered { get; set; }
        public double healthRecoveredAvgPer10Min { get; set; }
        public double healthRecoveredMostInGame { get; set; }
        public double pulseBombsAttached { get; set; }
        public double pulseBombsAttachedAvgPer10Min { get; set; }
        public double pulseBombsAttachedMostInGame { get; set; }
        public double pulseBombsKills { get; set; }
        public double pulseBombsKillsAvgPer10Min { get; set; }
        public double pulseBombsKillsMostInGame { get; set; }
        public double selfHealing { get; set; }
        public double selfHealingAvgPer10Min { get; set; }
        public double selfHealingMostInGame { get; set; }
    }

    public class Game33
    {
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards33
    {
        public double cards { get; set; }
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Miscellaneous21
    {
        public double turretsDestroyed { get; set; }
    }

    public class Tracer3
    {
        public object assists { get; set; }
        public Average33 average { get; set; }
        public Best33 best { get; set; }
        public Combat33 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific30 heroSpecific { get; set; }
        public Game33 game { get; set; }
        public MatchAwards33 matchAwards { get; set; }
        public Miscellaneous21 miscellaneous { get; set; }
    }

    public class Assists19
    {
        public double reconAssists { get; set; }
        public double reconAssistsAvgPer10Min { get; set; }
        public double reconAssistsMostInGame { get; set; }
    }

    public class Average34
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double criticalHitsAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best34
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double criticalHitsMostInGame { get; set; }
        public double criticalHitsMostInLife { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat34
    {
        public double barrierDamageDone { get; set; }
        public double criticalHits { get; set; }
        public string criticalHitsAccuracy { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public string quickMeleeAccuracy { get; set; }
        public double soloKills { get; set; }
        public string timeSpentOnFire { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific31
    {
        public string scopedAccuracy { get; set; }
        public string scopedAccuracyBestInGame { get; set; }
        public double scopedCriticalHits { get; set; }
        public string scopedCriticalHitsAccuracy { get; set; }
        public double scopedCriticalHitsAvgPer10Min { get; set; }
        public double scopedCriticalHitsMostInGame { get; set; }
        public double venomMineKills { get; set; }
        public double venomMineKillsAvgPer10Min { get; set; }
        public double venomMineKillsMostInGame { get; set; }
    }

    public class Game34
    {
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards34
    {
        public double cards { get; set; }
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Miscellaneous22
    {
        public double turretsDestroyed { get; set; }
    }

    public class Widowmaker
    {
        public Assists19 assists { get; set; }
        public Average34 average { get; set; }
        public Best34 best { get; set; }
        public Combat34 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific31 heroSpecific { get; set; }
        public Game34 game { get; set; }
        public MatchAwards34 matchAwards { get; set; }
        public Miscellaneous22 miscellaneous { get; set; }
    }

    public class Average35
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double meleeFinalBlowsAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best35
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double meleeFinalBlowsMostInGame { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
    }

    public class Combat35
    {
        public double barrierDamageDone { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double meleeFinalBlows { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public string quickMeleeAccuracy { get; set; }
        public string timeSpentOnFire { get; set; }
    }

    public class HeroSpecific32
    {
        public double damageBlocked { get; set; }
        public double damageBlockedAvgPer10Min { get; set; }
        public double damageBlockedMostInGame { get; set; }
        public double jumpKills { get; set; }
        public double jumpPackKills { get; set; }
        public double jumpPackKillsAvgPer10Min { get; set; }
        public double jumpPackKillsMostInGame { get; set; }
        public double meleeKills { get; set; }
        public double meleeKillsAvgPer10Min { get; set; }
        public double meleeKillsMostInGame { get; set; }
        public double playersKnockedBack { get; set; }
        public double playersKnockedBackAvgPer10Min { get; set; }
        public double playersKnockedBackMostInGame { get; set; }
        public double primalRageKills { get; set; }
        public double primalRageKillsAvgPer10Min { get; set; }
        public double primalRageKillsMostInGame { get; set; }
        public string primalRageMeleeAccuracy { get; set; }
        public string teslaCannonAccuracy { get; set; }
        public double weaponKills { get; set; }
    }

    public class Game35
    {
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards35
    {
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Miscellaneous23
    {
        public double turretsDestroyed { get; set; }
    }

    public class Winston
    {
        public object assists { get; set; }
        public Average35 average { get; set; }
        public Best35 best { get; set; }
        public Combat35 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific32 heroSpecific { get; set; }
        public Game35 game { get; set; }
        public MatchAwards35 matchAwards { get; set; }
        public Miscellaneous23 miscellaneous { get; set; }
    }

    public class Average36
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
    }

    public class Best36
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double multikillsBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat36
    {
        public double barrierDamageDone { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double multikills { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public double soloKills { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific33
    {
        public double grapplingClawKills { get; set; }
        public double grapplingClawKillsAvgPer10Min { get; set; }
        public double grapplingClawKillsMostInGame { get; set; }
        public double minefieldKills { get; set; }
        public double minefieldKillsAvgPer10Min { get; set; }
        public double minefieldKillsMostInGame { get; set; }
        public double playersKnockedBack { get; set; }
        public double playersKnockedBackAvgPer10Min { get; set; }
        public double playersKnockedBackMostInGame { get; set; }
    }

    public class Game36
    {
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards36
    {
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Miscellaneous24
    {
        public double turretsDestroyed { get; set; }
    }

    public class WreckingBall
    {
        public object assists { get; set; }
        public Average36 average { get; set; }
        public Best36 best { get; set; }
        public Combat36 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific33 heroSpecific { get; set; }
        public Game36 game { get; set; }
        public MatchAwards36 matchAwards { get; set; }
        public Miscellaneous24 miscellaneous { get; set; }
    }

    public class Assists20
    {
        public double defensiveAssists { get; set; }
        public double defensiveAssistsAvgPer10Min { get; set; }
        public double defensiveAssistsMostInGame { get; set; }
        public double offensiveAssists { get; set; }
        public double offensiveAssistsAvgPer10Min { get; set; }
        public double offensiveAssistsMostInGame { get; set; }
    }

    public class Average37
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double meleeFinalBlowsAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best37
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double meleeFinalBlowsMostInGame { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat37
    {
        public double barrierDamageDone { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double meleeFinalBlows { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public string quickMeleeAccuracy { get; set; }
        public double soloKills { get; set; }
        public string timeSpentOnFire { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific34
    {
        public string averageEnergy { get; set; }
        public string averageEnergyBestInGame { get; set; }
        public double damageBlocked { get; set; }
        public double damageBlockedAvgPer10Min { get; set; }
        public double damageBlockedMostInGame { get; set; }
        public double gravitonSurgeKills { get; set; }
        public double gravitonSurgeKillsAvgPer10Min { get; set; }
        public double gravitonSurgeKillsMostInGame { get; set; }
        public double highEnergyKills { get; set; }
        public double highEnergyKillsAvgPer10Min { get; set; }
        public double highEnergyKillsMostInGame { get; set; }
        public string primaryFireAccuracy { get; set; }
        public double projectedBarriersApplied { get; set; }
        public double projectedBarriersAppliedAvgPer10Min { get; set; }
        public double projectedBarriersAppliedMostInGame { get; set; }
    }

    public class Game37
    {
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards37
    {
        public double cards { get; set; }
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Zarya
    {
        public Assists20 assists { get; set; }
        public Average37 average { get; set; }
        public Best37 best { get; set; }
        public Combat37 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific34 heroSpecific { get; set; }
        public Game37 game { get; set; }
        public MatchAwards37 matchAwards { get; set; }
        public object miscellaneous { get; set; }
    }

    public class Assists21
    {
        public double defensiveAssists { get; set; }
        public double defensiveAssistsAvgPer10Min { get; set; }
        public double defensiveAssistsMostInGame { get; set; }
        public double healingDone { get; set; }
        public double healingDoneMostInGame { get; set; }
        public double offensiveAssists { get; set; }
        public double offensiveAssistsAvgPer10Min { get; set; }
        public double offensiveAssistsMostInGame { get; set; }
    }

    public class Average38
    {
        public double allDamageDoneAvgPer10Min { get; set; }
        public double barrierDamageDoneAvgPer10Min { get; set; }
        public double criticalHitsAvgPer10Min { get; set; }
        public double deathsAvgPer10Min { get; set; }
        public double eliminationsAvgPer10Min { get; set; }
        public double eliminationsPerLife { get; set; }
        public double finalBlowsAvgPer10Min { get; set; }
        public double healingDoneAvgPer10Min { get; set; }
        public double heroDamageDoneAvgPer10Min { get; set; }
        public double objectiveKillsAvgPer10Min { get; set; }
        public string objectiveTimeAvgPer10Min { get; set; }
        public double soloKillsAvgPer10Min { get; set; }
        public string timeSpentOnFireAvgPer10Min { get; set; }
    }

    public class Best38
    {
        public double allDamageDoneMostInGame { get; set; }
        public double allDamageDoneMostInLife { get; set; }
        public double barrierDamageDoneMostInGame { get; set; }
        public double criticalHitsMostInGame { get; set; }
        public double criticalHitsMostInLife { get; set; }
        public double eliminationsMostInGame { get; set; }
        public double eliminationsMostInLife { get; set; }
        public double finalBlowsMostInGame { get; set; }
        public double heroDamageDoneMostInGame { get; set; }
        public double heroDamageDoneMostInLife { get; set; }
        public double killsStreakBest { get; set; }
        public double objectiveKillsMostInGame { get; set; }
        public string objectiveTimeMostInGame { get; set; }
        public double soloKillsMostInGame { get; set; }
        public string timeSpentOnFireMostInGame { get; set; }
        public string weaponAccuracyBestInGame { get; set; }
    }

    public class Combat38
    {
        public double barrierDamageDone { get; set; }
        public double criticalHits { get; set; }
        public string criticalHitsAccuracy { get; set; }
        public double damageDone { get; set; }
        public double deaths { get; set; }
        public double eliminations { get; set; }
        public double finalBlows { get; set; }
        public double heroDamageDone { get; set; }
        public double objectiveKills { get; set; }
        public string objectiveTime { get; set; }
        public string quickMeleeAccuracy { get; set; }
        public double soloKills { get; set; }
        public string timeSpentOnFire { get; set; }
        public string weaponAccuracy { get; set; }
    }

    public class HeroSpecific35
    {
        public double selfHealing { get; set; }
        public double selfHealingAvgPer10Min { get; set; }
        public double selfHealingMostInGame { get; set; }
        public double transcendenceHealing { get; set; }
        public double transcendenceHealingBest { get; set; }
    }

    public class Game38
    {
        public double gamesWon { get; set; }
        public string timePlayed { get; set; }
    }

    public class MatchAwards38
    {
        public double cards { get; set; }
        public double medals { get; set; }
        public double medalsBronze { get; set; }
        public double medalsGold { get; set; }
        public double medalsSilver { get; set; }
    }

    public class Miscellaneous25
    {
        public double turretsDestroyed { get; set; }
    }

    public class Zenyatta3
    {
        public Assists21 assists { get; set; }
        public Average38 average { get; set; }
        public Best38 best { get; set; }
        public Combat38 combat { get; set; }
        public object deaths { get; set; }
        public HeroSpecific35 heroSpecific { get; set; }
        public Game38 game { get; set; }
        public MatchAwards38 matchAwards { get; set; }
        public Miscellaneous25 miscellaneous { get; set; }
    }

    public class CareerStats2
    {
        public AllHeroes2 allHeroes { get; set; }
        public Ana3 ana { get; set; }
        public Ashe ashe { get; set; }
        public Baptiste baptiste { get; set; }
        public Bastion bastion { get; set; }
        public Brigitte brigitte { get; set; }
        public DVa dVa { get; set; }
        public Doomfist doomfist { get; set; }
        public Genji genji { get; set; }
        public Hanzo3 hanzo { get; set; }
        public Junkrat junkrat { get; set; }
        public Lucio lucio { get; set; }
        public Mccree3 mccree { get; set; }
        public Mei mei { get; set; }
        public Mercy mercy { get; set; }
        public Moira3 moira { get; set; }
        public Orisa orisa { get; set; }
        public Pharah pharah { get; set; }
        public Reaper reaper { get; set; }
        public Reinhardt reinhardt { get; set; }
        public Roadhog roadhog { get; set; }
        public Soldier76 soldier76 { get; set; }
        public Sombra sombra { get; set; }
        public Symmetra symmetra { get; set; }
        public Torbjorn torbjorn { get; set; }
        public Tracer3 tracer { get; set; }
        public Widowmaker widowmaker { get; set; }
        public Winston winston { get; set; }
        public WreckingBall wreckingBall { get; set; }
        public Zarya zarya { get; set; }
        public Zenyatta3 zenyatta { get; set; }
    }

    public class Games2
    {
        public double played { get; set; }
        public double won { get; set; }
    }

    public class Ana4
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Ashe2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Baptiste2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Bastion2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Brigitte2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class DVa2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Doomfist2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Genji2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Hanzo4
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Junkrat2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Lucio2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Mccree4
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Mei2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Mercy2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Moira4
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Orisa2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Pharah2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Reaper2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Reinhardt2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Roadhog2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Soldier762
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Sombra2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Symmetra2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Torbjorn2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Tracer4
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Widowmaker2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Winston2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class WreckingBall2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Zarya2
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class Zenyatta4
    {
        public string timePlayed { get; set; }
        public double gamesWon { get; set; }
        public double winPercentage { get; set; }
        public double weaponAccuracy { get; set; }
        public double eliminationsPerLife { get; set; }
        public double multiKillBest { get; set; }
        public double objectiveKills { get; set; }
    }

    public class TopHeroes2
    {
        public Ana4 ana { get; set; }
        public Ashe2 ashe { get; set; }
        public Baptiste2 baptiste { get; set; }
        public Bastion2 bastion { get; set; }
        public Brigitte2 brigitte { get; set; }
        public DVa2 dVa { get; set; }
        public Doomfist2 doomfist { get; set; }
        public Genji2 genji { get; set; }
        public Hanzo4 hanzo { get; set; }
        public Junkrat2 junkrat { get; set; }
        public Lucio2 lucio { get; set; }
        public Mccree4 mccree { get; set; }
        public Mei2 mei { get; set; }
        public Mercy2 mercy { get; set; }
        public Moira4 moira { get; set; }
        public Orisa2 orisa { get; set; }
        public Pharah2 pharah { get; set; }
        public Reaper2 reaper { get; set; }
        public Reinhardt2 reinhardt { get; set; }
        public Roadhog2 roadhog { get; set; }
        public Soldier762 soldier76 { get; set; }
        public Sombra2 sombra { get; set; }
        public Symmetra2 symmetra { get; set; }
        public Torbjorn2 torbjorn { get; set; }
        public Tracer4 tracer { get; set; }
        public Widowmaker2 widowmaker { get; set; }
        public Winston2 winston { get; set; }
        public WreckingBall2 wreckingBall { get; set; }
        public Zarya2 zarya { get; set; }
        public Zenyatta4 zenyatta { get; set; }
    }

    public class QuickPlayStats
    {
        public Awards2 awards { get; set; }
        public CareerStats2 careerStats { get; set; }
        public Games2 games { get; set; }
        public TopHeroes2 topHeroes { get; set; }
    }

    public class OverWatchCompleteDto
    {
        public CompetitiveStats competitiveStats { get; set; }
        public double endorsement { get; set; }
        public string endorsementIcon { get; set; }
        public int gamesWon { get; set; }
        public string icon { get; set; }
        public double level { get; set; }
        public string levelIcon { get; set; }
        public string name { get; set; }
        public double prestige { get; set; }
        public string prestigeIcon { get; set; }
        public bool @private { get; set; }
        public QuickPlayStats quickPlayStats { get; set; }
        public double rating { get; set; }
        public string ratingIcon { get; set; }
        public object ratings { get; set; }



    }
}