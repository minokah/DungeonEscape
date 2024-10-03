using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    public AudioSource sfx;
    public GameObject door;
    public string key;
    public bool active = false;

    public virtual void Update() {
        if (active && Input.GetKeyDown(KeyCode.E)) {
            sfx.Play();
            door.SetActive(false);
            Global.KeyPrompt.SetVisible(false);
            active = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (Global.KeyArea.Grabbed(key) && other.tag.Equals("Player")) {
            Global.KeyPrompt.SetText($"[ E ] Use {key.ToUpper()} Key");
            Global.KeyPrompt.SetVisible(true);
            active = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag.Equals("Player")) {
            Global.KeyPrompt.SetVisible(false);
            active = false;
        }
    }
}
