﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class streamVideo : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
 
    private void Start()
    {
        StartCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();
        while(!videoPlayer.isPrepared)
        {
            yield return new WaitForSeconds(1);
            break;
        }
        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
    }
}
