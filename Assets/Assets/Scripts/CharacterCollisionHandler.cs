using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollisionHandler : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Stackable"))
		{
			Player.Instance.StackObjects(other.gameObject,Player.Instance.characters.Count - 1);
			Player.Instance.characters.Add(other.gameObject);
			other.gameObject.tag = "Untagged";
		}
	}
}
