using UnityEngine;
using System.Collections;
using Stanlia;
public class Program : MonoBehaviour {

	private GameObject console;
	private bool consoleVisibility = false;
	private Stanlia.Stanlia stanlia;
	// Use this for initialization
	void Start () {
		stanlia = new Stanlia.Stanlia ();
		console = GameObject.FindGameObjectWithTag ("Console");
	}
	
	// Update is called once per frame
	void Update () {
		//bind ` to the visibility of the console
		if (Input.GetKeyDown(KeyCode.BackQuote)){
			consoleVisibility = !consoleVisibility;
		}
		console.SetActive (consoleVisibility);

		//call Stanlia to update
		stanlia.Update ();
	}
}
