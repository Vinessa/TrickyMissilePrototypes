using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	Vector3 spawnPoint;
	Vector3 targetPosition;
	public float moveSpeed;
	// Use this for initialization
	void Start () {
		spawnPoint = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(targetPosition != Vector3.zero)
		{
			transform.position = transform.position + transform.forward *moveSpeed *Time.deltaTime; 
			if(Vector3.Distance(transform.position, targetPosition) < 5 || Vector3.Distance(spawnPoint, transform.position) > 100)
			{
				Destroy(gameObject);
			}

		}
	
	}

	void SetTarget(Vector3 newTargetPosition)
	{
		targetPosition = newTargetPosition;
	}
}
