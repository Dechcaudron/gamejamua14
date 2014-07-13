using UnityEngine;
using System.Collections;
using System;

public class GameControl : MonoBehaviour
{
		public float MadnessIncreaseSpeed;
		public GUIText looselabel;
		public GUIText time;
		private DateTime startTime;
		private bool isGameOn;

		void Start ()
		{
				Screen.lockCursor = true;
				startTime = DateTime.Now;
				isGameOn = true;
		}

		public void EndGame ()
		{
				isGameOn = false;
				looselabel.gameObject.SetActive (true);
				StaticRefs.Refs.GlobalSound.switchingTheme = true;
				StaticRefs.Refs.GlobalSound.FadeOut ();
				WWW challenge = new WWW ("http://api.gamejamua.com/challenge/76bf5d945fab4b4/complete");
				print ("Has perdido");
		}
		
		void Update ()
		{
				if (isGameOn) {
						DateTime current = DateTime.Now;
						time.text = "Time: " + (int)current.Subtract (startTime).TotalSeconds;	
				}			
		}
}
