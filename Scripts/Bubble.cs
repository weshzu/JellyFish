using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {


	[SerializeField] float objectSpeed = 1;
	[SerializeField] float resetPosition = -7f;
	[SerializeField] float startPosition = 12.5f;

    public GameManager gameManger;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	protected virtual void Update()
	{


		if (!GameManager.instance.GameOver)
		{
			transform.Translate(Vector3.left * (objectSpeed * Time.deltaTime));

			if (transform.localPosition.x <= resetPosition)
			{
				Vector3 newPos = new Vector3(startPosition, transform.position.y, transform.position.z);
				transform.position = newPos;
			}

		}
	}
		
	private void OnTriggerEnter(Collider other)
    {
        gameManger.AddPoint();



       
    }

}
