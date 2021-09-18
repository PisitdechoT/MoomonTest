using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton : MonoBehaviour
{
    [SerializeField] private GameObject[] obj;
    public void ToggleItems()
    {
        if (obj[0].activeSelf==false)
        {
            foreach (var item in obj)
            {
                item.SetActive(true);
            }
        }
        else if (obj[0].activeSelf == true)
        {
            foreach (var item in obj)
            {
                item.SetActive(false);
            }
        }
    }
}
