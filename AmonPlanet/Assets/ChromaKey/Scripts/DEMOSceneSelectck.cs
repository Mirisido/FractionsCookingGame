using UnityEngine;
using System.Collections;

public class DEMOSceneSelectck : MonoBehaviour {

	void OnGUI()
	{
		GUI.Box(new Rect((Screen.width/2) - 100,10,200,30),"");
		if(GUI.Button(new Rect((Screen.width/2) - 90,12,80,26),"Scene 1"))
		{
			Application.LoadLevel("DemoScene 2");
		}
		if(GUI.Button(new Rect((Screen.width/2) + 10,12,80,26),"Scene 2"))
		{
			Application.LoadLevel("DemoScene");
		}
	}
}
