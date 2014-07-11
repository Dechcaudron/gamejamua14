using UnityEngine;
using System.Collections;

public class SpiderBehaviour : EnemyBasicBehaviour {
	
	public bool isLocalPlayer;
	public static GameControl GameCtrl;
	public GameObject SpiderPlayer;
	public GameObject NPC;
	public CharacterController Controller;

	// Use this for initialization
	void Start () {
		Controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate ()
	{
		checkPlayer ();
		if (isLocalPlayer) {
			chasePlayer (SpiderPlayer,Controller);
		} else {
			chaseNPC (NPC);
		}
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
