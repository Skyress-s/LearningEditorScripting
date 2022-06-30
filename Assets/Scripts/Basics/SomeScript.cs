using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeScript : MonoBehaviour {
    public string someText;

    [HideInInspector] public int someValue = 5;
    
    public int experience = 570;
    public int expPerLevel = 100;
}
