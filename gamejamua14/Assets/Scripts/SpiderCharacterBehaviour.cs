using UnityEngine;
using System.Collections;

public class SpiderCharacterBehaviour : BasicCharacterBehaviour
{

		protected override void Start ()
		{
				StaticRefs.Refs.SpiderPlayer = gameObject;
				gameObject.SetActive (false);
		}
}
