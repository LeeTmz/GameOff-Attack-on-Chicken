using UnityEngine;

public class PatrolState : IEnemyState
{
	private Enemy enemy;
	private Vector2 patrolTarget;
	private bool movingToTarget;

	public void Enter(Enemy enemy)
	{
		this.enemy = enemy;
		SetPatrolTarget();
		movingToTarget = true;
		enemy.SetAnimation("Patrol");
	}

	public void Execute()
	{
		Patrol();
		if (Vector2.Distance(enemy.transform.position, enemy.Target.position) <= enemy.chaseDistance)
		{
			enemy.ChangeState(new ChaseState());
		}
	}

	public void Exit() { }

	private void Patrol()
	{
		if (movingToTarget)
		{
			// Move towards the patrol target
			enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, patrolTarget, enemy.moveSpeed * Time.deltaTime);

			// Check if the enemy reached the patrol target
			if (Vector2.Distance(enemy.transform.position, patrolTarget) < 0.1f)
			{
				movingToTarget = false;
				enemy.ChangeState(new IdleState());
			}

			// Rotate to face the patrol target using localScale.x
			Vector3 scale = enemy.transform.localScale;
			if (patrolTarget.x < enemy.transform.position.x)
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

	private void SetPatrolTarget()
	{
		patrolTarget = new Vector2(enemy.transform.position.x + Random.Range(-enemy.patrolRange, enemy.patrolRange), enemy.transform.position.y);
	}
}
