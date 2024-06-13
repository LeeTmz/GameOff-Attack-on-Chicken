using UnityEngine;

public class Enemy : MonoBehaviour
{
	private IEnemyState currentState;
	private Animator animator;

	public Transform Target { get; private set; }

	public float moveSpeed = 2f;
	public float chaseDistance = 5f;
	public float attackRange = 1f;
	public float patrolRange = 3f;

	private void Start()
	{
		animator = GetComponent<Animator>();
		Target = GameObject.FindWithTag("Player").transform;
		ChangeState(new IdleState());
	}

	private void Update()
	{
		currentState.Execute();
	}

	public void ChangeState(IEnemyState newState)
	{
		if (currentState != null)
		{
			currentState.Exit();
		}

		currentState = newState;
		currentState.Enter(this);

		Debug.Log(currentState);
	}

	public void SetAnimation(string animationName)
	{
		animator.Play(animationName);
	}
	void OnDrawGizmosSelected()
	{
		// Draw a yellow sphere at the transform's position
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position,chaseDistance);

		// Draw a yellow sphere at the transform's position
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, attackRange);

		// Draw a yellow sphere at the transform's position
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, patrolRange);
	}
}
