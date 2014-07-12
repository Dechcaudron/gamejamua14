using UnityEngine;
using System.Collections;

public class SpiderBehaviour : EnemyBasicBehaviour
{
	
		public bool isLocalPlayer;
		public static GameObject SpiderPlayer;
		public static GameObject NPC;
		protected Rigidbody rigidbody;

		// Use this for initialization
		void Awake ()
		{
				rigidbody = GetComponent<Rigidbody> ();
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
					chaseObjective (SpiderPlayer, rigidbody);
				} else {
					chaseObjective (NPC, rigidbody);
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
