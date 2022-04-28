using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHome : MonoBehaviour
{
    public AudioSource audioSource;
    private void OnEnable()
    {
        audioSource.Play();
    }
}
