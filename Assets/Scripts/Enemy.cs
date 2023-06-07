using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Update()
    {
        ManageMovement();
    }

	void ManageMovement()
	{
		const float SPEED = 3;
		transform.position += Vector3.forward * SPEED * Time.deltaTime;
	}
}
