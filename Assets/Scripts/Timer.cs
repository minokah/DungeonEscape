using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text currentTime;
    public TMP_Text bestTime;
    public float time = 0;
    public bool running = false;

    // Update is called once per frame
    void Start()
    {
        Dictionary<string, float> data = Leaderboard.GetScores();
        if (data.Count > 0)
        {
            float val = data.ElementAt(0).Value;
            string str = val.ToString("#.##");
            if (str.StartsWith(".")) str = "0" + str; // prepend a zero if it is < 1s
            bestTime.SetText($"Best: {str}");
        }
    }

    void Update()
    {
        if (running) {
            string str = time.ToString("#.##");
            if (str.StartsWith(".")) str = "0" + str; // prepend a zero if it is < 1s
            currentTime.SetText($"Time: {str}");
            time += Time.deltaTime;
        }
    }
}
