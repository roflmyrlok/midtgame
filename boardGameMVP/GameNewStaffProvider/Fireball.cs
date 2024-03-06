using BoardGameModel;

namespace GameNewStaffProvider;

public class Fireball : Spell
{
	public override void Act(List<Creature> enemies, List<Creature> allies)
	{
		var rand = new Random().Next(0, enemies.Capacity);
		enemies[rand].ReciveDmg(3, allies, enemies);
	}
}