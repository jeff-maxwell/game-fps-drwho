using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAI : MonoBehaviour
{
    public GameObject dalek1;
    public GameObject dalek2;
    public GameObject dalek3;
    public GameObject dalek4;
    public GameObject dalek5;
    GameObject[] waypoints;
    int currentWP;

    private void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    }
    void Start()
    {   
        for (int x = 0; x < 5; x++)
        {
            int dalekNumber = Random.Range(1, 5);
            currentWP = Random.Range(0, waypoints.Length - 1);
            GameObject b = new GameObject();

            switch (dalekNumber)
            {
                case 1:
                    b = Instantiate(dalek1, waypoints[currentWP].transform.position, waypoints[currentWP].transform.rotation);
                    break;
                case 2:
                    b = Instantiate(dalek2, waypoints[currentWP].transform.position, waypoints[currentWP].transform.rotation);
                    break;
                case 3:
                    b = Instantiate(dalek3, waypoints[currentWP].transform.position, waypoints[currentWP].transform.rotation);
                    break;
                case 4:
                    b = Instantiate(dalek4, waypoints[currentWP].transform.position, waypoints[currentWP].transform.rotation);
                    break;
                case 5:
                    b = Instantiate(dalek5, waypoints[currentWP].transform.position, waypoints[currentWP].transform.rotation);
                    break;
                default:
                    b = Instantiate(dalek1, waypoints[currentWP].transform.position, waypoints[currentWP].transform.rotation);
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
