using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource source;
    //Introduction
    public List<AudioClip> introductionL;

    //Conclusion
    public List<AudioClip> conclusionL;

    //Correct Answer
    public List<AudioClip> correctAnswerL;


    //Incorrect Answer
    public List<AudioClip> incorrectAnswerL;

    public List<AudioClip> words;

    //Music
    public AudioClip fail_noise;
    public AudioClip success_noise;

    private void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }
    public void introduction()
    {
        source.clip = introductionL[0];
        source.Play();
    }

    public void conclusion(bool winState)
    {
        if (winState) //True means win
        {
            source.clip = success_noise;
        }

        else
        {
            source.clip = fail_noise;
        }

        source.Play();
        StartCoroutine(soundCoroutine(4.5f));
    }

    private void endSound()
    {
        int temp = Random.Range(0, 6);
        source.clip = conclusionL[temp];
        source.Play();
    }

    public void correctAnswer()
    {
        int temp = Random.Range(0, 6);
        source.clip = correctAnswerL[temp];
        source.Play();
    }

    public void incorrectAnswer()
    {
        int temp = Random.Range(0, 6);
        source.clip = incorrectAnswerL[temp];
        source.Play();
    }

    public void playWord(string word)
    {
        source.clip = Resources.Load<AudioClip>("words/" + word);
        source.Play();
    }

    IEnumerator soundCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        endSound();
    }

}
