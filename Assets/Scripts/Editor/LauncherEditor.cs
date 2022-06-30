using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEditor.Graphs;
using UnityEngine;

[CustomEditor(typeof(Launcher))]
public class LauncherEditor : Editor
{

    [DrawGizmo(GizmoType.Pickable | GizmoType.Selected)]
    static void DrawGizmosSelected(Launcher launcher, GizmoType gizmoType)
    {
        var offsetPosition = launcher.transform.TransformPoint(launcher.offset);
        Handles.DrawDottedLine(launcher.transform.position, offsetPosition, 3);
        Handles.Label(offsetPosition, "Offset");
        if (launcher.projectile != null) {
            var positions = new List<Vector3>();
            var velocity = launcher.transform.forward * launcher.velocity / launcher.projectile.mass;
            var position = offsetPosition;
            var physicsStep = 0.05f;
            for (float i = 0f; i < 1f; i += physicsStep) {
                positions.Add(position);
                position += velocity * physicsStep;
                velocity += Physics.gravity * physicsStep;
            }

            using (new Handles.DrawingScope(Color.yellow)) {
                Handles.DrawAAPolyLine(positions.ToArray());
                Gizmos.DrawWireSphere(positions[positions.Count - 1], 0.125f);
                Handles.Label(positions[positions.Count - 1], "Estimated Position");
            }
        }
    }
    
    //adds handle for where projectile will be spawned, and adds ingame button next to handle which we can press fire on
    void OnSceneGUI() {
        var launcher = target as Launcher; // cool casting, same as (Launcher)target
        var transform = launcher.transform;
        
        using (var cc = new EditorGUI.ChangeCheckScope())
        {
            var newOffset = transform.InverseTransformPoint(

                Handles.PositionHandle(
                    transform.TransformPoint(launcher.offset),
                    transform.rotation));

            if(cc.changed)
            {
                Undo.RecordObject(launcher, "Offset Change");
                launcher.offset = newOffset;
            }
        }

        //Handles.Position handle adds a Position handle in the editor, click on a component with the launcher and you will see!
        launcher.offset =
            transform.InverseTransformPoint(
                Handles.PositionHandle(transform.TransformPoint(launcher.offset),
                transform.rotation));
        
        //draw the ingame button, it should only be pressable in playmode
        Handles.BeginGUI();
        var rectMin = Camera.current.WorldToScreenPoint(
            launcher.transform.TransformPoint(launcher.offset));

        // i dont fully understand these lines
        var rect = new Rect();
        rect.xMin = rectMin.x;
        rect.yMin = SceneView.currentDrawingSceneView.position.height - 
                    rectMin.y;
        rect.width = 64;
        rect.height = 18;
        
        GUILayout.BeginArea(rect);
        
        /*public class SomeDisposableType : IDisposable
{
   ...implmentation details...
}

These are equivalent:

SomeDisposableType t = new SomeDisposableType();
try {
    OperateOnType(t);
}
finally {
    if (t != null) {
        ((IDisposable)t).Dispose();
    }
}

using (SomeDisposableType u = new SomeDisposableType()) {
    OperateOnType(u);
}
*/
        using (new EditorGUI.DisabledGroupScope(!Application.isPlaying)) {
            if (GUILayout.Button("Fire!")) {
                launcher.Fire();
            }
        }
        GUILayout.EndArea();
        Handles.EndGUI();
        
    }

    public override void OnInspectorGUI() {
        DrawDefaultInspector();        
        if (GUILayout.Button("FIRE!")) {
            var launcher = target as Launcher;
            launcher.Fire();
        }
    }
}
