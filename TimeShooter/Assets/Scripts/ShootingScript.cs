using UnityEngine;
using System.Collections;

enum Age {older, younger};


public class ShootingScript : MonoBehaviour {

	public string[] ageableObjectTags;
	public float shootRange;
	public GameObject shot;
	GameObject latestShot;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0))
		{
			latestShot = (GameObject) Instantiate(shot, transform.position, transform.rotation);
			CheckObject(Age.older);
		}
		if(Input.GetMouseButtonDown(1))
		{
			latestShot = (GameObject) Instantiate(shot, transform.position, transform.rotation);
			CheckObject(Age.younger);
		}

	
	}

	void CheckObject(Age effect)
	{
		/*if(effect == Age.older)
			Debug.Log("Older");
		else
			Debug.Log("Younger");*/

		RaycastHit rayHit;
		bool hit = Physics.Raycast(transform.position, transform.forward, out rayHit, shootRange);
		if(hit) 
		{
			Debug.DrawLine(transform.position, rayHit.point,Color.red, 1.0f);
			//Debug.Log(rayHit.collider.transform.gameObject.name);
			foreach(string tag in ageableObjectTags)
			{
				if(rayHit.collider.tag == tag)
				{
					if(effect == Age.older)
						rayHit.transform.gameObject.SendMessage("Aged", 1);
					else
						rayHit.transform.gameObject.SendMessage("Aged", -1);

					break;

				}
			}
		}
		else
			Debug.DrawLine(transform.position, transform.forward*shootRange,Color.red, 1.0f);

		latestShot.SendMessage("SetTarget", transform.forward*shootRange);
	}


}
