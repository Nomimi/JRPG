using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeRoom : MonoBehaviour {


    public Vector2 cameraChange;
    public Vector3 playerChange;

    private CameraMovement camMov;
    public string placeName;
    public GameObject text;
    public Text placeText;
    public bool showText;


	// Use this for initialization
	void Start () {

        camMov = Camera.main.GetComponent<CameraMovement>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (showText)
        {
            StartCoroutine(showName());
        }
        if (collision.CompareTag("Player"))
        {
            camMov.minXPosition += cameraChange;
            camMov.maxXPosition += cameraChange;
            collision.transform.position += playerChange;
        }


    }

    private IEnumerator showName()

    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);

    }
}
