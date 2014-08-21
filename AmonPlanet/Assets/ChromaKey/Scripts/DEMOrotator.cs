using UnityEngine;
using System.Collections;

public class DEMOrotator : MonoBehaviour {

	private Transform _transform;
	public float speed = 20f;
	void Start () 
	{
		_transform = transform;
	}

	void Update () 
	{
		_transform.Rotate(new Vector3(0f,speed * Time.deltaTime,0f));
	}
}
