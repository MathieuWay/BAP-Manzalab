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

        //Linkedin
        public UILogo LinkedinURL;

        //Mail
        public UILogo MailURL;

        //Phone
        public UILogo PhoneURL;

        public RectTransform[] LogoList;
        public bool[] sideList;

        //public RectTransform[] 

        private void Start()
        {
            LinkedinURL.GetComponent<UILogo>().URL = linkedinList[IDCard];
            MailURL.GetComponent<UILogo>().URL = "mailto:" + MailList[IDCard];
            PhoneURL.GetComponent<UILogo>().URL = "tel:" + PhoneList[IDCard];

        }
        /// <summary>
        /// The Unity Update method.
        /// </summary>
        public void Update()
        {
            if (Image == null || Image.TrackingState != TrackingState.Tracking)
            {
                //Ar Core ne track plus l'image on cache l'ui
                for (int i = 0; i < LogoList.Length; i++)
                {
                    LogoList[i].gameObject.SetActive(false);
                }
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

                //SetActive true
                LogoList[i].gameObject.SetActive(true);
            }
        }
    }
}
