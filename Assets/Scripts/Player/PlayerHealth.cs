using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, Idamageable
{
	[Header("Life Configuration")]
	[SerializeField] private float maxHealth = 5f;
	[SerializeField] private float currentLife;

	[Header("Sound Configuration")]
	[SerializeField] private AudioClip[] damageSoundClips;

	private SpriteRenderer spriteRenderer;

	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		currentLife = maxHealth;
	}

	public void Damage(float damgeAmount)
	{
		currentLife -= damgeAmount;
		StartCoroutine(ColorColision());

		//SFX		
		SoundFXManager.instance.PlayRandomSoundFXClip(damageSoundClips, transform, 1f);

		if (currentLife <= 0)
		{
			Die();
		}
	}
	public void Die()
	{
		Destroy(gameObject);
	}

	IEnumerator ColorColision()
	{
		spriteRenderer.color = Color.red;
		yield return new WaitForSeconds(0.1f);
		spriteRenderer.color = Color.white;
	}
}
