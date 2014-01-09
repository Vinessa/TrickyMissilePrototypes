using UnityEngine;
using System.Collections;

public class LavaSpriteScript : MonoBehaviour {

	public Vector3 targetPos;
	Vector3 vecToTarget;
	public float moveSpeed;
	float lifeTime;

	// Use this for initialization
	void Start () {
		targetPos = GameObject.FindGameObjectWithTag("Player").transform.position;
		vecToTarget = targetPos - transform.position;
		vecToTarget = Vector3.Normalize(vecToTarget);
		lifeTime = Random.Range(3.0f,10.0f);
		moveSpeed = Random.Range(5.0f, 10.0f);
	}
	
	// Update is called once per frame
	void Update () {
		lifeTime -= Time.deltaTime;
		if(lifeTime <= 0.0f)
			Destroy(gameObject);

		transform.Translate(vecToTarget* moveSpeed * Time.deltaTime);
	}
}
