using UnityEngine;

public class PhonePresenter : MonoBehaviour
{
    private PhoneModel _model = new PhoneModel();
    public PhoneView view;

    private void OnEnable()
    {
        // Ci iscriviamo all'evento quando lo script è attivo
        StandObjective.OnObjectiveCompleted += GestisciNuovoObiettivo;
    }

    private void OnDisable()
    {
        // È fondamentale disiscriversi per evitare memory leak
        StandObjective.OnObjectiveCompleted -= GestisciNuovoObiettivo;
    }

    private void GestisciNuovoObiettivo(string nomeObiettivo)
    {
        _model.AddChecklistItem(nomeObiettivo);
        view.UpdateDisplay(_model.Checklist);
        
        // Possiamo anche far vibrare il telefono o emettere un suono qui
        Debug.Log($"[Telefono] Checklist aggiornata con: {nomeObiettivo}");
    }
}