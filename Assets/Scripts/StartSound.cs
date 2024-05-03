using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class StartSound : MonoBehaviour
{
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip ambientalSound;
    private float volume = 0.125f;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        m_AudioSource.PlayOneShot(ambientalSound, volume);
    }
}
