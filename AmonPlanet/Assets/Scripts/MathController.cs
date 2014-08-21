using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MathController : MonoBehaviour {

	public decimal targetFraction = ((decimal) 3 / 4);
	public static int numSelectedIngredients =0;
	public static int numTotalIngredients = 0;
	public static decimal currentFraction= 0;

	//Brandon's variables
	public List<float> brandCurrentFraction = new List<float>();
	public List<float> brandCurrentUsedIngrediants = new List<float>();

	// Use this for initialization
	void Start () 
	{
		Debug.Log ("Total Ingrediant Number Before: " + numTotalIngredients);
		numTotalIngredients = GameController.ingAmount;
		Debug.Log ("Total Ingrediant Number After: " + numTotalIngredients);

		//Brandon's start
		for (int i = 0; i < Variables.numberOfIngrediants; i++)
		{
			brandCurrentUsedIngrediants.Add(0);
		}

		for (int i = 0; i < Variables.numberOfIngrediants; i++)
		{
			brandCurrentFraction.Add(0);
		}
	}

	//displays a button for the user to press when they are confident they have the correct number of ingredients selected
	void OnGUI()
	{
	
		//if the gui button is pressed and the current number of selected ingredients matches the given fraction
		//then a message is printed confirming that the user is correct (Dev purposes)
		if (GUI.Button(new Rect(10, 40, 200, 30), "Is this right?"))
		{
			print ("Target Fraction: " + targetFraction);
			currentFraction = ((decimal) numSelectedIngredients) / numTotalIngredients;
			print("Current Fraction: " + currentFraction);

			if(targetFraction == ((decimal)numSelectedIngredients / numTotalIngredients))
			{

				print ("Yes this is the correct amount of ingredients!");

			}
		}
	}
}