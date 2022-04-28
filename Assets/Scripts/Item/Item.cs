using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public GameObject item;
    [HideInInspector]
    public GameObject showText;
    [HideInInspector]
    public AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }

    protected virtual IEnumerator DeleteGameobject()
    {
        yield return new WaitForSeconds(.3f);
        //showText.SetActive(false);
        Destroy(gameObject);
    }
}
