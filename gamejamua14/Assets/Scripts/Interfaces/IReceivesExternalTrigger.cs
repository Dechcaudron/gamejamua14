using UnityEngine;

public interface IReceivesExternalTrigger
{
		void ExtTriggerEnter (Collider a_collider);
		void ExtTriggerStay (Collider a_collider);
		void ExtTriggerExit (Collider a_collider);
}