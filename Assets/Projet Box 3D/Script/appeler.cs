using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appeler : MonoBehaviour {
    public void onClick()
    {
        Application.OpenURL("tel:" + 3900);
    }
}
