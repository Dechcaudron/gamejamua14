using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Extension
{

		public static Transform GetRandomTransform (this Transform[] a_array)
		{
				return a_array [Random.Range (0, a_array.Length)];
		}
}
