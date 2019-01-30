using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changescene : MonoBehaviour {

    public void NextScene1()
    {
        SceneManager.LoadScene("Manzalab_card");
    }
    public void NextScene2()
    {
        SceneManager.LoadScene("Aug_Video");
    }
    public void NextScene3()
    {
        SceneManager.LoadScene("projet assistance");
    }
}
