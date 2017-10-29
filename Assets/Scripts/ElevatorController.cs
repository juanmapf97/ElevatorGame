using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour {

    public float smoothFactor = 1;
    private bool isMoving;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void MoveToFloor (int floor)
    {
        if (!isMoving) {
            switch (floor)
            {
                case 1:
                    StartCoroutine(MoveObject(transform.position, new Vector3(3.2f, 0)));
                    break;
                case 2:
                    StartCoroutine(MoveObject(transform.position, new Vector3(3.2f, 2.5f)));
                    break;
                case 3:
                    StartCoroutine(MoveObject(transform.position, new Vector3(3.2f, 5f)));
                    break;
                case 4:
                    StartCoroutine(MoveObject(transform.position, new Vector3(3.2f, 7.5f)));
                    break;
                default:
                    break;
            }
            isMoving = true;
        }
    }

    IEnumerator MoveObject(Vector3 source, Vector3 target)
    {
        float startTime = Time.time;
        while (Vector3.Distance(transform.position, target) > 0.05f)
        {
            transform.position = Vector3.Lerp(source, target, (Time.time - startTime) * smoothFactor);
            yield return null;
        }
        transform.position = target;
        isMoving = false;
    }
}
