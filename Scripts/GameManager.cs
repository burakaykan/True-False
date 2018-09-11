using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public Question[] questions;
    private static List<Question> unansweredQuestions;

    private Question currentQuestion;
    
    [SerializeField]
    private Text factText;

    [SerializeField]
    private Text trueAnsweredText;

    [SerializeField]
    private Text falseAnsweredText;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float timeBetweenQuestions = 1f;

    [SerializeField]
    private Text PuanText;

    public int puan;

    

    void Start()
    {
       
        if (unansweredQuestions==null || unansweredQuestions.Count==0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }
        //puankontrolu();
        if (puan<0)
        {
            ReklamGoster();
        }
        SetCurrentQuestion();
        AdManager.Instance.ShowBanner();


    }
    //void puankontrolu()
    //{
    //    if (puan<=-1)
    //    {
    //        ReklamGoster();
    //        puanreset();
    //    }
    //}
    public void ReklamGoster()
    {
            AdManager.Instance.ShowVideo();
        puanreset();
    }
    public void puanreset()
    {
        puan = 10;
    }

    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        factText.text = currentQuestion.fact;

        if (currentQuestion.isTrue)
        {
            trueAnsweredText.text = "BİLDİN";
            falseAnsweredText.text = "BİLEMEDİN";
        }
        else
        {
            trueAnsweredText.text = "BİLEMEDİN";
            falseAnsweredText.text = "BİLDİN";
        }

    }

    IEnumerator TransitionToNextQuestion()
    {
        OnEnable();
        unansweredQuestions.Remove(currentQuestion);
        yield return new WaitForSeconds(timeBetweenQuestions);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UserSelectTrue()
    {
        animator.SetTrigger("True");
        if (currentQuestion.isTrue)
        {
            FindObjectOfType<AudioManager>().Play("truesound");
            Debug.Log("doğru!");
            puan = puan + 1;
            Debug.Log("puan arttı");
            PuanText.text = puanbul();
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("falsesound");
            Debug.Log("yanlış!!!");
            puan = puan - 1;
            Debug.Log("puan azaldı");
            PuanText.text = puanbul();
        }
        StartCoroutine(TransitionToNextQuestion());


    }
    public void UserSelectFalse()
        {
        animator.SetTrigger("False");

        if (!currentQuestion.isTrue)
            {
            FindObjectOfType<AudioManager>().Play("truesound");
            Debug.Log("doğru!");
            puan = puan + 1;
            Debug.Log("puan arttı");
            PuanText.text = puanbul();
        }
            else
            {
            FindObjectOfType<AudioManager>().Play("falsesound");
            Debug.Log("yanlış!!!");
            puan = puan - 1;
            Debug.Log("puan azaldı");
            PuanText.text = puanbul();
        }

        StartCoroutine(TransitionToNextQuestion());
    }
 
    public string puanbul()
    {
        OnDisable();
        return puan.ToString();
    }
    void OnDisable()
    {
        PlayerPrefs.SetInt("score", puan);
    }
    void OnEnable()
    {
        puan = PlayerPrefs.GetInt("score");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
            puan = 10;
        }
    }
}
