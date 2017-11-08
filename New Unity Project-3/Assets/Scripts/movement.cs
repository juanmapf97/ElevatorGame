using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{


    //public float speed = 1;
    public GameObject gcf2, gcf1, gcf3, gcf4;
    public int userIs = 0;
    public int moving = 1;
    public bool click = false;
    public GameObject target;
    public GameObject ctarget;
    public Camera camera1;
    public bool up = false;
    public Queue<GameObject> clicks;
    public LinkedList<GameObject> keys = new LinkedList<GameObject>();
    public GameObject button1U;
    public GameObject button2U;
    public GameObject button2D;
    public GameObject button3U;
    public GameObject button3D;
    public GameObject button4D;
    private Queue<GameObject> pressedButtons = new Queue<GameObject>();


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (click)
        {
            if (userIs == 1 && keys.Count > 0 && transform.position == keys.First.Value.transform.position)
            {
                userIs = 0;
                click = false;
                keys.RemoveFirst();
            }
            Debug.Log("Waiting for input");
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = camera1.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Transform objectHit = hit.transform;

                    ctarget.transform.position = objectHit.transform.position;
                    if (ctarget.transform.position == gcf1.transform.position || ctarget.transform.position == gcf2.transform.position || ctarget.transform.position == gcf3.transform.position || ctarget.transform.position == gcf4.transform.position)
                    {
                        if (transform.position.y > ctarget.transform.position.y)
                        {
                            up = false;
                        }
                        else
                        {
                            up = true;
                        }
                        keys.AddFirst(ctarget);
                        userIs = 1;
                        moving = 0;
                        //click = false;
                    }
                }

            }
            
        }
        else
        {
            //if (userIs == 1 && transform.position == keys.First.Value.transform.position)
            //{
            //    userIs = 0;
            //    click = false;
            //    keys.RemoveFirst();
            //}
            //else
            //{
                //if (moving == 1 && !click) {
                Debug.Log("Doing update for input at least?");
                if (Input.GetKeyDown("z"))
                {
                    //target = gcf1;
                    keys.AddFirst(gcf1);
                    moving = 0;
                    //userIs = 0;
                    //click = true;
                    button1U.GetComponent<SpriteRenderer>().color = Color.yellow;
                    pressedButtons.Enqueue(button1U);
                }
                if (Input.GetKeyDown("s"))
                {
                    //target = gcf2;
                    keys.AddFirst(gcf2);
                    moving = 0;
                    //userIs = 0;
                    //click = true;
                    button2D.GetComponent<SpriteRenderer>().color = Color.yellow;
                    pressedButtons.Enqueue(button2D);
                }
                if (Input.GetKeyDown("a"))
                {
                    //target = gcf2;
                    keys.AddFirst(gcf2);
                    moving = 0;
                    //userIs = 0;
                    //click = true;
                    button2U.GetComponent<SpriteRenderer>().color = Color.yellow;
                    pressedButtons.Enqueue(button2U);
                }

                if (Input.GetKeyDown("w"))
                {
                    //target = gcf3;
                    keys.AddFirst(gcf3);
                    moving = 0;
                    //userIs = 0;
                    //click = true;
                    button3D.GetComponent<SpriteRenderer>().color = Color.yellow;
                    pressedButtons.Enqueue(button3D);
                }
                if (Input.GetKeyDown("q"))
                {
                    Debug.Log("Got the input Captain!");
                    //target = gcf3;
                    keys.AddFirst(gcf3);
                    moving = 0;
                    //userIs = 0;
                    //click = true;
                    button3U.GetComponent<SpriteRenderer>().color = Color.yellow;
                    pressedButtons.Enqueue(button3U);
                }
                if (Input.GetKeyDown("2"))
                {
                    //target = gcf4;
                    keys.AddFirst(gcf4);
                    moving = 0;
                    //userIs = 0;
                    //click = true;
                    button4D.GetComponent<SpriteRenderer>().color = Color.yellow;
                    pressedButtons.Enqueue(button4D);
                }

                //}

                if (keys.Count > 0 && transform.position.y != keys.First.Value.transform.position.y)
                {
                    transform.position = Vector3.MoveTowards(transform.position, keys.First.Value.transform.position, Time.deltaTime * .5f);
                    if (!click)
                    {
                        if (up)
                        {
                            if (transform.position.y < gcf2.transform.position.y)
                            {
                                if (Input.GetKeyDown("a"))
                                {
                                    target = gcf2;
                                    moving = 0;
                                    //userIs = 0;
                                    //click = true;
                                }
                            }
                            if (transform.position.y < gcf3.transform.position.y)
                            {
                                if (Input.GetKeyDown("q"))
                                {
                                    target = gcf3;
                                    moving = 0;
                                    //userIs = 0;
                                    //click = true;
                                }
                            }
                        }
                        else
                        {
                            if (transform.position.y > gcf2.transform.position.y)
                            {
                                if (Input.GetKeyDown("s"))
                                {
                                    target = gcf2;
                                    moving = 0;
                                    //userIs = 0;
                                    //click = true;
                                }
                            }
                            if (transform.position.y > gcf3.transform.position.y)
                            {
                                if (Input.GetKeyDown("w"))
                                {
                                    target = gcf3;
                                    moving = 0;
                                    //userIs = 0;
                                    //click = true;
                                }
                            }

                        }


                    }


                }

                if (keys.Count > 0 && transform.position == keys.First.Value.transform.position)
                {
                    moving = 1;
                    keys.RemoveFirst();
                    click = true;
                    if (pressedButtons.Count > 0)
                    {
                        pressedButtons.Dequeue().GetComponent<SpriteRenderer>().color = Color.red;
                    }
                }
            }

        //}
    }
}


