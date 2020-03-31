using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class buttonHighlited : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject videoPlayer;
    public RawImage rawImage;
    public Texture imageTexture;

    public void OnPointerEnter(PointerEventData eventData)
    {
        VideoPlayer videoPlayerObj = videoPlayer.GetComponent<VideoPlayer>();
     
        videoPlayerObj.Prepare();
        while (!videoPlayerObj.isPrepared)
        {
            StartCoroutine(PrepareVideo());
            break;
        }
        rawImage.texture = videoPlayerObj.texture;
        videoPlayerObj.Play();

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        videoPlayer.GetComponent<VideoPlayer>().Pause();
        rawImage.texture = imageTexture;
    }

    IEnumerator PrepareVideo()
    {
        yield return new WaitForSeconds(1); 
    }
}
