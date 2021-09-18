using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class HPAndLevelHeaderValue : MonoBehaviour
{
    GameCharacter chara;
    [SerializeField] Slider HPBar;
    [SerializeField] TextMeshProUGUI level;
    void Start()
    {
    }
    void Update()
    {
        HPBar.value = chara.HP;
    }
    public void setValue(GameCharacter chara)
    {
        this.chara = chara;
        level.text = this.chara.level.ToString();
        HPBar.maxValue = chara.maxHP;
        HPBar.value = chara.HP;
    }
}
