using UnityEngine;
using System;

public static class JsonHelper
{
	public static T[] FromJson<T>(string json)
	{
		Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
		return wrapper.Character;
	}

	[Serializable]
	private class Wrapper<T>
	{
		public T[] Character;
	}
}