using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersGrid.Services.GameAPIs.LeagueOfLegends.Models
{
    public class LoLMatchesDTO
    {
        public long gameId { get; set; }
        public string platformId { get; set; }
        public long gameCreation { get; set; }
        public int gameDuration { get; set; }
        public int queueId { get; set; }
        public int mapId { get; set; }
        public int seasonId { get; set; }
        public string gameVersion { get; set; }
        public string gameMode { get; set; }
        public string gameType { get; set; }
        public List<Participant> participants { get; set; }
        public List<ParticipantIdentity> participantIdentities { get; set; }
    }

    public class Participant
    {
        public int participantId { get; set; }
        public int teamId { get; set; }
        public int championId { get; set; }
        public int spell1Id { get; set; }
        public int spell2Id { get; set; }
        public Stats stats { get; set; }
    }

    public class Player
    {
        public string platformId { get; set; }
        public string accountId { get; set; }
        public string summonerName { get; set; }
        public string summonerId { get; set; }
        public string currentPlatformId { get; set; }
        public string currentAccountId { get; set; }
        public string matchHistoryUri { get; set; }
        public int profileIcon { get; set; }
    }

    public class ParticipantIdentity
    {
        public int participantId { get; set; }
        public Player player { get; set; }
    }

    public class Stats
    {
        public int participantId { get; set; }
        public bool win { get; set; }
        public int kills { get; set; }
        public int deaths { get; set; }
        public int assists { get; set; }
        public int largestKillingSpree { get; set; }
        public int largestMultiKill { get; set; }
        public int killingSprees { get; set; }
        public int longestTimeSpentLiving { get; set; }
        public int doubleKills { get; set; }
        public int tripleKills { get; set; }
        public int quadraKills { get; set; }
        public int pentaKills { get; set; }
        public int unrealKills { get; set; }
        public int totalDamageDealt { get; set; }
        public int magicDamageDealt { get; set; }
        public int physicalDamageDealt { get; set; }
        public int trueDamageDealt { get; set; }
        public int largestCriticalStrike { get; set; }
        //public int totalDamageDealtToChampions { get; set; }
        //public int magicDamageDealtToChampions { get; set; }
        //public int physicalDamageDealtToChampions { get; set; }
        //public int trueDamageDealtToChampions { get; set; }
        //public int totalHeal { get; set; }
        //public int totalUnitsHealed { get; set; }
        //public int damageSelfMitigated { get; set; }
        //public int damageDealtToObjectives { get; set; }
        //public int damageDealtToTurrets { get; set; }
        //public int visionScore { get; set; }
        //public int timeCCingOthers { get; set; }
        //public int totalDamageTaken { get; set; }
        //public int magicalDamageTaken { get; set; }
        //public int physicalDamageTaken { get; set; }
        //public int trueDamageTaken { get; set; }
        //public int goldEarned { get; set; }
        //public int goldSpent { get; set; }
        //public int turretKills { get; set; }
        //public int inhibitorKills { get; set; }
        //public int totalMinionsKilled { get; set; }
        //public int neutralMinionsKilled { get; set; }
        //public int neutralMinionsKilledTeamJungle { get; set; }
        //public int neutralMinionsKilledEnemyJungle { get; set; }
        //public int totalTimeCrowdControlDealt { get; set; }
        //public int champLevel { get; set; }
        //public int visionWardsBoughtInGame { get; set; }
        //public int sightWardsBoughtInGame { get; set; }
        //public int wardsPlaced { get; set; }
        //public int wardsKilled { get; set; }
        //public bool firstBloodKill { get; set; }
        //public bool firstBloodAssist { get; set; }
        //public bool firstTowerKill { get; set; }
        //public bool firstTowerAssist { get; set; }
        //public bool firstInhibitorKill { get; set; }
        //public bool firstInhibitorAssist { get; set; }
        //public int combatPlayerScore { get; set; }
        //public int objectivePlayerScore { get; set; }
        //public int totalPlayerScore { get; set; }
        //public int totalScoreRank { get; set; }
    }
}
