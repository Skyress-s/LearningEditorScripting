using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Projectile))]
public class ProjectileEditor : Editor
{
    void OnSceneGUI() {
        var projectile = target as Projectile;
        projectile.damageRadius = Handles.RadiusHandle(
            projectile.transform.rotation, 
            projectile.transform.position, 
            projectile.damageRadius);
        
        
    }


    //We should also add a Gizmo so we can see the Projectile in the scene view when it has no renderable geometry.
    //Here we have used a DrawGizmo attribute to specify a method which is used to draw the gizmo for the Projectile class.
    //This can also be done by implementing OnDrawGizmos and OnDrawGizmosSelected in the Projectile class itself,
    //however it is better practice to keep editor functionality separated from game functionality when possible,
    //so we use the DrawGizmo attribute instead.
    [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
    static void DrawGizmosSelected(Projectile projectile, GizmoType gizmoType) {
        Gizmos.DrawSphere(projectile.transform.position, 0.125f);
    }
}
