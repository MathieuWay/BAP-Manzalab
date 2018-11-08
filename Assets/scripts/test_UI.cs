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
    public Transform target;
    public float RotationSpeed;

    //Facebook
    public GameObject Facebook;
    private RectTransform FacebookRect;

    //Twitter
    public GameObject Twitter;
    private RectTransform TwitterRect;

    //Linkedin
    public GameObject Linkedin;
    private RectTransform LinkedinRect;

    //Mail
    public GameObject Mail;
    private RectTransform MailRect;
    private String mailString;

    //Phone
    public GameObject Phone;
    private RectTransform PhoneRect;
    private String phoneString;

    public RectTransform[] LogoList;
    public bool[] sideList;//Si faux Position Gauche Sinon droit

    private void Start()
    {
        //Get RectTransform
        FacebookRect = Facebook.GetComponent<RectTransform>();
        TwitterRect = Twitter.GetComponent<RectTransform>();
        LinkedinRect = Linkedin.GetComponent<RectTransform>();
        MailRect = Mail.GetComponent<RectTransform>();
        PhoneRect = Phone.GetComponent<RectTransform>();

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

        /*Transform Calculation*/

        //Position
        //Right Side
        Facebook.transform.localPosition = ((halfWidth + halfWidth * 0.25f) * Vector3.right) + ((halfHeight - halfHeight * 0.5f) * Vector3.forward);
        Twitter.transform.localPosition = ((halfWidth + halfWidth * 0.25f) * Vector3.right) + ((halfHeight - halfHeight * 1f) * Vector3.forward);
        Linkedin.transform.localPosition = ((halfWidth + halfWidth * 0.25f) * Vector3.right) + ((halfHeight - halfHeight * 1.5f) * Vector3.forward);
        //Left Side
        Mail.transform.localPosition = ((halfWidth + halfWidth * 0.25f) * Vector3.left) + ((halfHeight - halfHeight * 0.75f) * Vector3.forward);
        Phone.transform.localPosition = ((halfWidth + halfWidth * 0.25f) * Vector3.left) + ((halfHeight - halfHeight * 1.25f) * Vector3.forward);

        //rotation
        FacebookRect.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);
        TwitterRect.Rotate(Vector3.up * (RotationSpeed * 1.5f) * Time.deltaTime);
        LinkedinRect.Rotate(Vector3.up * (RotationSpeed * 2f) * Time.deltaTime);
        MailRect.Rotate(Vector3.up * (RotationSpeed * 1.25f) * Time.deltaTime);
        PhoneRect.Rotate(Vector3.up * (RotationSpeed * 1.75f) * Time.deltaTime);

        //Size
        FacebookRect.sizeDelta = new Vector2(halfWidth * 0.5f, halfWidth * 0.5f);
        TwitterRect.sizeDelta = new Vector2(halfWidth * 0.5f, halfWidth * 0.5f);
        LinkedinRect.sizeDelta = new Vector2(halfWidth * 0.5f, halfWidth * 0.5f);
        MailRect.sizeDelta = new Vector2(halfWidth * 0.5f, halfWidth * 0.5f);
        PhoneRect.sizeDelta = new Vector2(halfWidth * 0.5f, halfWidth * 0.5f);

        //Flip Handling

        //Facebook
        if (FacebookRect.localRotation.eulerAngles.x > 180 && FacebookRect.localRotation.eulerAngles.x < 360)
            FacebookRect.localScale = new Vector3(-1, 1, 1);
        else
            FacebookRect.localScale = new Vector3(1, 1, 1);
        //Twitter
        if (TwitterRect.localRotation.eulerAngles.x > 180 && TwitterRect.localRotation.eulerAngles.x < 360)
            TwitterRect.localScale = new Vector3(-1, 1, 1);
        else
            LinkedinRect.localScale = new Vector3(1, 1, 1);
        //Linkedin
        if (LinkedinRect.localRotation.eulerAngles.x > 180 && LinkedinRect.localRotation.eulerAngles.x < 360)
            LinkedinRect.localScale = new Vector3(-1, 1, 1);
        else
            LinkedinRect.localScale = new Vector3(1, 1, 1);
        //Mail
        if (MailRect.localRotation.eulerAngles.x > 180 && MailRect.localRotation.eulerAngles.x < 360)
            MailRect.localScale = new Vector3(-1, 1, 1);
        else
            MailRect.localScale = new Vector3(1, 1, 1);
        //Phone
        if (MailRect.localRotation.eulerAngles.x > 180 && MailRect.localRotation.eulerAngles.x < 360)
            MailRect.localScale = new Vector3(-1, 1, 1);
        else
            MailRect.localScale = new Vector3(1, 1, 1);


        //SetActive
        Facebook.SetActive(true);
        Twitter.SetActive(true);
        Linkedin.SetActive(true);
        Mail.SetActive(true);
        Phone.SetActive(true);
        /*
         * float offsetDroit = 0,25;
         * float offsetGauche =0;
        * for int i ; i<logoList.length ; i++
        *       Si SideList[i] == vrai
        *           //Set position Droit pour logoList[i]
        *           //OffsetDroit += 0.5;
        *       sinon
        *           //Set position Gauche
        *      Set Rotation
        *      Set size
        *      Handle Flip
        */
    }
}
