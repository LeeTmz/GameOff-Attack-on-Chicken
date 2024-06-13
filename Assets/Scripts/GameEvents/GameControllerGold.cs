using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerGold : MonoBehaviour
{
	public float goldPlayerCount;

	private void OnEnable()
	{
		GameEvents.TestActionGold += Gold;
		GameEvents.TestActionNormal += ActionNormal;
	}
	private void OnDisable()
	{
		GameEvents.TestActionGold -= Gold;
		GameEvents.TestActionNormal -= ActionNormal;
	}
	public void Gold(float value)
	{
		goldPlayerCount += value;
		Debug.Log(goldPlayerCount);
	}
	public void ActionNormal()
	{
		Debug.Log("Action acionada com sucesso");
	}
}
