using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text currentTime;
    public TMP_Text bestTime;
    public float time = 0;
    public bool running = true;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (running) {
            string str = time.ToString("#.###");
            if (str.StartsWith(".")) str = "0" + str; // prepend a zero if it is < 1s
            currentTime.SetText($"Time: {str}");
            time += Time.fixedDeltaTime;
        }
    }
}
