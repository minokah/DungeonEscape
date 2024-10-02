using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGrab : MonoBehaviour
{
    // On grabbing the key, update ui and make invisible
    public string colour;
    public AudioSource pickup;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            pickup.Play();
            gameObject.SetActive(false);
            Global.KeyArea.GrabKey(colour);
        }
    }
}
