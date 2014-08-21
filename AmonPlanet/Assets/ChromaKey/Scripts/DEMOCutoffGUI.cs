using UnityEngine;
using System.Collections;

public class DEMOCutoffGUI : MonoBehaviour {

	public Transform screen1;
	public Transform screen2;

	public float cutoffValue = 0.175f;

	void Update()
	{
		screen1.renderer.material.SetFloat("_Cutoff",cutoffValue);
		screen2.renderer.material.SetFloat("_Cutoff",cutoffValue);
	}


	void OnGUI()
	{
		GUI.Box(new Rect(8,8,300,80),"");
		GUILayout.BeginArea(new Rect(10,18,290,80));
		
		GUILayout.BeginHorizontal();
		GUILayout.Label("Cut-off Value",GUILayout.Width(50));
		cutoffValue = GUILayout.HorizontalSlider(cutoffValue,0f,1f);

		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		GUI.Label(new Rect(64,31,290,80),cutoffValue.ToString("F"));
		if(GUI.Button(new Rect(18,54,282,28),"Reset"))
		{
			cutoffValue = 0.175f;
		}
	}
}
