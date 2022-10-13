using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    //public GameObject audioManager;
    //VARIABLES FOR POP UP SCREENS
    public GameObject levelPopUp;
    public GameObject optionsPopUp;
    public GameObject aboutPopUp;
    public GameObject levelList;

    public GameObject playButton;
    public GameObject settingsButton;
    public GameObject aboutButton;
    public GameObject quitButton;

    public GameObject fadeImage;

    //VARIABLES FOR STAR IMAGES DISPLAYED ON LEVEL BUTTONS ON LEVEL SCREEN
    public GameObject[] level1StarsImages;
    public GameObject[] level2StarsImages;

    public ParticleSystem buttonEffects;
    public Animator myAnimator;

    public GameManager gameManager;
    public AudioManager audioManager;
    public AudioSource myAudio;

    public int nextLevel;


    // Start is called before the first frame update
    void Start()
    {
        levelPopUp.SetActive(false);
        fadeImage.SetActive(true);
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        myAudio = audioManager.GetComponent<AudioSource>();

        myAnimator = GameObject.Find("FadeOut").GetComponent<Animator>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();



    }

    public void GameStart()
    {
        StartCoroutine(StartTimer());
    }

    public void LevelScreenActive(int level)
    {

        levelPopUp.SetActive(true);
        nextLevel = level;
    }

    public void LevelScreenClose()
    {
        audioManager.PlayMenu(0);
        levelPopUp.GetComponent<Animator>().SetBool("Disappear", true);
    }

    public void OpenOptions()
    {
        optionsPopUp.SetActive(true);
        optionsPopUp.GetComponent<Animator>().SetBool("Appear", true);
    }

    public void CloseOptions()
    {
        optionsPopUp.GetComponent<Animator>().SetBool("Appear", false);
        optionsPopUp.GetComponent<Animator>().SetBool("Disappear", true);
    }

    public void OpenAbout()
    {
        aboutPopUp.SetActive(true);
        aboutPopUp.GetComponent<Animator>().SetBool("Appear", true);
    }

    public void CloseAbout()
    {
        aboutPopUp.GetComponent<Animator>().SetBool("Appear", false);
        aboutPopUp.GetComponent<Animator>().SetBool("Disappear", true);
    }

    public void OpenLevel()
    {

        StartCoroutine(OpenLevelDelay());
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator StartTimer()
    {
        playButton.GetComponent<Animator>().SetTrigger("Pressed");
        buttonEffects.Play();
        audioManager.PlayMenu(1);
        yield return new WaitForSeconds(0.5f);
        settingsButton.SetActive(true);
        aboutButton.SetActive(true);
        levelList.SetActive(true);
        playButton.SetActive(false);

        for(int i=0; i < gameManager.level1Stars; i++)
        {
            level1StarsImages[i].SetActive(true);
        }
    }

    public IEnumerator OpenLevelDelay()
    {
        audioManager.PlayMenu(2);
        myAnimator.SetBool("FadeIn", false);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextLevel);
    }


}
