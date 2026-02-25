using UnityEngine;
using UnityEngine.SceneManagement; // Necessario per caricare le scene

public class MainMenuUIController : MonoBehaviour
{
    [Header("Impostazioni Pannelli")]
    public GameObject pannelloMenuPrincipale;
    public GameObject pannelloImpostazioni;

    // 1. Metodo per il bottone INIZIA
    public void IniziaGioco()
    {
        // Carica la scena chiamata "TutorialScene"
        // Assicurati che sia aggiunta nelle Build Settings!
        SceneManager.LoadScene("TutorialScene");
    }

    // 1. Metodo per il bottone INIZIA
    public void IniziaGiocoReale()
    {
        // Carica la scena chiamata "WorldScene"
        // Assicurati che sia aggiunta nelle Build Settings!
        SceneManager.LoadScene("WorldScene");
    }

    // 2. Metodo per il bottone IMPOSTAZIONI
    public void ApriImpostazioni()
    {
        if (pannelloImpostazioni != null && pannelloMenuPrincipale != null)
        {
            pannelloImpostazioni.SetActive(true);      // Attiva le impostazioni
            pannelloMenuPrincipale.SetActive(false);   // Disattiva il menu principale
        }
    }

    public void ChiudiImpostazioni()
    {
        if (pannelloImpostazioni != null && pannelloMenuPrincipale != null)
        {
            pannelloImpostazioni.SetActive(false);     // Disattiva le impostazioni
            pannelloMenuPrincipale.SetActive(true);    // Attiva il menu principale
        }
    }

    // 3. Metodo per il bottone ESCI
    public void EsciDalGioco()
    {
        Debug.Log("Il gioco si sta chiudendo..."); // Utile per testare nell'Editor
        Application.Quit(); // Chiude l'applicazione (funziona solo nel build finale)
    }
}