using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILogo : MonoBehaviour {
    public string URL;
    public void onClick()
    {
        Application.OpenURL(URL);
    }
}
