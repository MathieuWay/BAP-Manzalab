using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRedirection : MonoBehaviour {
    public string url;
    public void redirection()
    {
        Application.OpenURL(url);
    }
}
