using UnityEngine;
using System.Collections;

public class DistroyByTime : MonoBehaviour {

	public float lifetime;

	void Start()
	{
		Destroy (gameObject, lifetime);
	}

}
