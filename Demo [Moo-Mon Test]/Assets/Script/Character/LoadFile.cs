using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFile : MonoBehaviour
{
    public TextAsset data;
    [HideInInspector] public CharactersData character;
    public GameObject[] obj;

    void Start()
    {
        character = JsonUtility.FromJson<CharactersData>(data.text);
        foreach (var item in obj)
        {
            item.SetActive(true);
        }
    }
}
