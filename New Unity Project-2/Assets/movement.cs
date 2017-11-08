using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{


	//public float speed = 1;
	public int queuecount = 0;
	public GameObject gcf2, gcf1, gcf3, gcf4;
	public int userIs = 0;
	public int moving = 1;
	public bool click = false;
	public GameObject target;
	public GameObject ctarget;
	public  Camera camera1;
	public bool up = false;
	public Queue<GameObject> clicks;
	public Queue<GameObject> keys;
	public bool pett = true;
	private Queue<GameObject> pressedButtons = new Queue<GameObject>();
    


	// Use this for initialization
	void Start ()
	{
		gcf1 = GameObject.Find ("gcf1");
		gcf2 = GameObject.Find ("gcf2");
		gcf3 = GameObject.Find ("gcf3");
		gcf4 = GameObject.Find ("gcf4");
		target = GameObject.Find ("gcf1");
		clicks = new Queue<GameObject> ();
		keys = new Queue<GameObject> ();
		//clicks.Enqueue(ctarget);


	}

	// Update is called once per frame
	void Update ()
	{
//		if (moving == 1) {

			if (Input.GetKeyDown ("z")) {
//				target = gcf1;
				 keys.Enqueue(gcf1);
				moving = 0;
				userIs = 0;
				click = true;
				pett = false;
			}
			if (Input.GetKeyDown ("s")) {
//				target = gcf2;
				 keys.Enqueue(gcf2);
				moving = 0;
				userIs = 0;
				click = true;
				pett = false;
			}
			if (Input.GetKeyDown ("a")) {
//				target = gcf2;
				 keys.Enqueue(gcf2);
				moving = 0;
				userIs = 0;
				click = true;
				pett = false;
			}

			if (Input.GetKeyDown ("w")) {
//				target = gcf3;
				 keys.Enqueue(gcf3);
				moving = 0;
				userIs = 0;
				click = true;
				pett = false;
			}
			if (Input.GetKeyDown ("q")) {
//				target = gcf3;
				keys.Enqueue(gcf3);
				moving = 0;
				userIs = 0;
				click = true;
				pett = false;
			}
			if (Input.GetKeyDown ("2")) {
//				target = gcf4;
				keys.Enqueue(gcf4);
				moving = 0;
				userIs = 0;
				click = true;
				pett = false;

//			}
                
		}
		queuecount = clicks.Count;
		if (clicks.Count != 0) {
			target = clicks.Peek ();
			// BroadcastMessage(clicks.Peek().name);

		}

		if (transform.position.y != clicks.Peek().transform.position.y) {
			transform.position = Vector3.MoveTowards (transform.position, clicks.Peek().transform.position, Time.deltaTime * .5f);
            


			if (click == false) {
                
				if (up == true) {

					if (transform.position.y < gcf2.transform.position.y) {
						if (Input.GetKeyDown ("a")) {
							clicks.Enqueue (gcf2);
							moving = 0;
							userIs = 0;
							click = true;
							pett = false;
						}
					}
					if (transform.position.y < gcf3.transform.position.y) {
						//BroadcastMessage("enter q");
						if (Input.GetKeyDown ("q")) {
							BroadcastMessage ("enter q");

							clicks.Enqueue (gcf3);
							moving = 0;
							userIs = 0;
							click = true;
							pett = false;
						}
					}                    
				} else {
					if (transform.position.y > gcf2.transform.position.y) {
						BroadcastMessage ("enter s");
						if (Input.GetKeyDown ("s")) {
							BroadcastMessage ("enter s");
							clicks.Enqueue (gcf2);
							moving = 0;
							userIs = 0;
							click = true;
							pett = false;
						}
					}
					if (transform.position.y > gcf3.transform.position.y) {
						if (Input.GetKeyDown ("w")) {
							clicks.Enqueue (gcf4);
							moving = 0;
							userIs = 0;
							click = true;
							pett = false;
						}
					}

				}


			}
            
            
		}

		if (userIs == 1) {
			if (Input.GetMouseButtonDown (0)) {
				Ray ray = camera1.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit)) {
					Transform objectHit = hit.transform;
                    
					ctarget.transform.position = objectHit.transform.position;
					if (ctarget.transform.position == gcf1.transform.position || ctarget.transform.position == gcf2.transform.position ||
					                   ctarget.transform.position == gcf3.transform.position || ctarget.transform.position == gcf4.transform.position) {
						if (transform.position.y > ctarget.transform.position.y) {
							up = false;

						} else {
							up = true;
						}
						if (ctarget.transform.position == gcf1.transform.position) {
							clicks.Enqueue (gcf1);
						}
						if (ctarget.transform.position == gcf2.transform.position) {
							clicks.Enqueue (gcf2);
						}
						if (ctarget.transform.position == gcf3.transform.position) {
							clicks.Enqueue (gcf3);
						}
						if (ctarget.transform.position == gcf4.transform.position) {
							clicks.Enqueue (gcf4);
						}
						//BroadcastMessage(clicks.Peek().name);

						//target = ctarget;
						userIs = 0;
						moving = 0;
						click = false;
						pett = true;
					}
				}
                
			}
            
		}
        
		if (transform.position == keys.Peek().transform.position) {
            
			if (clicks.Count != 0) {
				//BroadcastMessage(clicks.Peek().name);
				if (transform.position == clicks.Peek ().transform.position) {
					//BroadcastMessage(clicks.Peek().name);

					clicks.Dequeue ();
				}

			}
			if (keys.Count > 0) {
				keys.Dequeue ();
			}
			moving = 1;
			if (click == true) {
				userIs = 1;
			}

		}

	}


}


