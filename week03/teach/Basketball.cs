/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row
        while (!reader.EndOfData) {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = string.IsNullOrEmpty(fields[8]) ? 0 : int.Parse(fields[8]);

            if (players.ContainsKey(playerId))
            {
                players[playerId] += points;
            }
            else
            {
                players[playerId] = points;
            }
        }

        Console.WriteLine($"Players: {{{string.Join(", ", players)}}}");
        Console.WriteLine("\n==========================================");

        var sortedPlayers = players.ToArray();
        Array.Sort(sortedPlayers, (x, y) => y.Value.CompareTo(x.Value));

        var topPlayers = new string[10];
        int count = Math.Min(10, sortedPlayers.Length);

        Console.WriteLine("Top 10 Players with the Highest Total Points Scored:");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine($"{ "Player ID", -15} | { "Total Points", -12}");
        Console.WriteLine("----------------------------------------------------");

        for (int i = 0; i < count; i++)
        {
            topPlayers[i] = $"{sortedPlayers[i].Key, -15} | {sortedPlayers[i].Value, -12:N0}";


            Console.WriteLine(topPlayers[i]);
        }
    }
}