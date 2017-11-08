using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTriggerController : MonoBehaviour {
    
    public ElevatorController ElevatorScript;
    public GameObject Elevator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown () {
        if (ElevatorScript.readyForClick)// && ((ElevatorScript.up && Elevator.transform.position.y < transform.position.y) || (!ElevatorScript.up && Elevator.transform.position.y > transform.position.y)))
        {
            Debug.Log("Entered");
            ElevatorScript.AddClickedFloor(gameObject);
        }
    }
}
