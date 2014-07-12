using UnityEngine;
using System.Collections;
using System.Timers;

public class SpiderwebBehaviour : MonoBehaviour
{
		public GameObject Spider;
		public float SpawnTime;

		private int counter;

		void Start ()
		{
				counter = 0;
		}

		void FixedUpdate ()
		{
				counter++;
				if (counter / (1 / Time.fixedDeltaTime) >= SpawnTime) {
						spawn ();
				}
		}

		private void spawn ()
		{
				GameObject newSpider = GameObject.Instantiate (Spider) as GameObject;
				
				newSpider.transform.position = transform.position;
		}
}
