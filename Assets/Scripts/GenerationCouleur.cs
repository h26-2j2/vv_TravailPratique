using UnityEngine;
using TMPro;

public class GenerationCouleur : MonoBehaviour
{   
    public SpriteRenderer[] cartes;
    public SpriteRenderer carteViser;
    //UI
    public TMP_Text texteCartes;
    void Start()
    {
        // Pour chaque carte dans le tableau "cartes"
        foreach (SpriteRenderer carte in cartes)
        {
            carte.color = GenererCouleursCartes();
        }

        int nbrCartes = Random.Range(2,5); //2 a 4
        texteCartes.text = $"Choisissez {nbrCartes} cartes";

        carteViser.color = GenererCouleurCarteViser(cartes, nbrCartes);
    }

    Color GenererCouleursCartes()
    {
        int indiceCMJ = Random.Range(0,3); // C = 0, M = 1, J = 2

        switch (indiceCMJ)
        {
            case 0:
                return CMJVersRGB(1, 0, 0);
            case 1:
                return CMJVersRGB(0, 1, 0);
            case 2:
                return CMJVersRGB(0, 0, 1);
        }

        return GenererCouleursCartes();
    }

    Color GenererCouleurCarteViser(SpriteRenderer[] cartes, int nbrCartes)
    {
        SpriteRenderer[] selectionCartes = new SpriteRenderer[nbrCartes];
        int n = 0;
        int loops = 0;
        int maxLoops = 1000;

        while (n < nbrCartes && loops < maxLoops)
        {
            int selection = Random.Range(0, cartes.Length);
            bool estDejaSelectionne = false;

            for (int i = 0; i < n; i++)
            {
                if (cartes[selection] == selectionCartes[i])
                {
                    estDejaSelectionne = true;
                    break;
                }
            }

            if (!estDejaSelectionne)
            {
                selectionCartes[n] = cartes[selection];
                n++;
            }
            loops++;
        }

        Color couleurViser = new Color(0,0,0);

       foreach (SpriteRenderer carte in selectionCartes)
        {
            couleurViser += carte.color;
        }
        couleurViser /= nbrCartes;

        return couleurViser;
    }
    
    // conversion/transformation de CMJ a RVG
    Color CMJVersRGB(int C, int M, int J)
    {
        float R = 1f * (1f - C);
        float V = 1f * (1f - M);
        float G = 1f * (1f - J);

        return new Color(R, V, G);
    }
}
