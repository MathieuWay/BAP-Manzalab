using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WifiUI : MonoBehaviour {
    public Transform Camera;
    public Transform box;
    public Transform warningText;

    public List<Transform> antennas;
    public Sprite[] WifiImages;

    //Range
    [Header("Range in meters")]
    public float goodRange = 1f;
    public float mediumRange = 1.5f;
    public float badRange = 2f;
    //public float noRange;

    private Image WifiImage;

    private static WifiUI instance;
    public static WifiUI Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<WifiUI>();
            if (instance == null)
                Debug.LogError("No Wifi UI");
            return instance;
        }
    }

	// Use this for initialization
	void Start () {
        WifiImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        float Closest = Mathf.Infinity;
        foreach (Transform antenna in antennas)
        {
            float distance = Vector3.Distance(Camera.position, antenna.position);
            if ( distance < Closest)
                Closest = distance;
        }
        if(box != null)
        {
            float distancebox = Vector3.Distance(Camera.position, box.position);
            if (distancebox < Closest)
                Closest = distancebox;
        }

        if(Closest < goodRange)
            WifiImage.sprite = WifiImages[0];
        else if (Closest < mediumRange)
            WifiImage.sprite = WifiImages[1];
        else if (Closest < badRange)
            WifiImage.sprite = WifiImages[2];
        else
            WifiImage.sprite = WifiImages[3];
        if (Closest > 1f && box != null)
            warningText.gameObject.SetActive(true);
        else
            warningText.gameObject.SetActive(false);

    }
}
