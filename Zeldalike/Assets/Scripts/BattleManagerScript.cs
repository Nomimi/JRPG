using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleManagerScript : MonoBehaviour {



    BMSTimeline myBMSTimeline;

    double activeTurn = 0;
    float time = 0;


    public float ticksPerSecond = 10.0f;


    public List<BaseCharacter> HeroScripts;
    public List<Image> turnSprites;
    public List<Image> timeLineSprites;


    public List<float> timeTillTurn;
    public List<BaseEnemy> Enemys;


    //Decides if the time counts on, may be used to make it a turn based battle system

    bool floatingTime;
    bool battleIsActive = true;


    // Use this for initialization
    void Start() {

        foreach (BaseCharacter BH in HeroScripts)
        {
            timeTillTurn.Add(BH.agility);

        }


        for (int i = 0; i <= HeroScripts.Count - 1; i++)
        {
                      HeroScripts[i].timeTillTurn = HeroScripts[i].agility;
        }

        StartCoroutine(TurnTimer());
    }

    // Update is called once per frame
    void Update() {
        Timeliner();
    }

    void recalculateTurnSprites()
    {
        HeroScripts.Sort(SortByWaitingTurns);

        for (int i = 0; i <= turnSprites.Count - 1; i++)
        { turnSprites[i].sprite = HeroScripts[i % (HeroScripts.Count)].battleAvatar;
            //Debug.Log("I did do this");
        }

    }

    static int SortByWaitingTurns(BaseCharacter H1, BaseCharacter h2)
    {

        return H1.timeTillTurn.CompareTo(h2.timeTillTurn);
    }

    //void sortbyTimeTillTurn()
    //{
        


    //}

    public void CaclulateWaitingTime() {
        //Debug.Log("Its turn: " + activeTurn);
        for (int i = 0; i <= HeroScripts.Count - 1; i++)
        {
            HeroScripts[i].timeTillTurn--;
            if (HeroScripts[i].timeTillTurn < 0)
            {
                battleIsActive = false;
                Debug.Log("Something seems to be 0");
                HeroScripts[i].timeTillTurn = HeroScripts[i].agility; }

        }
    



        //foreach (BaseCharacter BH in HeroScripts)
        //{
        //    timeTillTurn[BH.turnCounter] = ;

        //}


        
        //Debug.Log("Its turn: " + activeTurn);
        for (int i = 0; i <= HeroScripts.Count-1; i++)
        {
            //Debug.Log(HeroScripts[i].gameObject.name + "is in" + HeroScripts[i].timeTillTurn + "turns");
        }
        
    }

    public void TurnButton()
    {
        battleIsActive = true;
        StartCoroutine(TurnTimer());
    }

    IEnumerator TurnTimer()
    {

        while (battleIsActive)
        {
            Debug.Log("Wait for" + (1f / ticksPerSecond));
            yield return new WaitForSeconds((1.0f / ticksPerSecond));
            activeTurn++;
            CaclulateWaitingTime();
            //recalculateTurnSprites();
        }
    }

    void Timeliner()
    {

        for(int i = 0; i < timeLineSprites.Count; i++)
        {
         timeLineSprites[i].transform.Translate( new Vector3((HeroScripts[i].agility/10.0f), 0,0));


            if (timeLineSprites[i].transform.localPosition.x >= 800)
            {
                timeLineSprites[i].transform.localPosition = new Vector3 (-800, 0, 0);

            }

        }
       
        
     
    }



}
