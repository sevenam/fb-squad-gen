<Query Kind="Program" />

void Main()
{
	
	var numMatches = 15;
	
	for(var i = 0; i < numMatches; i++) {
		GenerateSquad();
		Console.WriteLine();
	}
	players.OrderBy(x => x.gamesplayed).Dump();
}

// You can define other methods, fields, classes and namespaces here

public static List<string> positions = new List<string> {"Keeper", "Back", "CB", "Back", "Winger", "CM", "CM", "Winger", "Forward", "Substitute", "Substitute", "Substitute" };

public static List<Player> players = new List<Player>
	{
		new Player("BRR", new() {"Keeper"}),
		new Player("HJA",  new() {"Keeper"}),
		new Player("AM",  new() {"Back", "Winger", "Substitute"}),
		new Player("ÅF", new() {"Back", "CB", "CM", "Substitute"}),
		new Player("AHT", new() {"Winger", "Back", "Forward", "Substitute"}),
		new Player("CHT", new() {"Winger", "Forward", "Substitute"}),
		new Player("DA", new() {"Back", "Substitute"}),
		new Player("EE", new() {"CM", "Winger", "Substitute"}),
		new Player("FV", new() {"Winger", "Back", "CB", "CM", "Substitute"}),
		new Player("GSR", new() {"Back", "Winger", "Substitute"}),
		new Player("JK", new() {"Back", "CB", "CM", "Winger", "Substitute"}),
		new Player("LA", new() {"Winger", "Back", "Substitute"}),
		new Player("LWA", new() {"CM", "CB", "Back", "Substitute"}),
		new Player("MBL", new() {"Forward", "Winger", "Substitute"}),
		new Player("MGB", new() {"Winger", "CM", "Substitute"}),
		new Player("SH", new() {"Back", "CB", "Winger", "Substitute"}),
		new Player("SEMB", new() {"Back", "Winger", "Forward", "Substitute"}),
		new Player("SØ", new() {"CB", "Back", "CM", "Winger", "Substitute"}),
		new Player("TKPS", new() { "Forward", "Winger", "Substitute"}),
		new Player("WBG", new() { "CM", "Winger", "Back", "Substitute"}),
		new Player("MN", new() { "Back", "Winger", "Forward", "Substitute"})
	}.OrderBy(a => Guid.NewGuid()).ToList();

public static List<SquadPosition> GenerateSquad() 
{
	var squad = new List<SquadPosition>();
	foreach (var position in positions)
	{
		var player = players.Where(x => x.positions.Contains(position)).Where(x => !squad.Select(x => x.player).ToList().Contains(x)).ToList().OrderBy(x => x.gamesplayed).First();
		squad.Add(new SquadPosition(position, player));
		players.Single(x => x.name.Equals(player.name)).gamesplayed++;
		Console.WriteLine($"{position}: {player.name}");
	}
	return squad;
}

public class Player
{
	public readonly string name;
	public readonly List<string> positions;
	public int gamesplayed;

	public Player(string name, List<string> positions, int gamesplayed = 0)
	{
		this.name = name;
		this.positions = positions;
		this.gamesplayed = gamesplayed;
	}
}

public class SquadPosition
{
	public string position;
	public Player player;
	
	public SquadPosition(string position, Player player)
	{
		this.position = position;
		this.player = player;
	}
}

