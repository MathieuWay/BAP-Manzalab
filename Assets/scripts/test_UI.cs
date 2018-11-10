using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using GoogleARCore;
using GoogleARCoreInternal;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Uses 4 frame corner objects to visualize an AugmentedImage.
/// </summary>
public class test_UI : MonoBehaviour
{
    public String[] MailList;
    public String[] PhoneList;

    public Transform target;
    public float RotationSpeed;

    //Facebook
    public GameObject Facebook;
    private String facebookString;

    //Twitter
    public GameObject Twitter;
    private String twitterString;

    //Linkedin
    public GameObject Linkedin;
    private String linkedinString;

    //Mail
    public GameObject Mail;
    private String mailString;

    //Phone
    public GameObject Phone;
    private String phoneString;

    public RectTransform[] LogoList;
    public bool[] sideList;//Si faux Position Gauche Sinon droit

    

    private void Start()
    {

    }
    /// <summary>
    /// The Unity Update method.
    /// </summary>
    public void Update()
    {
        if (target.gameObject.activeSelf == false)
        {
            //Ar Core ne track plus l'image on cache l'ui
            Facebook.SetActive(false);
            Twitter.SetActive(false);
            Linkedin.SetActive(false);
            Mail.SetActive(false);
            Phone.SetActive(false);
            return;
        }
        
        //Get Half Size of image
        float halfWidth = target.localScale.x / 2;
        float halfHeight = target.localScale.y / 2;

        //SetActive
        Facebook.SetActive(true);
        Twitter.SetActive(true);
        Linkedin.SetActive(true);
        Mail.SetActive(true);
        Phone.SetActive(true);

        float offsetDroit = 0.5f;
        float offsetGauche = 0.75f;

        for (int i = 0; i < LogoList.Length; i++)
        {


            //Position
            if (sideList[i] == true)
            {
                //Right Side
                LogoList[i].transform.localPosition = ((halfWidth + halfWidth * 0.25f) * Vector3.right) + ((halfHeight - halfHeight * offsetDroit) * Vector3.forward);
                offsetDroit += 0.5f;
            }
            else
            {
                //Left Side
                LogoList[i].transform.localPosition = ((halfWidth + halfWidth * 0.25f) * Vector3.left) + ((halfHeight - halfHeight * offsetGauche) * Vector3.forward);
                offsetGauche += 0.5f;
            }

            //rotation
            LogoList[i].Rotate(Vector3.up * RotationSpeed * Time.deltaTime);

            //Size
            LogoList[i].sizeDelta = new Vector2(halfWidth * 0.5f, halfWidth * 0.5f);

            //Flip Handling
            if (LogoList[i].localRotation.eulerAngles.x > 180 && LogoList[i].localRotation.eulerAngles.x < 360)
                LogoList[i].localScale = new Vector3(-1, 1, 1);
            else
                LogoList[i].localScale = new Vector3(1, 1, 1);
        }
    }
}
