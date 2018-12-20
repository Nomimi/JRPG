using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleManagerScript : MonoBehaviour {

    double activeTurn = 0;

    public List<Image> turnImages;
    public List<BaseCharacter> HeroScripts;

    public List<int> timeTillTurn;
    // Use this for initialization
    void Start () {

        foreach (BaseCharacter BH in HeroScripts)
             {
            timeTillTurn.Add(BH.agility);

             }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void NextTurn() {

        foreach (BaseCharacter BH in HeroScripts)
        {
            BH = 0;

        }


        activeTurn++;
        Debug.Log("Its turn: " + activeTurn);
    }
}
