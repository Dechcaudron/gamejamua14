using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour
{
		public float MadnessIncreaseSpeed;
		public GUIText looselabel;

		void Start ()
		{
				Screen.lockCursor = true;
		}

		public void EndGame ()
		{
				looselabel.gameObject.SetActive (true);
				StaticRefs.Refs.GlobalSound.switchingTheme = true;
				StaticRefs.Refs.GlobalSound.FadeOut ();
				WWW challenge = new WWW ("http://api.gamejamua.com/challenge/76bf5d945fab4b4/complete");
				print ("Has perdido");
		}
}
