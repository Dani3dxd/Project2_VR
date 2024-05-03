using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TutorialCanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject tuto1;
    [SerializeField] private GameObject tuto2;
    [SerializeField] private GameObject tuto3;

    public void whenbuttonBackClick()
    {
        if (tuto3.activeInHierarchy)
        {
            tuto2.SetActive(true);
            tuto3.SetActive(false);
        }
        else if (tuto2.activeInHierarchy)
        {
            tuto1.SetActive(true);
            tuto2.SetActive(false);
        }
        else if (tuto1.activeInHierarchy)
        {
            tuto3.SetActive(true);
            tuto1.SetActive(false);
        }
    }
}
