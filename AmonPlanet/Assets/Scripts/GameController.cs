using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	//ing = ingrediant

	public static bool ARActive = false;
	public GameObject[] inPos;
	private Transform trans;
	public GameObject imageTarget;
	public GameObject[] ingrediant;
	public int ingMultiple = 2; //number of ingrediants used on this level
	public static int ingAmount = 8; //number of a specific ingrediant -- used for placing ingrediant in scene
	public static List<int> ingAmountList = new List<int>();
	public List<GameObject> ingList = new List<GameObject>();
	public static int ingCounter = 0;

	void Awake ()
	{
		if (ARActive == true)
		{
			//use AR camera
		}
		else
		{
			//use non-AR camera
		}
	}

	// Use this for initialization
	void Start () 
	{
		//ingAmount = Variables.numberOfIngrediants;

		ingMultiple = Variables.numberOfIngrediants;

		for (int i = 0; i < ingMultiple; i++)
		{
			ingAmountList.Add(Variables.amountPerIngrediant[i]);
			//set ingAmount to next ingrediant amount
		}

		//places ingrediants in proper places
		for (int i = 0; i < ingAmountList[0]; i++)
		{
			trans = inPos[i].GetComponent<Transform>();
			GameObject newIng = Instantiate(ingrediant[0], trans.position, Quaternion.identity) as GameObject;
			ingList.Add (newIng);
			newIng.transform.parent = imageTarget.transform;
		}
	}

	void OnGUI()
	{
		if (GUI.Button(new Rect(Screen.width - 90, Screen.height - 120, 90, 60), "Next\nIngrediant"))
		{
			if (ingCounter < ingMultiple - 1)
			{
				ingCounter++;

				//destroy current objects
				foreach (GameObject newIng in ingList)
				{
					Destroy(newIng);
				}

				ingList.Clear();

				//add next ingrediants
				for (int i = 0; i < ingAmountList[ingCounter]; i++)
				{
					trans = inPos[i].GetComponent<Transform>();
					GameObject newIng = Instantiate(ingrediant[ingCounter], trans.position, Quaternion.identity) as GameObject;
					ingList.Add (newIng);
					newIng.transform.parent = imageTarget.transform;
				}
			}
		}
		if (GUI.Button(new Rect(Screen.width - 90, Screen.height - 60, 90, 60), "Previous\nIngrediant"))
		{
			if (ingCounter > 0)
			{
				ingCounter--;

				//destroy current objects
				foreach (GameObject newIng in ingList)
				{
					Destroy(newIng);
				}

				ingList.Clear();

				//add previous ingrediants
				for (int i = 0; i < ingAmountList[ingCounter]; i++)
				{
					trans = inPos[i].GetComponent<Transform>();
					GameObject newIng = Instantiate(ingrediant[ingCounter], trans.position, Quaternion.identity) as GameObject;
					ingList.Add (newIng);
					newIng.transform.parent = imageTarget.transform;
				}
			}
		}
	}
}
