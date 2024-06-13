using UnityEngine;

public class IdleState : IEnemyState
{
	private float idleDuration = 2f;
	private float idleTimer;
	private Enemy enemy;

	public void Enter(Enemy enemy)
	{
		this.enemy = enemy;
		idleTimer = 0;
		enemy.SetAnimation("Idle");
	}

	public void Execute()
	{
		Idle();
		if (idleTimer >= idleDuration)
		{
			enemy.ChangeState(new PatrolState());
		}
	}

	public void Exit() { }

	private void Idle()
	{
		idleTimer += Time.deltaTime;
	}
}
