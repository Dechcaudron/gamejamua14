using UnityEngine;
using System.Collections;
using System.Timers;

public class SpiderwebBehaviour : MonoBehaviour
{
		public GameObject Spider;
		public float SpawnTime;

		public Transform[] Spawns;

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
				Transform t_spawnPoint = Spawns.GetRandomTransform ();
				GameObject newSpider = GameObject.Instantiate (Spider, t_spawnPoint.position, Quaternion.identity) as GameObject;
				newSpider.GetComponent<SpiderBehaviour> ().SetSpawn (t_spawnPoint);
		}
}
