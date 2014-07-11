using UnityEngine;
using System.Collections;

public class SpiderBehaviour : EnemyBasicBehaviour {
	
	public bool isLocalPlayer;
	public static GameControl GameCtrl;
	public GameObject SpiderPlayer;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate ()
	{
		checkPlayer ();
	}

	private void checkPlayer()
	{
		if (checkLocalPlayer (SpiderPlayer)) 
		{
			isLocalPlayer = true;
		} else 
		{
			isLocalPlayer = false;
		}
	}

}
