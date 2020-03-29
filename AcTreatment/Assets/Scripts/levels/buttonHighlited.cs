using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class buttonHighlited : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject videoPlayer;
    public RawImage rawImage;
    public Texture imageTexture;

    public void OnPointerEnter(PointerEventData eventData)
    {
        videoPlayer.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        videoPlayer.SetActive(false);
        rawImage.texture = imageTexture;
    }
}
