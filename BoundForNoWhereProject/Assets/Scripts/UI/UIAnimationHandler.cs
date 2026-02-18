using UnityEngine;
using UnityEngine.EventSystems;

public class UIAnimationHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator anim;
    private AudioSource audioSource;
    [SerializeField] private AudioClip UIHover;

    void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.SetBool("isHovered", true);
        audioSource.PlayOneShot(UIHover, 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        anim.SetBool("isHovered", false);
        audioSource.PlayOneShot(UIHover, 1);
    }
}
