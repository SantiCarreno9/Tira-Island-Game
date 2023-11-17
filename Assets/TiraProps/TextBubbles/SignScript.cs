using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SignScript : MonoBehaviour
{
    public GameObject bubbleAnim;
    public GameObject bubble;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bubbleAnim.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        bubble.SetActive(false);
    }




}
