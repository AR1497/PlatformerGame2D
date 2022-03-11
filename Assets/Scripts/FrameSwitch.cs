using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameSwitch : MonoBehaviour
{
    [SerializeField]
    private GameObject activeFrame;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharacterView>())
        {
            activeFrame.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<CharacterView>())
        {
            activeFrame.SetActive(false);
        }
    }
}
