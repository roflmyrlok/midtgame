using BoardGameModel;

namespace GameNewStaffProvider;

public static class NewStaffProcider
{
	static List<Creature> NewCreatureProvide()
	{
		var _creatures = new List<Creature>();
		_creatures.Add(new Scorpion(1));
		_creatures.Add(new Troll(1));
		return _creatures;
	}

	static List<Spell> NewSpellProvider()
	{
		var spells = new List<Spell>();
		return spells;
	}
	
	
}