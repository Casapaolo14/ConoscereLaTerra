using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

// Quando avrai il Meta Quest 2, non dovrai toccare il codice sopra. Dovrai solo:
// OVR Raycaster: Sostituire il Graphic Raycaster sul Canvas con OVR Raycaster (fornito dall'SDK di Meta).
// Pointable Canvas: Aggiungere il componente Pointable Canvas per permettere alle mani virtuali di inviare l'input "Click" come se fosse un mouse.
// Parenting: Invece di lasciarlo fisso nello spazio, trascina il Canvas sotto il LeftHandAnchor o RightHandAnchor del tuo Player Rig per farlo apparire "attaccato" alla mano.

public class PhoneView : MonoBehaviour
{
    public TextMeshProUGUI checklistText;
    public Button closeButton;

    public void UpdateDisplay(List<string> items)
    {
        checklistText.text = "OBIETTIVI:\n";
        foreach (var item in items)
        {
            checklistText.text += $"- {item}\n";
        }
    }
}
