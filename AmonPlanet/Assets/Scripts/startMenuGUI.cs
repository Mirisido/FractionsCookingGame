using UnityEngine;
using System.Collections;

public class startMenuGUI : MonoBehaviour {

	// Make the first button. If it is pressed the user is to the next level
	void OnGUI() {
		if(GUI.Button (new Rect(300,300,240, 180), "Take Picture of Toy")){

			Application.LoadLevel(1);
		}
	}
}