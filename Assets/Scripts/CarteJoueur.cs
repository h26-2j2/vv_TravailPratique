using UnityEngine;
using UnityEngine.EventSystems;

public class CarteJoueur : MonoBehaviour
{
    public SpriteRenderer carteJoueur;
    Color[] couleursMix = new Color[4];
    int maxIndex = 0;

    public void AjouterCouleur(BaseEventData eventData)
    {
        PointerEventData pointerData = eventData as PointerEventData;
        if (pointerData != null || maxIndex < 4)
        {
            GameObject objet = pointerData.pointerPress;
            print(objet);
            SpriteRenderer sprite = objet.GetComponent<SpriteRenderer>();
            couleursMix[maxIndex] = sprite.color;
            maxIndex++;
        }
    }

    public void DefaireCouleur()
    {
        if (maxIndex != 0)
        {
            maxIndex--;
        }
    }

    void MiseAJourCarteJoueur()
    {
        Color resultat = new Color(0, 0, 0);

        for (int i = 0; i <= maxIndex; i++)
        {
            resultat += couleursMix[i];
        }
        resultat /= maxIndex + 1;
        
    }
}
