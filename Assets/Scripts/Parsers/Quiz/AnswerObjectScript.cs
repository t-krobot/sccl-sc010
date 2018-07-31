using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/***** EXAMPLE ANSWER OBJECT CLASS */
/*
 * Create a new answer object following this template and attach it to the object representing you answer.
 * Edit the UpdateSelf function to reflect the necessary components (sprites, audio, etc)
 */


public class AnswerObjectScript : MonoBehaviour 
{
    public CanvasGroup cg;
    public AudioSource source;
    public UnifiedQuizController quizController;
    public QuizModel.AnswerModel answer {get; set;}

    public void StartSubmission() 
    {
        StartCoroutine(PlaySound());
        Debug.Log(answer.audio);
    }

    public void UpdateSelf() {
        // Update the necessary components of the answer 
        GetComponentInChildren<Text>().text = answer.text;
    }

    private void SendToController()
    {
        cg.interactable = true;
        quizController.ReceiveAnswer(answer.isCorrect);
    }


    IEnumerator PlaySound()
    {
        cg.interactable = false;
        source.clip = answer.audio;
        source.Play();
        while(source.isPlaying)
        {
            yield return null;
        }
        SendToController();
    }
}