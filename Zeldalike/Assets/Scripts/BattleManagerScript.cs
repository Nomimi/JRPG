using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleManagerScript : MonoBehaviour {

    double activeTurn = 0;
    int time = 0;


    public float ticksPerSecond = 10.0f;


    public List<BaseCharacter> HeroScripts;
    public List<Image> turnSprites;


    public List<int> timeTillTurn;


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
            Debug.Log(HeroScripts[i].gameObject.name + "is in" + HeroScripts[i].timeTillTurn + "turns");
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
            recalculateTurnSprites();
        }
    }
}
