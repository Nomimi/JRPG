using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleCanvasManager : MonoBehaviour {

    public BMSTimeline myBMSTimeline;


    public List <GameObject> healthBar;
    public List<BaseCharacter> myCharacters;

    public SpriteRenderer mySpriteRenderer;

    public Image img;
    public float hppercentage;
    // Use this for initialization
    void Start()
    {
        foreach (BaseCharacter BC in myCharacters)
        {
            healthBar.Add(Instantiate(healthBar[0], healthBar[(healthBar.Count - 1)].transform.position + new Vector3(0, -200, 0), Quaternion.identity));



        }
        

    }

    // Update is called once per frame
    void Update()
    {
        foreach(BaseCharacter BC in myCharacters)
            {

            hppercentage = (BC.curHP / BC.baseHP);
            img.transform.localScale = new Vector3(hppercentage, 1, 1);

        }

        //sr.transform.localScale = new Vector3 (100, 100, 100);
    }
}
