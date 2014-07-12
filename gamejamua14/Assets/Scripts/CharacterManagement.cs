using UnityEngine;
using System.Collections;

public class CharacterManagement : MonoBehaviour
{
		public GameObject BasicPlayer;
		public GameObject SpidersPlayer;
		public GameObject SharksPlayer;

		private	bool expectingChange;
		private GameObject currentPlayer;

		void Start ()
		{
				expectingChange = false;
				currentPlayer = BasicPlayer;
		}

		void OnTriggerExit (Collider a_collider)
		{
				expectingChange = true;

		}

		void OnTriggerStay (Collider a_collider)
		{
				if (!expectingChange)
						return;

				currentPlayer.SetActive (false);	

				switch (a_collider.name) {
				case "TriggerSpiders":
						SpidersPlayer.SetActive (true);
						currentPlayer = SpidersPlayer;
						break;

				case "TriggerBase":
						BasicPlayer.SetActive (true);
						currentPlayer = BasicPlayer;
						break;
				}

				//End the change
				expectingChange = false;
		}
}
