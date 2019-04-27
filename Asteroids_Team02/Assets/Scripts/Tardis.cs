using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tardis : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.tag);
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(2);
        }
    }
}
