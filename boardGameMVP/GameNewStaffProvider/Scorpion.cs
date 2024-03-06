using BoardGameModel;

namespace GameNewStaffProvider;

public class Scorpion : Creature
{
	public Scorpion(int id) : base(id)
	{
		Health = 3;
		Attack = 8;
	}

	public override void Act(List<Creature> enemies, List<Creature> alies)
	{
		if (Dead)
		{
			return;
		}
		var rand = new Random().Next(0, enemies.Capacity - 1);
		enemies[rand].ReciveDmg(this.Attack * 2, alies, enemies);
	}
}