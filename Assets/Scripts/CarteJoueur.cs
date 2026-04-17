using UnityEngine;
using UnityEngine.EventSystems;

public class CarteJoueur : MonoBehaviour
{
    public SpriteRenderer carteJoueur;
    public SpriteRenderer carteVise;
    public GenerationCouleur script;
    GameObject[] objetsCouleursMix = new GameObject[4]; // Nouveau tableau de GameObject de 4 espaces
    int nbrCouleurs = 0;

    public void AjouterCouleur(BaseEventData eventData)
    {
        PointerEventData pointerData = eventData as PointerEventData;
        if (pointerData != null && nbrCouleurs < 4)
        {
            GameObject objet = pointerData.pointerPress;
            objetsCouleursMix[nbrCouleurs] = objet;
            nbrCouleurs++;
            objet.SetActive(false);
            MiseAJourCarteJoueur();
        }
    }

    public void DefaireCouleur()
    {
        if (nbrCouleurs != 0)
        {
            nbrCouleurs--;
            objetsCouleursMix[nbrCouleurs].SetActive(true);
            MiseAJourCarteJoueur();
        }
    }

    public void VerifierCarteJoueur()
    {
        if (carteVise.color == carteJoueur.color && script.nbrCartes == nbrCouleurs)
        {
            print("oui");
        }
        else
        {
            print("non");
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

        for (int i = 0; i < nbrCouleurs; i++)
        {
            SpriteRenderer sprite = objetsCouleursMix[i].GetComponent<SpriteRenderer>();
            resultat += sprite.color;
        }
        resultat /= nbrCouleurs;

        carteJoueur.color = resultat;
        
    }
}
