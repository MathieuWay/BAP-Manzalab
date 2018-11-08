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

        public String[] MailList;
        public String[] PhoneList;

        public GameObject canvas;
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

        //public RectTransform[] 

        private void Start()
        {
            //Get RectTransform
            FacebookRect = Facebook.GetComponent<RectTransform>();
            TwitterRect = Twitter.GetComponent<RectTransform>();
            LinkedinRect = Linkedin.GetComponent<RectTransform>();


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

            /*Transform Calculation*/

            //Position
            //Right Side
            Facebook.transform.localPosition = ((halfWidth + halfWidth * 0.25f) * Vector3.right) + ((halfHeight - halfHeight * 0.5f)  * Vector3.forward);
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
             * foreach logo in logoTab
             *      Setposition
             *      Set Rotation
             *      Set size
             *      Handle Flip
             */
        }
    }
}
