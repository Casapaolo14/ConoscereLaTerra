using System;
using System.Collections.Generic;

public class PhoneModel
{
    public List<string> Checklist = new List<string>();
    public string NoteTestuali = "";
    
    // Evento per notificare il Presenter che i dati sono cambiati
    public Action OnDataChanged;

    public void AddChecklistItem(string item)
    {
        Checklist.Add(item);
        OnDataChanged?.Invoke();
    }
}