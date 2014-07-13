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
				print ("Has perdido");
		}
}
