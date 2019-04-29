using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayLevelMusic : MonoBehaviour
{
    public bool CallCamShake = true;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<AudioSource>().playOnAwake = false;
        this.GetComponent<AudioSource>().loop = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!this.GetComponent<AudioSource>().isPlaying)
            {
                this.GetComponent<AudioSource>().Play();
                if (CallCamShake)
                {

                    StartCoroutine(other.GetComponentInChildren<CameraShake>().Shake(.4f, .3f));
                }
            }
        }
        
    }
}
