using UnityEngine;
using System.Collections;

public class DEMORenderToTexture : MonoBehaviour {



	public Texture2D rttTexture;
	public Transform targetMesh;
	public Camera mainCamera;
	public float updateRate = 0.2f;

	void Start () 
	{
		StartCoroutine("rtt");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator rtt()
	{
		while(true)
		{
			yield return new WaitForSeconds(updateRate);
			yield return new WaitForEndOfFrame();
			rttTexture = new Texture2D((int)(Screen.width*0.3f),(int)(Screen.height*0.3f));
			rttTexture.ReadPixels(new Rect((int)(Screen.width*0.7f),(int)(Screen.height*0.7f),(int)(Screen.width*0.3f),(int)(Screen.height*0.3f)),0,0);
			rttTexture.Apply();
			targetMesh.renderer.material.mainTexture = rttTexture;

		}
	}

	void OnGUI()
	{
		//GUI.DrawTexture(new Rect(0,0,400,400),rttTexture);
	}
}
