using UnityEngine;
using System.Collections;

public class References : MonoBehaviour
{
		public GameObject BasicPlayer;
		public GameObject SpiderPlayer;
		public GameObject SharkPlayer;

		public GameObject Smoke;

		void Awake ()
		{
				StaticRefs.Refs = this;
		}
}
