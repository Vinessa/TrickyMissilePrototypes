using UnityEngine;
using System.Collections;

public class EagleScript : MonoBehaviour {
	Ages age;
	public float moveSpeed;
	public float eggMoveSpeed;
	public float normalMoveSpeed;
	public float oldMoveSpeed;

	public GameObject egg;
	public GameObject chick;
	public GameObject adult;
	public GameObject great;

	public int startingAge = -1;

	public GameObject[] flightPath;
	int curFPPoint;
	public GameObject target;
	public float rotateSpeed = 3;
	// Use this for initialization

	public BoxCollider myCollider;
	void Start () {

		if(startingAge > 0 && startingAge < 4)
			for(int i = 0; i < startingAge; i++)
				age++;
		else
			age = Ages.baby;


		curFPPoint = 0;
		target = flightPath[0];
		Aged(0);
	}
	
	// Update is called once per frame
	void Update () {
		if(age == Ages.normal || age == Ages.old)
		{
			//transform.LookAt(target.transform.position);
			float step = rotateSpeed * Time.deltaTime;
			Vector3 targetRotation = (target.transform.position - transform.position).normalized;
			Quaternion lookRotation = Quaternion.LookRotation(targetRotation);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
			//transform.Translate(transform.forward*moveSpeed*Time.deltaTime);
			transform.position = transform.position + transform.forward*moveSpeed*Time.deltaTime;

			//goes from first point in flight path to next and goes from last fp point to first
			if(Vector3.Distance(target.transform.position, transform.position) < 3)
			{
				curFPPoint++;
				if(curFPPoint >= flightPath.Length)
					curFPPoint = 0;


				target = flightPath[curFPPoint];
			}
		}
	}

	void Aged(int effect)
	{
		if(effect > 0)
		{
			if(age == Ages.old)
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
			transform.tag = "Egg";
			moveSpeed = 0;
			egg.SetActive(true);
			chick.SetActive(false);
			adult.SetActive(false);
			great.SetActive(false);
			myCollider.size = new Vector3(.71f,.57f,.67f);
			break;
		case Ages.young:
			transform.tag = "Eagle";
			moveSpeed = 0.0f;
			egg.SetActive(false);
			chick.SetActive(true);
			adult.SetActive(false);
			great.SetActive(false);
			myCollider.size = new Vector3(.71f,.57f,.67f);
			break;
		case Ages.normal:
			transform.tag = "Eagle";
			moveSpeed = 10.0f;
			egg.SetActive(false);
			chick.SetActive(false);
			adult.SetActive(true);
			great.SetActive(false);
			myCollider.size = new Vector3(1.9f,.57f, 1.61f);
			break;
		case Ages.old:
			transform.tag = "Eagle";
			moveSpeed = 5.0f;
			egg.SetActive(false);
			chick.SetActive(false);
			adult.SetActive(false);
			great.SetActive(true);
			myCollider.size = new Vector3(6,.57f,3.37f);

			break;
		default:
			break;
		}
	}
}
