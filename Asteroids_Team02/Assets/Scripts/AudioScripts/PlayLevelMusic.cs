using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayLevelMusic : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<AudioSource>().playOnAwake = false;
        this.GetComponent<AudioSource>().loop = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        this.GetComponent<AudioSource>().Play();
    }
}
