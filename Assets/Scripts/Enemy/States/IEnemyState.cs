// IEnemyState.cs
public interface IEnemyState
{
	void Enter(Enemy enemy);
	void Execute();
	void Exit();
}
