using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float moveDuration = 5f;

    public GameObject lightning;
    private float speed;
    private bool moving = true;
    private float initialX;

    void Start()
    {
        initialX = transform.position.x;
        StartCoroutine(Hid(moveDuration));
        speed = UnityEngine.Random.Range(-5f, 5f);
        StartCoroutine(ChangeSpeed(UnityEngine.Random.Range(0, 5f)));
    }


    void Update()
    {
        MoveObject(speed);

    }

    void MoveObject(float speed)
    {
        float newX = transform.position.x + Time.deltaTime * speed;

        // Check if the object is beyond 25 units from the initial position
        if (Mathf.Abs(newX - initialX) >= 25f)
        {
            speed *= -1;
        }
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    IEnumerator Hid(float t)
    {
        yield return new WaitForSeconds(t);
        moving = !moving;
        lightning.SetActive(true);
    }
    IEnumerator ChangeSpeed(float t)
    {
        yield return new WaitForSeconds(t);
        speed *= -1;
    }
}
