using UnityEngine;
using System.Collections;

public class CharacterManagement : MonoBehaviour
{
		private	bool expectingChange;

		void Start ()
		{
				expectingChange = false;
		}

		void OnTriggerExit (Collider a_collider)
		{
				expectingChange = true;
		}

		void OnTriggerStay (Collider a_collider)
		{
				switch (a_collider.name) {

				}
		}
}
