using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    // Variables
    [HideInInspector] public bool clickAllowed = false; 
    int currentPage = 0;
    Animator animator;  
    public Page[] pages; public Image pagePanel; 
    public TextMeshProUGUI TMP; 
    public string nextScene, backgroundMusic;
        
    void Awake()
    {
        FindObjectOfType<AudioManager>().PlaySound(backgroundMusic);
        animator = GetComponent<Animator>();

        pagePanel.sprite = pages[currentPage].pageImage; 
        TMP.text = pages[currentPage].storyText;
    }

    public void AllowClick(){
        clickAllowed = true;
    }

    public void ChangePage(){
        if (currentPage != (pages.Length-1))
        {
            currentPage ++;
            pagePanel.sprite = pages[currentPage].pageImage; 
            TMP.text = pages[currentPage].storyText;
        } else {
            SceneManager.LoadScene(nextScene);
        }

    }   
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && clickAllowed)
        {
            clickAllowed = false;
            animator.SetTrigger("Click");
        }
    }
}
