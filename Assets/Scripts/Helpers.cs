using System;
using UnityEngine;

public class Helpers
{
	public static Vector3 XZ(this Vector3 input) {
		return new Vector3 (input.x, 0, input.z);
	}
}

