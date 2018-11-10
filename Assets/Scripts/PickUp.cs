using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("Working");
	}

	void OnCollisionStay2D (Collision2D other)
	{
		//Debug.Log(other.gameObject.tag);
		if(other.gameObject.tag == "Player" && Input.GetButtonDown("Pick")){
			InputHandler.itemPicked = true;
			Destroy(this.gameObject);
		}
	}
}
