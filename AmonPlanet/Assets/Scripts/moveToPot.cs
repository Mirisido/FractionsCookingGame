using UnityEngine;
using System.Collections;

public class moveToPot : MonoBehaviour {

	public Transform target;
	public float speed;
	public bool mouseClicked;

	void Start()
	{
		//set target to Main Stage object
		target = GameObject.FindGameObjectWithTag("MainStage").transform;
	}

	//updates every frame
	void Update()
	{
		if (mouseClicked) 
		{
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target.position, step);
		}
	}

	//when the user clicks or touches the object 
	void OnMouseDown()
	{
		GameController.ingAmountList[GameController.ingCounter] = GameController.ingAmountList[GameController.ingCounter] - 1;
		Debug.Log (GameController.ingAmountList[GameController.ingCounter]);
		mouseClicked = true;
		//NewMathController.numSelectedIngredients = NewMathController.numSelectedIngredients + 1;
		NewMathController.CurrentUsedIngrediants[GameController.ingCounter] = NewMathController.CurrentUsedIngrediants[GameController.ingCounter] + 1;
		//Debug.Log ("Current Count: " + NewMathController.CurrentUsedIngrediants[GameController.ingCounter]);
	}

	//Destroy Object upon entering the Main Stage
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "MainStage")
		{
			Destroy(this.gameObject);
		}
	}
}
