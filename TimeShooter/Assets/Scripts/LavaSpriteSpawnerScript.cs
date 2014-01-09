using UnityEngine;
using System.Collections;
// System.Collections.Generic;

public class LavaSpriteSpawnerScript : MonoBehaviour {
	public GameObject laveSpritePrefab;
	GameObject[] lavaPads;
	float timeLeft;
	public float SpawnTime;
	// Use this for initialization
	void Start () {
		SpawnTime = Random.Range(30,60);
		lavaPads = GameObject.FindGameObjectsWithTag("Lava");
		Spawn();
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft-= Time.deltaTime;

		if(timeLeft <= 0)
			Spawn();
	
	}

	void Spawn()
	{
		SpawnTime = Random.Range(30,60);
		timeLeft = SpawnTime;

		int padNumber = Random.Range(0, lavaPads.Length);
		transform.position = lavaPads[padNumber].transform.position;
		Vector3 spawnPos = transform.position;
		spawnPos.y += 1;

		Instantiate(laveSpritePrefab, spawnPos, laveSpritePrefab.transform.rotation);
	}
}
