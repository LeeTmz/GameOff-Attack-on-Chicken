using UnityEngine;

public class ChaseState : IEnemyState
{
	private Enemy enemy;

	public void Enter(Enemy enemy)
	{
		this.enemy = enemy;
		enemy.SetAnimation("Chase");
	}

	public void Execute()
	{
		Chase();
		if (Vector2.Distance(enemy.transform.position, enemy.Target.position) > enemy.chaseDistance)
		{
			enemy.ChangeState(new IdleState());
		}
		else if (Vector2.Distance(enemy.transform.position, enemy.Target.position) <= enemy.attackRange)
		{
			enemy.ChangeState(new AttackState());
		}
	}

	public void Exit() { }

	private void Chase()
	{
		// Move towards the player
		enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.Target.position, enemy.moveSpeed * Time.deltaTime);

		// Rotate to face the player using localScale.x
		Vector3 scale = enemy.transform.localScale;
		if (enemy.Target.position.x < enemy.transform.position.x)
		{
			scale.x = Mathf.Abs(scale.x) * -1; // Face left
		}
		else
		{
			scale.x = Mathf.Abs(scale.x); // Face right
		}
		enemy.transform.localScale = scale;
	}	
}
