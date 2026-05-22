using UnityEngine;

public class GestionCercleVise : MonoBehaviour
{
        public SpriteRenderer cercleViser;
        public string sceneJeu = "Niveau2";

        public SpriteRenderer[] cercles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("ChoisirCercleViser", 0.1f);
    }

    public void ChoisirCercleViser()
    {
        int CercleSelectionner = Random.Range(0, cercles.Length);
        cercleViser.color = cercles[CercleSelectionner].color;

    }

    public bool VerifierCercle(Color SelectionCouleur)
    {
        if (cercleViser.color == SelectionCouleur)
        {
            return true;
        }
        return false;
    }
}
