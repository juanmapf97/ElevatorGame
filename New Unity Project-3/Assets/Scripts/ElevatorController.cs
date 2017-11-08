using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{

    public GameObject Button1U, Button2U, Button2D, Button3U, Button3D, Button4D, Floor1, Floor2, Floor3, Floor4;
    private LinkedList<GameObject> floorsToVisit, pressedButtons, clickedFloors;
    public bool readyForClick, up;

    // Use this for initialization
    void Start()
    {
        floorsToVisit = new LinkedList<GameObject>();
        pressedButtons = new LinkedList<GameObject>();
        clickedFloors = new LinkedList<GameObject>();
        readyForClick = false;
        up = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            AddFloor(Floor1, Button1U);
        }
        if (Input.GetKeyDown("s"))
        {
            AddFloor(Floor2, Button2D);
        }
        if (Input.GetKeyDown("a"))
        {
            AddFloor(Floor2, Button2U);
        }
        if (Input.GetKeyDown("w"))
        {
            AddFloor(Floor3, Button3D);
        }
        if (Input.GetKeyDown("q"))
        {
            AddFloor(Floor3, Button3U);
        }
        if (Input.GetKeyDown("2"))
        {
            AddFloor(Floor4, Button4D);
        }

        if (clickedFloors.Count == 0)
        {
            if (floorsToVisit.Count > 0 && transform.position != floorsToVisit.First.Value.transform.position)
            {
                MoveToPosition(floorsToVisit.First.Value.transform.position);
            }
            if (floorsToVisit.Count > 0 && transform.position == floorsToVisit.First.Value.transform.position)
            {
                pressedButtons.First.Value.GetComponent<SpriteRenderer>().color = Color.red;
                pressedButtons.RemoveFirst();
                readyForClick = true;
                floorsToVisit.RemoveFirst();
            }
        } else
        {
            if (transform.position != clickedFloors.First.Value.transform.position)
            {
                MoveToPosition(clickedFloors.First.Value.transform.position);
            }
            if (transform.position == clickedFloors.First.Value.transform.position)
            {
                clickedFloors.RemoveFirst();
            }
        }
    }

    void MoveToPosition(Vector3 target)
    {
        if (!readyForClick)
        {
            if (clickedFloors.Count != 0)
            {
                if (Mathf.Abs(transform.position.y - Floor3.transform.position.y) < 0.01 && floorsToVisit.Contains(Floor3))
                {
                    readyForClick = true;
                    floorsToVisit.Remove(Floor3);
                    if (pressedButtons.Contains(Button3U))
                    {
                        pressedButtons.Find(Button3U).Value.GetComponent<SpriteRenderer>().color = Color.red;
                        pressedButtons.Remove(Button3U);
                    }
                    else
                    {
                        pressedButtons.Find(Button3D).Value.GetComponent<SpriteRenderer>().color = Color.red;
                        pressedButtons.Remove(Button3D);
                    }
                }
                if (Mathf.Abs(transform.position.y - Floor2.transform.position.y) < 0.01 && floorsToVisit.Contains(Floor2))
                {
                    readyForClick = true;
                    floorsToVisit.Remove(Floor2);
                    if (pressedButtons.Contains(Button2U))
                    {
                        pressedButtons.Find(Button2U).Value.GetComponent<SpriteRenderer>().color = Color.red;
                        pressedButtons.Remove(Button2U);
                    } else
                    {
                        pressedButtons.Find(Button2D).Value.GetComponent<SpriteRenderer>().color = Color.red;
                        pressedButtons.Remove(Button2D);
                    }
                }
                if (Mathf.Abs(transform.position.y - Floor1.transform.position.y) < 0.01 && floorsToVisit.Contains(Floor1))
                {
                    readyForClick = true;
                    floorsToVisit.Remove(Floor1);
                    pressedButtons.Find(Button1U).Value.GetComponent<SpriteRenderer>().color = Color.red;
                    pressedButtons.Remove(Button1U);
                }
                if (Mathf.Abs(transform.position.y - Floor4.transform.position.y) < 0.01 && floorsToVisit.Contains(Floor4))
                {
                    readyForClick = true;
                    floorsToVisit.Remove(Floor4);
                    pressedButtons.Find(Button4D).Value.GetComponent<SpriteRenderer>().color = Color.red;
                    pressedButtons.Remove(Button4D);
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * .5f);
        }
    }

    void AddFloor(GameObject floor, GameObject button)
    {
        floorsToVisit.AddLast(floor);
        button.GetComponent<SpriteRenderer>().color = Color.yellow;
        pressedButtons.AddLast(button);
    }

    public void AddClickedFloor(GameObject floor)
    {
        clickedFloors.AddLast(floor);
        readyForClick = false;
    }
}
