using UnityEngine;
using System.Collections;

public class CharacterManagement : MonoBehaviour
{
		public GameObject BasicPlayer;
		public GameObject SpidersPlayer;
		public GameObject SharksPlayer;
		private	bool expectingChange;
		private GameObject currentPlayer;
		public AudioSource audioResource;
		public AudioClip[] audioClips;

		void Start ()
		{
				expectingChange = false;
				currentPlayer = BasicPlayer;
				audioResource.clip = audioClips [0];
				audioResource.volume = 1;	
				audioResource.loop = true;
		}

		void OnTriggerExit (Collider a_collider)
		{
				expectingChange = true;
		}

		void OnTriggerStay (Collider a_collider)
		{

				switch (a_collider.name) {
				case "SpiderBossTrigger":
						if (BossSpiderBehaviour.IsAwake == true && currentPlayer != SpidersPlayer) {
								currentPlayer.SetActive (false);
								SpidersPlayer.SetActive (true);
								currentPlayer = SpidersPlayer;
						}
						break;
				}

				if (!expectingChange)
						return;

				currentPlayer.SetActive (false);	

				switch (a_collider.name) {
				case "TriggerSpiders":
						SpidersPlayer.SetActive (true);
						currentPlayer = SpidersPlayer;
						if (audioResource.isPlaying) {				
								audioResource.Pause ();
						}
						break;

				case "TriggerBase":
						BasicPlayer.SetActive (true);
						currentPlayer = BasicPlayer;
						if (audioResource.isPlaying) {				
								audioResource.Pause ();
						}
						break;

				case "TriggerSharks":
						SharksPlayer.SetActive (true);
						currentPlayer = SharksPlayer;
						audioResource.Play ();
						break;
				}

				//End the change
				expectingChange = false;
		}
}
