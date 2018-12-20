using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sign : MonoBehaviour {

    public CanvasGroup canvasGroup;
    public GameObject dialogueObject;
    public Text dialogueText;

    public string signText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ShowButton());

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(HideButton());

        }
    }
    IEnumerator ShowButton()
    {
        float tempfloat = 1;

        // canvasGroup.alpha = Mathf.Lerp(0f, 1f, 0.01f*Time.deltaTime);
        canvasGroup.alpha = Mathf.SmoothDamp(1f, 0f, ref tempfloat, 120f);
        yield return null;
    }
    IEnumerator HideButton()
    {
        float tempfloat = 1;

        canvasGroup.alpha = Mathf.SmoothDamp(0f, 1f, ref tempfloat, 120f);


        yield return null;
    }

}
