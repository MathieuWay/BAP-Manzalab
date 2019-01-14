using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ButtonOne : MonoBehaviour {
    public Transform nextQuestion;
    public void NextQuestion()
    {
        transform.parent.gameObject.SetActive(false);
        nextQuestion.gameObject.SetActive(true);
    }
}
