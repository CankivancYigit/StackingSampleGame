using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
			if (gameObject != Player.Instance.characters[0])
			{
				Destroy(Player.Instance.characters[Player.Instance.characters.Count - 1].gameObject);
				Player.Instance.characters.Remove(Player.Instance.characters[Player.Instance.characters.Count - 1].gameObject);
				Player.Instance.GetComponentInChildren<StackBar>().UpdateStackBar();
			}
		}
		
		if (other.gameObject.CompareTag("Finish"))
		{
			other.gameObject.transform.Find("Finish Point Transform").transform.localPosition -= transform.forward/2;
			
			if (gameObject == Player.Instance.characters[0])
			{
				GameManager.Instance._states = GameManager.States.GameEnd;
				
				PlayerController.Instance.enabled = false;
				
				Player.Instance.GetComponentInChildren<StackBar>().gameObject.SetActive(false);
				
				GameManager.Instance.CinemachineVirtualCamera.Follow = gameObject.transform;

				transform.DOMove(other.gameObject.transform.Find("Finish Point Transform").transform.position, 1)
					.OnComplete(() => transform.DOLocalRotate(new Vector3(transform.localRotation.x, 180, transform.localRotation.z), 1)
						.OnComplete(() => transform.GetComponent<Animator>().SetBool("Dance",true)));
			}
			else
			{
				transform.DOMove(other.gameObject.transform.Find("Finish Point Transform").transform.position, 1)
					.OnComplete(() => transform.DOLocalRotate(new Vector3(transform.localRotation.x, 180, transform.localRotation.z), 1)
						.OnComplete(() => transform.GetComponent<Animator>().SetBool("Dance",true)));
				//Destroy(gameObject);
			}
		}
	}
}
