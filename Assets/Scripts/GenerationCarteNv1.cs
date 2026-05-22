using UnityEngine;
using TMPro;

public class GenerationCarteNv1 : MonoBehaviour
{   
    public SpriteRenderer[] cartes;
    public SpriteRenderer carteViser;
    public int nbrCartes = 0;

    public GenerationCouleur generationCouleur;
    //UI
    public TMP_Text texteCartes;
    void Start()
    {
        foreach (SpriteRenderer carte in cartes) // Pour chaque carte dans le tableau "cartes"
        {
            carte.color = generationCouleur.GenererCouleur(); // la couleur de la carte est effectué par la fonction GenererCouleur
        }

        nbrCartes = Random.Range(2,5); //2 a 4
        texteCartes.text = $"Choisissez {nbrCartes} cartes";

        carteViser.color = GenererCouleurCarteViser(cartes, nbrCartes);
    }

    Color GenererCouleurCarteViser(SpriteRenderer[] cartes, int nbrCartes)
    {
        SpriteRenderer[] selectionCartes = new SpriteRenderer[nbrCartes]; //tableau de SpriteRenderer qui a une taille de nbrCartes
        int n = 0;
        int loops = 0;
        int maxLoops = 1000;

        while (n < nbrCartes && loops < maxLoops) // répète jusqu'à temps que la condition est fausse
        {
            int selection = Random.Range(0, cartes.Length); 
            bool estDejaSelectionne = false; 

            for (int i = 0; i < n; i++) //loop commence à 0; i doit être plus petit que n; ajoute 1 iteration
            {
                if (cartes[selection] == selectionCartes[i]) // SI cartes pige au hasard = [i]eme carte dans la loop
                {
                    estDejaSelectionne = true;
                    break;
                }
            }

            if (!estDejaSelectionne) //SI n'est pas deja selectionner
            {
                selectionCartes[n] = cartes[selection]; //[n] carte selectionner = carte piger au hasard
                n++;
            }
            loops++;
        }

        Color couleurViser = new Color(0,0,0);

       foreach (SpriteRenderer carte in selectionCartes) //for loop, pour chaque element de la liste
        {
            couleurViser += carte.color; //couleurViser EST ÉGAUX À couleurViser + carte.color
        }
        couleurViser /= nbrCartes; //couleurViser EST ÉGAUX À couleurViser / nbrCartes

        return couleurViser;
    }

}
