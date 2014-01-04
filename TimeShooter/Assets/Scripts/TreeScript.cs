using UnityEngine;
using System.Collections;



public class TreeScript : MonoBehaviour 
{
	Ages age = Ages.normal;

	void Start()
	{
		age = (Ages) Random.Range(0,5);
		Aged(0);
	}

	void Aged (int effect)
	{
		if(effect > 0)
		{
			if(age == Ages.superOld)
				Destroy (this.gameObject);
			else
				age++;
		}
		else if (effect < 0)
		{
			if(age == Ages.baby)
				Destroy (this.gameObject);
			else
				age--;
		}

		switch(age)
		{
		case Ages.baby:
			transform.localScale = new Vector3(.25f,.5f,.25f);
			break;
		case Ages.young:
			transform.localScale = new Vector3(.25f,3,.25f);
			break;
		case Ages.normal:
			transform.localScale = new Vector3(.75f, 7f, .75f);
			break;
		case Ages.old:
			transform.localScale = new Vector3(2f,12f,2f);
			break;
		case Ages.superOld:
			transform.localScale = new Vector3(3f,24f,3f);
			break;
		default:
			transform.localScale = new Vector3(.5f,1,.5f);
			break;
		}
	}
}
