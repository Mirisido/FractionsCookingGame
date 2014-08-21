using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class NewMathController : MonoBehaviour {

	public List<double> CurrentFraction = new List<double>();
	public static List<double> CurrentUsedIngrediants = new List<double>();
	//public static int numSelectedIngredients = 0;

	// Use this for initialization
	void Start () 
	{
		for (int i = 0; i < Variables.numberOfIngrediants; i++)
		{
			CurrentUsedIngrediants.Add(0);
		}
		
		for (int i = 0; i < Variables.numberOfIngrediants; i++)
		{
			CurrentFraction.Add(0);
		}
	}

	void OnGUI()
	{
		if (GUI.Button(new Rect(10, 40, 200, 30), "Is this right?"))
		{
			for (int i = 0; i < Variables.numberOfIngrediants; i++)
			{
				double tempDouble = CurrentUsedIngrediants[i];
				double secondTemp = Variables.amountPerIngrediant[i];
				double tempCheck = tempDouble/secondTemp;

				CurrentFraction[i] = tempCheck;

				//Debug.Log ("tempDouble: " + tempDouble);
				//Debug.Log ("secondTemp: " + secondTemp);
				//Debug.Log ("Formula: " + tempDouble + "/" + secondTemp);
				//Debug.Log ("Current Fraction: " + CurrentFraction[i]);
				//Debug.Log ("tempCheck: " + tempCheck);
				//Debug.Log ("Goal: " + Variables.goalFractionPer[i]);
			}

			if (CurrentFraction.SequenceEqual(Variables.goalFractionPer))
			{
				Debug.Log ("Correct");
			}
			else
			{
				Debug.Log ("Not Correct");
			}
		}
	}
}
