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

		if (other.gameObject.CompareTag("Collectible"))
		{
			ScoreSystem.Instance.IncreaseCoinCount(5);
			Destroy(other.gameObject);
		}

		if (other.gameObject.CompareTag("Diamond"))
		{
			ScoreSystem.Instance.IncreaseCoinCount(10);
			Destroy(other.gameObject);
		}

		if (other.gameObject.CompareTag("Finish"))
		{
			if (gameObject == Player.Instance.characters[0])
			{
				ScoreSystem.Instance.IncreaseTotalCoinCount();
			}
		}
	}
}
