using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Variables : MonoBehaviour {

	public int editorNumber = 3;
	public static int numberOfIngrediants;
	//public static float goalFraction;
	public static List<int> amountPerIngrediant = new List<int>();
	public static List<double> goalFractionPer = new List<double>();

	void Start()
	{

		numberOfIngrediants = editorNumber;
		//goalFraction = 3/4;

		for (int i = 0; i < numberOfIngrediants; i++)
		{
			amountPerIngrediant.Add(8);
		}

		/*for (int i = 0; i < numberOfIngrediants; i++)
		{
			goalFractionPer.Add((double)3/(double)8);
			Debug.Log ("Goal Fraction: " + goalFractionPer[i]);
		}*/

		goalFractionPer.Add (1d/8d);
		goalFractionPer.Add (6d/8d);
		goalFractionPer.Add (3d/8d);

		//goalFractionPer.Add(3/8);
	}
}
