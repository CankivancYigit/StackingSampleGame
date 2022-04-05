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
			if ( Player.Instance.characters.Count < Player.Instance.MaxStackAmount)
			{
				Player.Instance.StackObjects(other.gameObject,Player.Instance.characters.Count - 1);
				Player.Instance.characters.Add(other.gameObject);
				Player.Instance.GetComponentInChildren<StackBar>().UpdateStackBar();
				other.gameObject.GetComponent<Animator>().SetBool("Run 1",true);
				other.gameObject.tag = "Untagged";
			}
		}

		if (other.gameObject.CompareTag("Collectible"))
		{
			ScoreSystem.Instance.ChangeCoinCount(5);
			UiManager.Instance.SetCoinAmountText();
			Destroy(other.gameObject);
		}

		if (other.gameObject.CompareTag("Diamond"))
		{
			ScoreSystem.Instance.ChangeCoinCount(10);
			UiManager.Instance.SetCoinAmountText();
			Destroy(other.gameObject);
		}

		if (other.gameObject.CompareTag("Obstacle"))
		{
			Player.Instance.characters.Remove(gameObject);
			Player.Instance.GetComponentInChildren<StackBar>().UpdateStackBar();
			Destroy(gameObject);
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
