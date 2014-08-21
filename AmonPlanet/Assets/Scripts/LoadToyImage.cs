using UnityEngine;
using System.Collections;
using UnityEditor;

public class LoadToyImage : MonoBehaviour {

	public Shader newShader;
	public WWW www;

//retrieves the image of the toy from the specified location
IEnumerator getImage(){ 
		//use Application.persistentDataPath when making an android build
		WWW www = new WWW("file:C:/Users/Mirisido/Documents/School/SummerResearch/AmonPlanet/Assets/Resources/Screenshot.png");

		//waits for the image to be found
		yield return www;

		renderer.material.mainTexture = www.texture;
		renderer.material.shader = newShader;
		print ("Width: " + renderer.material.mainTexture.width + "Height: " + renderer.material.mainTexture.height);
		}

	// Use this for initialization
	void Start () {

		//Starts the coroutine that finds the image
		StartCoroutine (getImage());
	}
}
