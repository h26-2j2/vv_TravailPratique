using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public string sceneIntro = "EcranTitre";
    public string sceneJeu = "Niveau1";
    public void DemarrerJeu()
    {
        SceneManager.LoadScene(sceneJeu);
    }
}
