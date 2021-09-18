using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCharacter : MonoBehaviour
{    
    #region Set The Character Data

    public int id { get; private set; }
    public string image { get; private set; }
    public int attack { get; private set; }
    public int level { get; private set; }
    public int maxHP { get; private set; }
    public int HP { get; private set; }
    public float attackInterval { get; private set; }
    public float Team { get; private set; }
    public Skill[] skill { get; private set; }    
    
    SpriteRenderer characterImage;
    bool isCharacterSet;

    public int fakeIDForTest;//test id
    public int fakeTeamForTest;//test

    public void SetData(int id)
    {
        foreach (var item in data.character)
        {
            if (item.id==id)
            {
                this.id = item.id;
                this.image = item.image;
                this.attack = item.attack;
                this.level = item.level;
                this.maxHP = item.HP;
                this.attackInterval = item.speed;
                this.Team = fakeTeamForTest;//placeholder for team
                this.skill = null;//placeholder for skill

                break;
            }
        }
        MakeCharacter();
    }
    public void MakeCharacter()
    {        
        characterImage =gameObject.GetComponentInChildren<SpriteRenderer>();
        characterImage.sprite = Resources.Load<Sprite>("Images/"+image);        
        if (Team == 0)
        {
            manager.playerTeam.Add(this);
            characterImage.flipX = true;
        }
        else
        {
            manager.enemyTeam.Add(this);
        }
        HP = maxHP;
        gameObject.GetComponentInChildren<HPAndLevelHeaderValue>().setValue(this);
        //add things here
        isCharacterSet = true;
    }
    #endregion
    CharactersData data;    
    Game_Manager manager;
    float attackCD;    
    void Start()
    {   
        manager= FindObjectOfType<Game_Manager>();
        data = FindObjectOfType<LoadFile>().character;
        SetData(fakeIDForTest);  
        attackCD = attackInterval;
        
    }
    void Update()
    {
        if (isCharacterSet && manager.skillTimer<=0&&manager.enemyTeam.Count>0 && manager.playerTeam.Count > 0)
        {
            #region Death
            if (HP<=0)
                {
                //add something here if need before destroy
                    if (manager.enemyTarget=this)
                    {
                        manager.enemyTarget = null;
                        manager.playerTeam.Remove(this);
                    }
                    if (manager.playerTarget = this)
                    {
                        manager.playerTarget = null;
                        manager.enemyTeam.Remove(this);
                    }
                    Destroy(gameObject);
                }
            #endregion
            #region Normal Attack
            if (manager.playerTarget==null)
            {
                manager.PTarget();
            }
            attackCD -= Time.deltaTime;
            if (attackCD<=0)
            {
                NormalAttack();
                attackCD = attackInterval;
            }
            #endregion
            #region Skill
            Skill();
            #endregion
            #region Buff
            //placeholder buff here
            #endregion
        }
    }
    public void NormalAttack()
    {
        //do hit animation here
        if (Team==0)
        {
            manager.playerTarget.receivedDamage(attack);
        }
        else
        {
            manager.enemyTarget.receivedDamage(attack);
        }
        
    }
    public void receivedDamage (int damage)
    {
        //do get hit animation h
        this.HP -= damage;
    }
    public void Skill()
    {
        //placeholder for skill
    }
}
