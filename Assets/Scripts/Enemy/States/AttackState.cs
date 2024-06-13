using UnityEngine;

public class AttackState : IEnemyState
{
	private Enemy enemy;
	private float attackCooldown = 0.2f;
	private float attackTimer;

	public void Enter(Enemy enemy)
	{
		this.enemy = enemy;
		attackTimer = 0;
		enemy.SetAnimation("Attack");
	}

	public void Execute()
	{
		Attack();
	}

	public void Exit() { }

	private void Attack()
	{
		attackTimer += Time.deltaTime;
		if (attackTimer >= attackCooldown)
		{
			// Execute attack logic here
			Debug.Log("Attacking the player!");

			// Reset the attack timer
			attackTimer = 0;

			// Check if the player is out of attack range after the attack
			if (Vector2.Distance(enemy.transform.position, enemy.Target.position) > enemy.attackRange)
			{
				enemy.ChangeState(new ChaseState());
			}
		}
	}
}
