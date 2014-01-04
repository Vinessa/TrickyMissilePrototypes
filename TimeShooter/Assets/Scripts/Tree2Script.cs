using UnityEngine;
using System.Collections;

public class Tree2Script : MonoBehaviour {
	public Material baby;
	public Material young;
	public Material normal;
	public Material old;
	public Material superOld;

	public CapsuleCollider treeCollider;
	GameObject player;
	public GameObject[] Images;
	public GameObject acorn;
	public GameObject treePrefab;
	float treeYPos = 3.049999f;
	float acornYPos = 0;


	Ages age;

	void Start()
	{
		if(Time.realtimeSinceStartup > 2)
		{
			//acorn.SetActive(true);
			player = GameObject.FindGameObjectWithTag("Player");
			age = Ages.pre;
			Aged(0);
		}
		else
		{
			acorn.SetActive(false);
			player = GameObject.FindGameObjectWithTag("Player");
			age = (Ages) Random.Range(0,5) + 1;
			Aged(0);
		}
	}

	void Aged (int effect)
	{
		bool dead = false;
		if(effect > 0)
		{
			if(age >= Ages.superOld)
				//Destroy (this.gameObject);
				//DestroyImmediate(this.gameObject);
				dead = true;
			else
				age++;
		}
		else if (effect < 0)
		{
			if(age <= Ages.pre)
				//Destroy (this.gameObject);
				dead = true;
			else
				age--;
		}

		if(dead == false)
		{
			switch(age)
			{
			case Ages.pre:
				transform.tag = "Acorn";
				foreach(GameObject img in Images)
				{
					img.SetActive(false);
				}
				transform.position = new Vector3(transform.position.x, acornYPos, transform.position.z);
				acorn.SetActive(true);
				treeCollider.radius = 0.1f;
				treeCollider.height = 0.22f;
				treeCollider.center = new Vector3(0,0,0);
				break;

			case Ages.baby:
				transform.tag = "Tree";
				foreach(GameObject img in Images)
				{
					img.SetActive(true);
					img.renderer.material = baby;
				}
				transform.position = new Vector3(transform.position.x, treeYPos, transform.position.z);
				acorn.SetActive(false);
				treeCollider.radius = 0.19f;
				treeCollider.height = 0.44f;
				treeCollider.center = new Vector3(0,-.89f,0);
				break;
			case Ages.young:
				transform.tag = "Tree";
				foreach(GameObject img in Images)
					img.renderer.material = young;
				treeCollider.radius = .35f;
				treeCollider.height = 0.78f;
				treeCollider.center = new  Vector3(0,-.76f,0);
				break;
			case Ages.normal:
				transform.tag = "Tree";
				foreach(GameObject img in Images)
					img.renderer.material = normal;
				treeCollider.radius = .42f;
				treeCollider.height = 1.32f;
				treeCollider.center = new Vector3(0,-.41f,0);
				break;
			case Ages.old:
				transform.tag = "Tree";
				foreach(GameObject img in Images)
					img.renderer.material = old;
				treeCollider.radius = .65f;
				treeCollider.height = 2.04f;
				treeCollider.center = new Vector3(0,0f,0);
				break;
			case Ages.superOld:
				transform.tag = "Tree";
				foreach(GameObject img in Images)
					img.renderer.material = superOld;
				treeCollider.radius = 1.2f;
				treeCollider.height = 2.93f;
				treeCollider.center = new Vector3(0,0f,0);

				Vector3 acornSpawnPoint = transform.position + new Vector3(Random.Range(-1.2f, 1.2f), 0, Random.Range(-1.2f, 1.2f));
				Instantiate(treePrefab, acornSpawnPoint, treePrefab.transform.rotation );
				break;
			default:
				transform.tag = "Acorn";
				foreach(GameObject img in Images)
				{
					img.SetActive(false);
				}
				transform.position = new Vector3(transform.position.x, acornYPos, transform.position.z);
				acorn.SetActive(true);
				treeCollider.radius = 0.1f;
				treeCollider.height = 0.22f;
				treeCollider.center = new Vector3(0,0,0);
				break;
			}
		}
		if(dead)
			Destroy (this.gameObject);
	}
}
