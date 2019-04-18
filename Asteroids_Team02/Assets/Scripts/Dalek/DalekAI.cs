using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DalekAI : MonoBehaviour
{
    Animator anim;
    public GameObject player;
    public GameObject bullet;
    public GameObject turret;

    public GameObject GetPlayer()
    {
        return player;
    }

    void Fire()
    {
        Vector3 gunLocation = new Vector3(turret.transform.position.x, 
                    turret.transform.position.y + 1, 
                    turret.transform.position.z);
        GameObject b = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
        b.GetComponent<Rigidbody>().AddForce(turret.transform.forward * -1500);
    }

    public void StopFiring()
    {
        CancelInvoke("Fire");
    }

    public void StartFiring()
    {
        InvokeRepeating("Fire", 0.5f, 0.5f);
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetFloat("distance",
            Vector3.Distance(transform.position,
                             player.transform.position));    
    }
}
