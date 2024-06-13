using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeGroundSaver : MonoBehaviour
{
    [SerializeField] private float saveFrequency = 3f;

    public Vector2 SafeGroundLocation {get; private set;} = Vector2.zero;

    private Coroutine safeGroundCoroutine;
    private GroundCheck groundCheck;
	private void Start()
	{
        groundCheck = GetComponent<GroundCheck>();
		safeGroundCoroutine = StartCoroutine(SaveGroundlocation());
        SafeGroundLocation = transform.position;
	}
	private IEnumerator SaveGroundlocation() 
    {
        float elapsedTime = 0f;
        while (elapsedTime < saveFrequency) 
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        if (groundCheck.IsGrounded()) 
        {
            Debug.Log("Salvadou a posição");
		    SafeGroundLocation = transform.position;
        }


        safeGroundCoroutine = StartCoroutine(SaveGroundlocation());

	}

    public void WarpPlayerToSafeGround() 
    {
        Debug.Log("Deu tp no personagem");
        transform.position = SafeGroundLocation;
    }
}
