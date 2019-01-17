using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NextQuestion : MonoBehaviour {
    public Transform nextQuestion;
    public void NextQuestionTrigger()
    {
        transform.parent.gameObject.SetActive(false);
        nextQuestion.gameObject.SetActive(true);
        RotationEvent eventRot;
        if(eventRot = GetComponent<RotationEvent>())
        {
            eventRot.RotationTrigger();
        }
    }
}
