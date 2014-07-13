﻿using UnityEngine;
using System.Collections;

public class References : MonoBehaviour
{
		public GameObject BasicPlayer;
		public GameObject SpiderPlayer;
		public GameObject SharkPlayer;

		public GameObject Smoke;
		public GameObject Bubbles;

		public GlobalSoundControl GlobalSound;
		public GameControl GameControl;

		void Awake ()
		{
				StaticRefs.Refs = this;
		}
}
