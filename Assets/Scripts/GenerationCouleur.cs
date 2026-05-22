using UnityEngine;
using TMPro;

public class GenerationCouleur : MonoBehaviour
{  
    public Color GenererCouleur() 
    {
        int indiceCMJ = Random.Range(0,3); // C = 0, M = 1, J = 2

        switch (indiceCMJ) //meme principe que if else
        {
            case 0:
                return CMJVersRGB(1, 0, 0); //C
            case 1:
                return CMJVersRGB(0, 1, 0); //M
            case 2:
                return CMJVersRGB(0, 0, 1); //J
        }

        return GenererCouleur();
    }

    // conversion/transformation de CMJ a RVG
    public Color CMJVersRGB(int C, int M, int J)
    {
        float R = 1f * (1f - C);
        float V = 1f * (1f - M);
        float G = 1f * (1f - J);

        return new Color(R, V, G);
    }
}
