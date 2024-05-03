using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BoxCounter : Box
{
    [Header("Color Caja")]
    [SerializeField] String ColorBox = "White";
    private int score = 0;
    private int totalItems = 0;
    public event Action CounterChange;

    [Header("Sonidos")]
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip s_Correct;
    [SerializeField] private AudioClip s_Wrong;
    [SerializeField] private float volume = 1.0f;


    private void OnTriggerEnter(Collider other)
    {
        ItemColor itemColor = other.GetComponent<ItemColor>();
        //it depends of color this method add or substract 1 and 2 points
        if (itemColor.color == ColorBox)
        {
            score += 1;
            m_AudioSource.PlayOneShot(s_Correct, volume); //if you get a match shoot it sounds a correct sound
        }
        else if (itemColor.color == "Violet")
            switch (ColorBox)
            {
                case "Red":
                    score += 2;
                    m_AudioSource.PlayOneShot(s_Correct, volume);
                    break;
                case "Blue":
                    score += 2;
                    m_AudioSource.PlayOneShot(s_Correct, volume);
                    break;
                default:
                    score -= 2;
                    m_AudioSource.PlayOneShot(s_Wrong, volume); //if you get a no-match shoot it sounds a wrong sound
                    break;
            }
        else if (itemColor.color == "Orange")
            switch (ColorBox)
            {
                case "Red":
                    m_AudioSource.PlayOneShot(s_Correct, volume);
                    score += 2;
                    break;
                case "Yellow":
                    m_AudioSource.PlayOneShot(s_Correct, volume);
                    score += 2;
                    break;
                default:
                    m_AudioSource.PlayOneShot(s_Wrong, volume);
                    score -= 2;
                    break;
            }
        else if (itemColor.color == "Green")
            switch (ColorBox)
            {
                case "Yellow":
                    m_AudioSource.PlayOneShot(s_Correct, volume);
                    score += 2;
                    break;
                case "Blue":
                    m_AudioSource.PlayOneShot(s_Correct, volume);
                    score += 2;
                    break;
                default:
                    m_AudioSource.PlayOneShot(s_Wrong, volume);
                    score -= 2;
                    break;
            }
        else
        {
            m_AudioSource.PlayOneShot(s_Wrong, volume);
            score -= 1;
        }

        totalItems +=1;
        CounterChange?.Invoke();
    }

    public void ResetScore()
    {
        score = 0;
        totalItems = 0;
        CounterChange?.Invoke();
    }

    public override int GetScore()
    {
        return score;
    }

    public override int GetTotalItems()
    {
        return totalItems;
    }
}
