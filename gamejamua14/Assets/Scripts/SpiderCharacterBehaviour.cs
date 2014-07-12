using UnityEngine;
using System.Collections;

public class SpiderCharacterBehaviour : BasicCharacterBehaviour
{

		public Animator SwordAnimator;

		protected override void Start ()
		{
				StaticRefs.Refs.SpiderPlayer = gameObject;
				gameObject.SetActive (false);
		}

		protected override void ProcessMouseClicks ()
		{
				base.ProcessMouseClicks ();

				if (Input.GetMouseButtonDown (0)) {
						SwordAnimator.SetTrigger (HashIDs.Attack);
				}
		}
}
