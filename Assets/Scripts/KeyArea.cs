using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyArea : MonoBehaviour
{
    public RawImage red, green, blue;
    private bool redGet, greenGet, blueGet;

    public void GrabKey(string s)
    {
        switch (s)
        {
            case "red":
                SetRedKeyGrabbed(true);
                break;
            case "green":
                SetGreenKeyGrabbed(true);
                break;
            case "blue":
                SetBlueKeyGrabbed(true);
                break;
        }
    }

    private void SetRedKeyGrabbed(bool t)
    {
        if (t)
        {
            redGet = true;
            red.uvRect = new Rect(0.25f, 0, 0.25f, 1);
        }
        else
        {
            redGet = false;
            red.uvRect = new Rect(0, 0, 0.25f, 1);
        }
    }

    private void SetGreenKeyGrabbed(bool t)
    {
        if (t)
        {
            greenGet = true;
            green.uvRect = new Rect(0.5f, 0, 0.25f, 1);
        }
        else
        {
            greenGet = false;
            green.uvRect = new Rect(0, 0, 0.25f, 1);
        }
    }

    private void SetBlueKeyGrabbed(bool t)
    {
        if (t)
        {
            blueGet = true;
            blue.uvRect = new Rect(0.75f, 0, 0.25f, 1);
        }
        else
        {
            blueGet = false;
            blue.uvRect = new Rect(0, 0, 0.25f, 1);
        }
    }
}
