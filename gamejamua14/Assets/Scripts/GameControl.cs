using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour
{
		public float MadnessIncreaseSpeed;

		void Start ()
		{
				Screen.lockCursor = true;
		}

		public void EndGame ()
		{
				print ("Has perdido");
		}
}
