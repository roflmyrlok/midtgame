using BoardGameModel;

namespace GameNewStaffProvider;

public class Heal : Spell
{
	public override void Act(List<Creature> enemies, List<Creature> allies)
	{
		foreach (var cr in allies)
		{
			cr.Health += 2;
			if (cr.Health >= 1 & cr.Dead)
			{
				cr.Dead = false;
			}
		}
	}
}