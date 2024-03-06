namespace BoardGameModel;

public class Creature
{
	public int Attack;
	public int Health;
	public int _id;
	public bool Dead = false;

	public Creature(int id)
	{
		_id = id;
	}
	public virtual void Act(List<Creature> enemies, List<Creature> allies)
	{
		if (Dead)
		{
			return;
		}
	}

	public virtual void ReciveDmg(int dmg, List<Creature> enemies, List<Creature> allies)
	{
		if (Dead)
		{
			return;
		}
		this.Health -= dmg;
		if (Health <= 0)
		{
			Dead = true;
		}
	}

	public void AttackRandom(List<Creature> enemies, List<Creature> alies)
	{
		if (Dead)
		{
			return;
		}
		var rand = new Random().Next(0, enemies.Capacity - 1);
		enemies[rand].ReciveDmg(this.Attack, alies, enemies);
	}
	
	public object Clone()
	{
		return this.MemberwiseClone();
	}
	
	
	
}