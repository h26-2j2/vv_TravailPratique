using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CarteJoueur : MonoBehaviour
{
    public SpriteRenderer carteJoueur;
    public SpriteRenderer carteVise;
    public GenerationCarteNv1 script;
    public string sceneJeu = "Niveau1";
    GameObject[] objetsCouleursMix = new GameObject[4]; // tableau de GameObject de 4 espaces
    int nbrCouleurs = 0;

    public void AjouterCouleur(BaseEventData eventData)
    {
        PointerEventData pointerData = eventData as PointerEventData;
        if (pointerData != null && nbrCouleurs < 4) // SI pointerData n'est pas null ET nbrCouleurs est plus petit que 4
        {
            GameObject objet = pointerData.pointerPress; // 
            objetsCouleursMix[nbrCouleurs] = objet; //
            nbrCouleurs++; //
            objet.SetActive(false); // 
            MiseAJourCarteJoueur(); //effectuer la fonction MiseAJourCarteJoueur
        }
    }

    public void DefaireCouleur()
    {
        if (nbrCouleurs != 0)
        {
            nbrCouleurs--;
            objetsCouleursMix[nbrCouleurs].SetActive(true); //
            MiseAJourCarteJoueur();
        }
    }

    public void VerifierCarteJoueur()
    {
        if (carteVise.color == carteJoueur.color && script.nbrCartes == nbrCouleurs) //
        {
            SceneManager.LoadScene(sceneJeu);
        }
        else
        {
            SceneManager.LoadScene(sceneJeu);
        }
    }

    void MiseAJourCarteJoueur()
    {
        Color resultat = new Color(0, 0, 0);

        if (nbrCouleurs == 0)
        {
            carteJoueur.color = new Color(255, 255, 255);
            return;
        }

        for (int i = 0; i < nbrCouleurs; i++) //
        {
            SpriteRenderer sprite = objetsCouleursMix[i].GetComponent<SpriteRenderer>();
            resultat += sprite.color; //resultat EST ÉGAUX À resultat + sprite­.color
        }
        resultat /= nbrCouleurs; //resultat EST ÉGAUX À resultat / nbrCouleurs

        carteJoueur.color = resultat;
        
    }
}
