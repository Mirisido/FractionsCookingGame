using UnityEngine;
using System.Collections;

public class DEMOChromaKeyGUI : MonoBehaviour {

	public Transform ckScreen;
	public float cutoffValue = 0.175f;
	public float smoothingValue = 0.175f;
	public float r = 0f;
	public float g = 0f;
	public float b = 1f;
	private Color hideColor;
	private Texture2D previewColor;
	void Start () 
	{
		hideColor = new Color(r,g,b,1f);
		previewColor = new Texture2D(1,1);
		previewColor.SetPixel(0,0,hideColor);
		previewColor.Apply();
	}

	void Update () 
	{
		hideColor = new Color(r,g,b,1f);
		previewColor.SetPixel(0,0,hideColor);
		previewColor.Apply();
		ckScreen.renderer.material.SetFloat("_Cutoff",cutoffValue);
		ckScreen.renderer.material.SetFloat("_Smoothing",smoothingValue);
		ckScreen.renderer.material.SetColor("_ColorToReplace",hideColor);
	}

	void OnGUI()
	{
		GUI.Box(new Rect(8,8,300,210),"");
		GUILayout.BeginArea(new Rect(10,18,290,210));
		
		GUILayout.BeginHorizontal();
		GUILayout.Label("Cut-off Value",GUILayout.Width(66));
		cutoffValue = GUILayout.HorizontalSlider(cutoffValue,0.01f,1f);
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.Label("Smoothing Value",GUILayout.Width(66));
		smoothingValue = GUILayout.HorizontalSlider(smoothingValue,0.01f,1f);
		GUILayout.EndHorizontal();

		GUILayout.Space(6);

		GUILayout.BeginHorizontal();
		GUILayout.Label("Red",GUILayout.Width(66));
		r = GUILayout.HorizontalSlider(r,0f,1f,GUILayout.Width(120));
		GUILayout.Label(r.ToString("F"));
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.Label("Green",GUILayout.Width(66));
		g = GUILayout.HorizontalSlider(g,0f,1f,GUILayout.Width(120));
		GUILayout.Label(g.ToString("F"));
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.Label("Blue",GUILayout.Width(66));
		b = GUILayout.HorizontalSlider(b,0f,1f,GUILayout.Width(120));
		GUILayout.Label(b.ToString("F"));
		GUILayout.EndHorizontal();





		GUILayout.EndArea();

		GUI.Label(new Rect(80,31,290,80),cutoffValue.ToString("F"));
		GUI.Label(new Rect(80,70,290,80),smoothingValue.ToString("F"));

		GUI.DrawTexture(new Rect(238,106,60,60),previewColor);



		if(GUI.Button(new Rect(18,183,282,30),"Reset"))
		{
			cutoffValue = 0.175f;
			smoothingValue = 0.175f;
			r = 0f;
			g = 0f;
			b = 1f;
		}
	}
}
