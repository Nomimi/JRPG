using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BarHandler : MonoBehaviour {


    public Sprite healthBar;
    public BaseCharacter myCharacter;
    public SpriteRenderer mySpriteRenderer;
  
    public Image img;
    public float hppercentage;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        hppercentage = (myCharacter.curHP / myCharacter.baseHP);
        img.transform.localScale = new Vector3(hppercentage, 1, 1);
        //sr.transform.localScale = new Vector3 (100, 100, 100);
	}
}
