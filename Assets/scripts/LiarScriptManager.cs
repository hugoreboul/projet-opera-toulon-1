using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class LiarScriptManager : MonoBehaviour
{
    // Le Text UI affichant les phrases
    public TextMeshProUGUI textDisplay;
    // tableaux contenant les textes (déclaré dans l'inspecteur)
    public string[] sentences;
    // la phrase que l'on veut afficher
    private int index;
    // vitesse d'affichage du text (attente en seconde avant d'afficher la prochaine lettre)
    public float typingSpeed;

    private Coroutine currentCoroutine;

    private void Start()
    {
      // on lance la premiere phrase
        currentCoroutine = StartCoroutine(Type());
    }

    // affichage d'une phrase lettre par lettre
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return
                 new WaitForSeconds(typingSpeed);
        }
    }

    // lancer la couroutine pour la phrase N
    public void GoToSentenceX(int _index)
    {
        if(index <= sentences.Length -1)
        {
            index = _index;
            StopCoroutine(currentCoroutine);
            textDisplay.text = "";
            currentCoroutine = StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
        }
    }
    
    // Detection du clic sur un objet de type menteur
    void Update()
    {
        for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {

                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject objectHit = hit.transform.gameObject;
                    
                    // l'objet doit avoir le tag Liar 
                    if (objectHit.tag == "Liar")
                    {
                        int num;
                        string str;
                        str = objectHit.transform.name;
                        str = str.Substring(str.Length - 1, 1);
                        int.TryParse(str, out num);
                        // on récupère le dernier chiffre du nom de l'objet (Exemple Liar4 -> 4), on va afficher la phrase 4
                        GoToSentenceX(num);
                    }
                }
            }
        }
    }

    public void valideChoice()
    {        
        // celui qui ne ments pas
        if (index == 4)
        {
            StopCoroutine(currentCoroutine);
            textDisplay.text = "";
            textDisplay.text = "C'est gagné ! \nLe suspect Vert ne ment pas";
        }
        else if(index >0 && index < 6)
        {
            StopCoroutine(currentCoroutine);
            textDisplay.text = "";
            textDisplay.text = "Perdu ! \nLe suspect selectionné ment !";
        }
    }
    
}
