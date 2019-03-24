using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BMSTimeline : MonoBehaviour {




    public GameObject myBattleCanvas;
    public List<BaseCharacter> HeroScripts;
    public CombatSpells myCombatSpells;




    public List<Image> timeLineSprites;
    public float ticksPerSecond = 1.0f;


    public List<BaseEnemy> Enemys;
    int charaktersTurn;
    int target = 0;
    

    //Decides if the time counts on, may be used to make it a turn based battle system

    bool floatingTime;
    bool battleIsActive = true;


    // Use this for initialization
    void Start()
    {
        myCombatSpells = GetComponent<CombatSpells>();
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AbilityButton(int abilityIndex)
    {
        timeLineSprites[charaktersTurn].transform.localPosition = new Vector3(-800, 0, 0);
        myCombatSpells.ExecuteAbility(abilityIndex, HeroScripts[charaktersTurn], HeroScripts[1]);
        battleIsActive = true;
        StartCoroutine(Timer());
    }

    public void ActionButton()
    {


        //CS.BasicAttack(HeroScripts[charaktersTurn], HeroScripts[target]);
        timeLineSprites[charaktersTurn].transform.localPosition = new Vector3(-800, 0, 0);
        battleIsActive = true;
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (battleIsActive)
        {
            yield return new WaitForSeconds((1.0f / ticksPerSecond));
            Timeliner();
        }
    }

    void Timeliner()
    {

        //while (battleIsActive)
        //{
            for (int i = 0; i < timeLineSprites.Count; i++)
            {
                timeLineSprites[i].transform.Translate(new Vector3((HeroScripts[i].agility*3)*Time.deltaTime, 0, 0));


                if (timeLineSprites[i].transform.localPosition.x >= 800)
                {


                if (HeroScripts[i].playerCharakter)
                {

           
                 
                    battleIsActive = false;
                    charaktersTurn = i;
                    break;
                }
                else
                {
                   
                    
                  
                    
                    charaktersTurn = i;
                    myCombatSpells.ExecuteAbility(1, HeroScripts[charaktersTurn], HeroScripts[1]);
                    timeLineSprites[charaktersTurn].transform.localPosition = new Vector3(-800, 0, 0);
                   
                    break;
                }

                }

            }
        //}


    }



}
