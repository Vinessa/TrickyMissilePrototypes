using UnityEngine;
using System.Collections;

enum Age {older, younger};


public class ShootingScript : MonoBehaviour {

	public string[] ageableObjectTags;
	public float shootRange;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0))
			CheckObject(Age.older);
		if(Input.GetMouseButtonDown(1))
			CheckObject(Age.younger);

	
	}

	void CheckObject(Age effect)
	{
		if(effect == Age.older)
			Debug.Log("Older");
		else
			Debug.Log("Younger");

		RaycastHit rayHit;
		bool hit = Physics.Raycast(transform.position, transform.forward, out rayHit, shootRange);
		if(hit)
		{
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
	}


}
