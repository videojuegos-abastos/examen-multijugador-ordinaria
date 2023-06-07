using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

class Player : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI hitsTMP;
	int lives = 3;
	bool immortal = false;
	bool floorUsed = false;
	[SerializeField] GameObject floor;

	void Start()
	{
		UpdateLivesUI();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && !floorUsed && lives > 0)
		{
			ResetFloor();
		}

		ManageMovement();
	}

	void ManageMovement()
	{
		const float SPEED = 6f;
		float h = Input.GetAxis("Horizontal");
	
		transform.position += Vector3.left * h * SPEED * Time.deltaTime;
	}


	void UpdateLivesUI()
	{
		if (lives >= 0)
		{
			hitsTMP.text = lives.ToString();
		}

		if (lives <= 0)
		{
			hitsTMP.color = Color.red;
		}
	}

	void ResetFloor()
	{
		floorUsed = true;
		StartCoroutine(nameof(ResetFloor_Coroutine));
	}

	IEnumerator ResetFloor_Coroutine()
	{
		floor.SetActive(false);

		yield return new WaitForSeconds(0.4f);

		floor.SetActive(true);
	}

	void OnTriggerEnter(Collider collider)
    {
		const string METEOR_TAG = "Meteor";
        if (collider.gameObject.tag == METEOR_TAG)
		{
			Destroy(collider.gameObject);

			lives -= 1;

			UpdateLivesUI();
		}
    }
}