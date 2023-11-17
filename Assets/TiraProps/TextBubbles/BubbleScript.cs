using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    public GameObject bubble;
    void callBubble()
    {

        bubble.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
