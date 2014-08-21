using UnityEngine;
using System.Collections;

public class takePhotographGUI : MonoBehaviour {

	bool  buttonPressed = false;

	//displays a button used to take a photograph and loads the next level
	void OnGUI(){
		if(buttonPressed == false){
						if (GUI.Button (new Rect (20, 40, 180, 120), "Take Photograph")) {
				buttonPressed = true;
				}
		}
		if (buttonPressed == true) {
			takeScreenshot();

			Application.LoadLevel (Application.loadedLevel + 1);
				}
		}

	//Takes a screenshot of what's displayed on the screen and saves it at the specified location
void takeScreenshot(){

		//Use Application.persistentDataPath when making an android build
		Application.CaptureScreenshot("Assets/Resources/Screenshot.png");		

	}

	}

