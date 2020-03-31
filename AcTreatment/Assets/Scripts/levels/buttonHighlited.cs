using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class buttonHighlited : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject animator;
    public RawImage rawImage;

    private float pauseTime;

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetActive(true);
        rawImage.gameObject.SetActive(false);
        AnimatorStateInfo stateInfo = animator.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        animator.GetComponent<Animator>().Play(stateInfo.nameHash, 0, pauseTime);
  
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pauseTime = animator.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime;
    
        rawImage.gameObject.SetActive(true);
        animator.SetActive(false);
    }

}
