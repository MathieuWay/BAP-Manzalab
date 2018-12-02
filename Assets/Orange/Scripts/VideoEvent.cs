using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoEvent : MonoBehaviour {
    public Transform wifi;
    // Use this for initialization
    void Start () {
        Debug.Log("init");
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public void NewVideoOBject(VideoPlayer video)
    {
        video.loopPointReached += VideoEnded;
    }

    void VideoEnded(VideoPlayer vp)
    {
        this.gameObject.SetActive(false);
        wifi.gameObject.SetActive(true);
        Debug.Log("Switch WIFI");
    }
}
