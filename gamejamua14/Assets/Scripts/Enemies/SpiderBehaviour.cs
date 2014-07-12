using UnityEngine;
using System.Collections;

public class SpiderBehaviour : EnemyBasicBehaviour
{
	
		public bool isLocalPlayer;
		public static GameObject SpiderPlayer;
		public static GameObject NPC;
		protected CharacterController Controller;

		// Use this for initialization
		void Awake ()
		{
				Controller = GetComponent<CharacterController> ();
				SpiderPlayer = StaticRefs.Refs.SpiderPlayer;
				NPC = GameObject.Find ("SpiderNPC");
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void FixedUpdate ()
		{
				checkPlayer ();
				if (isLocalPlayer) {
						chasePlayer (SpiderPlayer, Controller);
				} else {
						chaseNPC (NPC, Controller);
				}
		}

		private void checkPlayer ()
		{
				if (checkLocalPlayer (SpiderPlayer)) {
						isLocalPlayer = true;
				} else {
						isLocalPlayer = false;
				}
		}

}
