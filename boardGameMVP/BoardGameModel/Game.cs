using System.Xml.XPath;

namespace BoardGameModel;

public class Game
{
	private List<Creature> _fieldPlayer1 = new List<Creature>();
	private List<Creature> _fieldPlayer2 = new List<Creature>();
	private Dictionary<string, Creature> _availableCreature = new Dictionary<string, Creature>();
	private Dictionary<string, Spell> _availablespells = new Dictionary<string, Spell>();
	private int _currPlayer = 1;
	private int latestId = 1;
	bool WinCond = false;
	private IView _view;
	public Game(IView view, Dictionary<string, Creature> avaliableCreature, Dictionary<string, Spell> availablespells)
	{
		_availableCreature = avaliableCreature;
		_availablespells = availablespells;
		_view = view;
	}
	public void Act(GameAction gameAction, List<string> args)
	{
		switch (gameAction)
		{
			case GameAction.PutACreature:
				PutACreature(args);
				break;
			case GameAction.CastASpell:
				CastASpell(args);
				break;
			case GameAction.CreatureAct:
				CreatureAct(args);
				break;
			case GameAction.AttackRandomEnemy:
				AttackRandomEnemy(args);
				break;
		}
		_show();
		ClearField();
		_show();
		if (WinCond)
		{
			throw new Exception("win");
		}
	}
	private void PutACreature(List<string> args)
	{
		var newCreat = (Creature) _availableCreature[args[0]].Clone();
		newCreat._id = latestId + 1;
		latestId += 2;
		GetPlayer().Add(newCreat);
	}
	private void CastASpell(List<string> args)
	{
		var spell = _availablespells[args[0]];
		spell.Act(GetOpponent(), GetPlayer());
	}
	private void CreatureAct(List<string> args)
	{
		var field = GetPlayer();
		foreach (var cr in field)
		{
			if (args[0] == cr._id.ToString())
			{
				cr.Act(GetOpponent(),GetPlayer());
			}
		}
	}
	private void AttackRandomEnemy(List<string> args)
	{
		var field = GetPlayer();
		foreach (var cr in field)
		{
			if (args[0] == cr._id.ToString())
			{
				cr.AttackRandom(GetOpponent(), GetPlayer());
			}
		}
	}

	private void ClearField()
	{
		foreach (var creature in _fieldPlayer1)
		{
			if (creature.Dead)
			{
				_fieldPlayer1.Remove(creature);
			}
		}
		foreach (var creature in _fieldPlayer2)
		{
			if (creature.Dead)
			{
				_fieldPlayer1.Remove(creature);
			}
		}

		if (_fieldPlayer1.Count == 0 || _fieldPlayer2.Count == 0)
		{
			WinCond = true;
		}
		_show();
	}
	private void EndTurn()
	{
		if (_currPlayer == 1)
		{
			_currPlayer = 2;
		}
		if (_currPlayer == 2)
		{
			_currPlayer = 1;
		}
		_show();
		
	}
	private List<Creature> GetPlayer()
	{
		if (_currPlayer == 1)
		{
			return _fieldPlayer1;
		}
		else
		{
			return _fieldPlayer2;
		}
	}
	private List<Creature> GetOpponent()
	{
		if (_currPlayer == 2)
		{
			return _fieldPlayer1;
		}
		else
		{
			return _fieldPlayer2;
		}
	}

	private void _show()
	{
		_view.ShowChange(_fieldPlayer1, _fieldPlayer2);
	}
}