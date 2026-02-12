using UnityEngine;

// Dato che implementerai Meta XR Interaction SDK in seguito, ecco come muoverti ora:
// Usa il "Mock Input": Invece di script di teletrasporto VR, usa temporaneamente un semplice script di movimento FPS (WASD + Mouse) per girare nelle tue scene 3D su Unity.
// Pulsanti UI Standard: Per il "Telefono Virtuale", usa i classici Button di Unity. Quando avrai il visore, basterà aggiungere il componente Pointable Canvas di Meta per renderli cliccabili con le mani.


// Interfaccia per ogni stato
public interface IState
{
    void Enter();
    void Update();
    void Exit();
}

// Gestore della State Machine
public class StateMachineController : MonoBehaviour
{
    private IState _currentState;

    private void Start()
    {
        // Inizializziamo con lo stato Tutorial per il test
        ChangeState(new TutorialState());
    }

    private void Update()
    {
        _currentState?.Update();
    }

    public void ChangeState(IState newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter();
    }
}

// Esempio di uno Stato specifico
public class TutorialState : IState
{
    public void Enter() { Debug.Log("Entrato nel Tutorial: Benvenuto sulla Terra!"); }
    public void Update() { /* Logica specifica del tutorial */ }
    public void Exit() { Debug.Log("Uscita dal Tutorial."); }
}