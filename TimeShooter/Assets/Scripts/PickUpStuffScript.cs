using UnityEngine;
using System.Collections;

public class PickUpStuffScript : MonoBehaviour {

	public string[] carryableObjectsTags;
	public float reachRange;
	bool handsEmpty = true;
	public GameObject objectCarried;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(objectCarried != null)
		{
			objectCarried.transform.position = transform.position +transform.forward * 2;
		}

		if(Input.GetMouseButtonDown(2))
		{
			if(handsEmpty)
			{
				CheckForObject();
			}
			else
			{
				handsEmpty = true;
				objectCarried.transform.position = new Vector3(objectCarried.transform.position.x, 0, objectCarried.transform.position.z);
				objectCarried = null;
			}
		}
	}

	void CheckForObject()
	{
		RaycastHit rayHit;
		bool hit = Physics.Raycast(transform.position, transform.forward, out rayHit, reachRange);
		if(hit) 
		{
			Debug.DrawLine(transform.position, rayHit.point,Color.red, 1.0f);
			//Debug.Log(rayHit.collider.transform.gameObject.name);
			foreach(string tag in carryableObjectsTags)
			{
				if(rayHit.collider.tag == tag)
				{
					objectCarried = rayHit.collider.transform.gameObject;
					handsEmpty = false;
					break;
					
				}
			}
		}
		else
			Debug.DrawLine(transform.position, transform.forward*reachRange,Color.blue, 1.0f);
	}
}
