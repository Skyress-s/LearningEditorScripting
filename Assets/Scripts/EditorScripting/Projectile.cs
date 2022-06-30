using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {
    //hiding rigidbody
    //the "new" -> We can also remove editor warnings by using the ‘new’ keyword on the field declaration
    [HideInInspector] new public Rigidbody rb;

    public float damageRadius = 1f;

    //Reset gets called when you first add the component to a gameObject -> rb gets assiged instantly!
    //this can also be called manually
    private void Reset() {
        rb = GetComponent<Rigidbody>();
    }
}
