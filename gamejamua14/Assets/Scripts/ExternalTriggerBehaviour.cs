using UnityEngine;
using System.Collections;

public class ExternalTriggerBehaviour : MonoBehaviour
{
		[SerializeField]
		private MonoBehaviour
				MonoToTrigger;
		private IReceivesExternalTrigger toTrigger;

		// Use this for initialization
		void Awake ()
		{
				toTrigger = MonoToTrigger as IReceivesExternalTrigger;

				if (toTrigger == null)
						Debug.LogError ("The MonoBehaviour should implement IReceivesExternalTrigger");
		}
	
		void OnTriggerEnter (Collider a_collider)
		{
				toTrigger.ExtTriggerEnter (a_collider);
		}

		void OnTriggerStay (Collider a_collider)
		{
				toTrigger.ExtTriggerStay (a_collider);
		}

		void OnTriggerExit (Collider a_collider)
		{
				toTrigger.ExtTriggerExit (a_collider);
		}
}
