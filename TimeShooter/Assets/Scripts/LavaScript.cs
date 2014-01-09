using UnityEngine;
using System.Collections;

public class LavaScript : MonoBehaviour {

	void OnTriggerEnter(Collider c)
	{
		//Debug.Log("hit something");
		if((c.tag == "Lava" || c.tag == "LavaSprite" ) && transform.tag == "Player")
		{
			//Debug.Log("hit Lava");
			Application.LoadLevel(0);
		}

		else if((c.tag == "Lava" || c.tag == "LavaSprite" ) && transform.tag == "Tree")
		{
			Tree2Script myTreeScript = gameObject.GetComponent<Tree2Script>();
			//myTreeScript.age = Ages.pre;
			myTreeScript.Aged(Ages.pre);
		}

		else if((c.tag == "Lava" || c.tag == "LavaSprite" ) && transform.tag == "Eagle")
		{
			Application.LoadLevel(0);
		}
	}
}
