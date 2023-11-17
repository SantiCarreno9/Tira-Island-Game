using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
void hideself()
    {
        GameObject lightContainer = GameObject.FindGameObjectWithTag("Light");
        Destroy(lightContainer);
    }
}
