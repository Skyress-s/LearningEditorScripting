using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ref https://learn.unity.com/tutorial/editor-scripting#5c7f8528edbc2a002053b5fa
public class NameBehaviour : MonoBehaviour {
    
    //first argument is name, second is THE NAME OF THE FUNC to be called
    //right click on the text field to se option
    [ContextMenuItem("ClearString", "ResetText")][SerializeField] private string text;

    
    //right click on the component to se option
    [ContextMenu("Reset text")]
    private void ResetText() {
        text = string.Empty;
    }
}
