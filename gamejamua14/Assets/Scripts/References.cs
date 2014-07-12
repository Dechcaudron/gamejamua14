using UnityEngine;
using System.Collections;

public class References : MonoBehaviour
{
		public GameObject BasicPlayer;
		public GameObject SpiderPlayer;
		public GameObject PiranhasPlayer;

		public GameObject Smoke;

		void Awake ()
		{
				StaticRefs.Refs = this;
		}
}
