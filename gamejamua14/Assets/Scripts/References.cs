using UnityEngine;
using System.Collections;

public class References : MonoBehaviour
{
		public GameObject BasicPlayer;
		public GameObject SpiderPlayer;

		void Awake ()
		{
				StaticRefs.Refs = this;
		}
}
