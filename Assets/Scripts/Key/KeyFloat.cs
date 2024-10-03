using System;
using UnityEngine;

public class KeyFloat : MonoBehaviour
{
    // Starts from bottom, floats up, then down

    private float distance = 0.5f; // y units how far up/down it should float
    private float time = 0.75f; // How long (seconds) should it float up/down for before changing
    private float rotation = 1f; // degrees to rotate

    private float t = 0;
    private bool up = true;

    private float baseY;

    void Start()
    {
        baseY = transform.position.y;
    }

    void FixedUpdate()
    {
        t += Time.fixedDeltaTime;

        float progress = EaseInOutSine(t / time);
        float y = distance * progress;

        if (!up) y = -y;
        transform.position = new Vector3(transform.position.x, baseY + y, transform.position.z);
        transform.rotation *= Quaternion.AngleAxis(rotation, Vector3.up);


        if (progress >= 1f)
        {
            up = !up;
            t = 0;
            baseY = transform.position.y;
        }
    }

    private float EaseInOutSine(float x)
    {
        return (float)(-(Math.Cos(Math.PI * x) - 1) / 2);
    }
}
