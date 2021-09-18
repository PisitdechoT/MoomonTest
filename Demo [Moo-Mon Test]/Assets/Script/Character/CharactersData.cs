using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharactersData
{
    public Character[] character;
}
[System.Serializable]
public class Character
{
    public int id;
    public string image;
    public int attack;
    public int level;
    public int HP;
    public float speed;
    //public int[] skill_ID;   
}