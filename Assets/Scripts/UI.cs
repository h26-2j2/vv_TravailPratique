using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public string sceneIntro = "EcranTitre";
    public string sceneJeu = "Niveau1";
    public string sceneJeu2 = "Niveau2";
    public void DemarrerJeu()
    {
        SceneManager.LoadScene(sceneJeu);
    }

    public void ProchainJeu()
    {
        SceneManager.LoadScene(sceneJeu2);
    }
}
