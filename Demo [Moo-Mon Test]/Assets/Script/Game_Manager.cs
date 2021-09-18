using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{

    [HideInInspector] public GameCharacter playerTarget = null;
    [HideInInspector] public GameCharacter enemyTarget = null;
    [HideInInspector] public List<GameCharacter> playerTeam;
    [HideInInspector] public List<GameCharacter> enemyTeam;
    [HideInInspector] List<Skill> playerSkill;
    [HideInInspector] public float skillTimer;
    [SerializeField] int gameSpeed = 1;
    public int aGameSpeed { get { return gameSpeed; } }
    public static Game_Manager manager = null;
    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        playerTeam = new List<GameCharacter>();
        enemyTeam = new List<GameCharacter>();
        playerSkill = new List<Skill>();        
        //foreach (var item in playerTeam)//placeholder for add skill
        //{
        //    foreach (var ability in item.skill)
        //    {
        //        playerSkill.Add(ability);
        //    }
        //}
        skillTimer = 0;
    }
    private void Update()
    {
        if (skillTimer > 0)
        {
            skillTimer -= Time.deltaTime;
        }
        else if (skillTimer < 0)
        {
            skillTimer = 0;
        }
        PTarget();
        ETarget();
    }
    public void Pause()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = gameSpeed;
        }

    }
    public void PTarget()
    {
        if (playerTarget == null && enemyTeam.Count > 0)
        {
            var rand = UnityEngine.Random.Range(0, enemyTeam.Count);
            playerTarget = enemyTeam[rand].GetComponent<GameCharacter>();
            print(playerTarget.id + " is players target"+ enemyTeam.Count);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.GetComponent<GameCharacter>())
            {
                foreach (var item in enemyTeam)
                {
                    if (hit.transform.gameObject.GetComponent<GameCharacter>() == item)
                    {
                        playerTarget = item;
                        print("Select" + item.id);
                    }
                }
            }
        }
    }
    public void ETarget()
    {
        if (enemyTarget == null && playerTeam.Count > 0)
        {
            var rand = UnityEngine.Random.Range(0, playerTeam.Count);
            enemyTarget = playerTeam[rand].GetComponent<GameCharacter>();
            print(enemyTarget.id + " is enemies target"+ playerTeam.Count);
        }
    }


}
