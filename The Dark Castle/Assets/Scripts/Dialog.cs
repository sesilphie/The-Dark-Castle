using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
   public TextMeshProUGUI textDisplay;
   public string[] sentences;
   private int i;
   public float typeSpeed;
   public GameObject continueBtn;
   public Animator textAnim;

   void Start()
   {
       StartCoroutine(Type());
   }

    void Update()
    {
        if(textDisplay.text==sentences[i])
        {
            continueBtn.SetActive(true);
        }
    }
   IEnumerator Type()
   {
       foreach(char letter in sentences[i].ToCharArray())
       {
           textDisplay.text+=letter;
           yield return new WaitForSeconds(typeSpeed);

       }
       
   }
   public void Continue()
   {
       textAnim.SetTrigger("Change");
       continueBtn.SetActive(false);
       if(i<sentences.Length-1)
       {
           i++;
           textDisplay.text="";
           StartCoroutine(Type());
       }
       else
       {
           continueBtn.SetActive(false);
           textDisplay.text="";
       }
   }
}
