using BoardGameModel;

namespace GameNewStaffProvider;

public class Troll : Creature
{
	public Troll(int id) : base(id)
	{
		Health = 9;
		Attack = 2;
	}

	public override void Act(List<Creature> enemies, List<Creature> alies)
	{
		if (Dead)
		{
			return;
		}
		foreach (var cr in enemies)
		{
			cr.ReciveDmg(2, alies, enemies );
		}
	}
}