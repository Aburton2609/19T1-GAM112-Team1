using UnityEngine;
using UnityEngine.UI;

public class KeyPickUpLogic : MonoBehaviour
{
	Image keysHoldingUI;

	private void Start()
	{
		keysHoldingUI = GameObject.FindGameObjectWithTag("KeyImage").GetComponent<Image>();
		keysHoldingUI.fillAmount = 0;
	}

	void OnTriggerEnter2D(Collider2D collider2D)
	{
		if (collider2D.gameObject.tag == "Key")
		{
			keysHoldingUI.fillAmount += 0.25f;
			collider2D.gameObject.SetActive(false);
		}
	}

	public void UseKey()
	{
		keysHoldingUI.fillAmount -= 0.25f;
	}
}