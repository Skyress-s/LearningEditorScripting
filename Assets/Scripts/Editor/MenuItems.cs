using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuItems : MonoBehaviour
{
    /// <summary>
    /// These are the supported keys (can also be combined together):

//     % – CTRL on Windows / CMD on OSX
//     # – Shift
//     & – Alt
//     LEFT/RIGHT/UP/DOWN – Arrow keys
//     F1…F2 – F keys
//     HOME, END, PGUP, PGDN
//
//     Character keys not part of a key-sequence are added by adding an underscore prefix to them (e.g: _g for shortcut key “G”).
    /// </summary>
    
    
    //simple tools at the top of editor button
    [MenuItem("Tools/Clear PlayerPrefs, %_g")]
    private static void DeletePlayerPrefs() {
        Debug.Log("Cleared player prefs");
    }
    

    // Add a menu item with multiple levels of nesting
    [MenuItem("Tools/SubMenu/Option")]
    private static void NewNestedOption()
    {
        Debug.Log("You clicked a player option");
    }
    
    // rightlicking on assets
    [MenuItem("Assets/Load Additive Scene")]
    private static void LoadAdditiveScene()
    {
        var selected = Selection.activeObject;
        EditorApplication.OpenSceneAdditive(AssetDatabase.GetAssetPath(selected));
    }
    
    // Adding a new menu item under Assets/Create

    [MenuItem("Assets/Create/Add Configuration")]
    private static void AddConfig()
    {
        // Create and add a new ScriptableObject for storing configuration
    }

// Add a new menu item that is accessed by right-clicking inside the RigidBody component

    [MenuItem("CONTEXT/Rigidbody/New Option")]
    private static void NewOpenForRigidBody()
    {
    }
    
    // actions for specific asset types
    //-------------------------------------
    
    //this function has the logic for a specific action on a Asset
    [MenuItem("Assets/ProcessTexture")]
    private static void DoSomethingWithTexture()
    {
        //the actual logic
    }
    // Note that we pass the same path, and also pass "true" to the second argument.
    //this line disables / enables the option depending of if i return true or false, try rightling on a image asset and non-image asset
    [MenuItem("Assets/ProcessTexture", true)]
    private static bool NewMenuOptionValidation()
    {
        // This returns true when the selected object is a Texture2D (the menu item will be disabled otherwise).
        return Selection.activeObject.GetType() == typeof(Texture2D);
    }
    
    
    
    //Controlling order of priority
    //-------------------------------------
    [MenuItem("NewMenu/Option1", false, 1)]
    private static void NewMenuOption()
    {
    }

    [MenuItem("NewMenu/Option2", false, 2)]
    private static void NewMenuOption2()
    {
    }

    [MenuItem("NewMenu/Option3", false, 3)]
    private static void NewMenuOption3()
    {
    }

    [MenuItem("NewMenu/Option4", false, 51)]
    private static void NewMenuOption4()
    {
    }

    [MenuItem("NewMenu/Option5", false, 52)]
    private static void NewMenuOption5()
    {
    }
    
    //sometimes with CONTEXT to an inspector we want to modify the rigidbody, this can be done as follows
    // ------------------------------------------------------------------------------------------
    [MenuItem("CONTEXT/Rigidbody/New Option")]
    private static void NewMenuOption(MenuCommand menuCommand)
    {
        // The RigidBody component can be extracted from the menu command using the context field.
        var rigid = menuCommand.context as Rigidbody;
        rigid.isKinematic = !rigid.isKinematic; // toggles isKinematic
    }
}
