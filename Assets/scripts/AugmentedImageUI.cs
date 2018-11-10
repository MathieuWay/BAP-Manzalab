//-----------------------------------------------------------------------
// <copyright file="AugmentedImageVisualizer.cs" company="Google">
//
// Copyright 2018 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------

namespace GoogleARCore.Examples.AugmentedImage
{
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
    public class AugmentedImageUI : MonoBehaviour
    {
        //AR Core Image
        public AugmentedImage Image;
        public int IDCard;

        public String[] linkedinList;
        public String[] MailList;
        public String[] PhoneList;

        public GameObject canvas;
        public float RotationSpeed;

        //Facebook
        public GameObject Facebook;
        private RectTransform FacebookRect;
        private String facebookString;

        //Twitter
        public GameObject Twitter;
        private RectTransform TwitterRect;
        private String twitterString;

        //Linkedin
        public GameObject Linkedin;
        private RectTransform LinkedinRect;
        private String linkedinString;

        //Mail
        public GameObject Mail;
        private RectTransform MailRect;
        private String mailString;

        //Phone
        public GameObject Phone;
        private RectTransform PhoneRect;
        private String phoneString;

        public RectTransform[] LogoList;
        public bool[] sideList;

        //public RectTransform[] 

        private void Start()
        {
            FacebookRect = Facebook.GetComponent<RectTransform>();
            Facebook.GetComponent<UILogo>().URL = "fb://profile/1544625849163331";
            //Application.OpenURL("fb://profile/1544625849163331");

            TwitterRect = Twitter.GetComponent<RectTransform>();
            Twitter.GetComponent<UILogo>().URL = "twitter://user?screen_name=Manzalab";
            //Application.OpenURL("twitter://user?screen_name=Manzalab");

            LinkedinRect = Linkedin.GetComponent<RectTransform>();
            linkedinString = linkedinList[IDCard];
            Linkedin.GetComponent<UILogo>().URL = "Linkedin:" + linkedinString;

            MailRect = Mail.GetComponent<RectTransform>();
            mailString = MailList[IDCard];
            Mail.GetComponent<UILogo>().URL = "mailto:" + mailString;

            PhoneRect = Phone.GetComponent<RectTransform>();
            phoneString = PhoneList[IDCard];
            Phone.GetComponent<UILogo>().URL = "tel:" + phoneString;

        }
        /// <summary>
        /// The Unity Update method.
        /// </summary>
        public void Update()
        {
            if (Image == null || Image.TrackingState != TrackingState.Tracking)
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
            float halfWidth = Image.ExtentX / 2;
            float halfHeight = Image.ExtentZ / 2;

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
            //reset var
            offsetDroit = 0.5f;
            offsetGauche = 0.75f;


            //SetActive
            Facebook.SetActive(true);
            Twitter.SetActive(true);
            Linkedin.SetActive(true);
            Mail.SetActive(true);
            Phone.SetActive(true);
        }
    }
}
