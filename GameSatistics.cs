using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartsGameDesign
{

    // New class so we can keep track of the game history/winners
    public class GameStatistics
    {
        public Dictionary<string, int> WinsPerPlayer { get; private set; } = new Dictionary<string, int>();
        public List<string> LastGameWinners { get; set; } = new List<string>();

        // If someone wins, we record a win to their name
        public void RecordWin(string playerName)
        {
            if (WinsPerPlayer.ContainsKey(playerName))
            {
                WinsPerPlayer[playerName]++;
            }
            else
            {
                WinsPerPlayer[playerName] = 1;
            }
        }

        // Keep track of the latest winner so we can add to the list of winners
        public void SetLastGameWinners(List<string> winners)
        {
            LastGameWinners = winners;
        }


        // This is used for the Game Stats button on the Settings page which will show the game history to the user
        public string GetStatisticsSummary()
        {
            var summary = new StringBuilder();
            summary.AppendLine("Game Statistics:");
            summary.AppendLine("\nTotal Wins:");
            foreach (var kvp in WinsPerPlayer)
            {
                summary.AppendLine($"{kvp.Key}: {kvp.Value} wins");
            }
            summary.AppendLine($"\nLast Game Winner(s): {string.Join(", ", LastGameWinners)}");
            return summary.ToString();
        }
    }

}
