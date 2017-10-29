using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionTriggerController : MonoBehaviour {

    public ElevatorController elevator;
    public int floor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown ()
    {
        elevator.MoveToFloor(floor);
    }
}
