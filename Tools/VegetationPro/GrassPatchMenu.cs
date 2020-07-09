using UnityEngine;
using UnityEditor;


public class GrassPatchMenu
{
    [MenuItem("MaidenLand Tools/GrassPatch")]
    static void CreateLocation(MenuCommand menuCommand)
    {
        GameObject grassPatch = new GameObject("GrassPatch");
        grassPatch.AddComponent<GrassPatch>();

        // Ensure it gets reparented if this was a context click (otherwise does nothing)
        GameObjectUtility.SetParentAndAlign(grassPatch, menuCommand.context as GameObject);

        // Register the creation in the undo system
        Undo.RegisterCreatedObjectUndo(grassPatch, "CreateGrassPatch ");
        Selection.activeObject = grassPatch;
    }
}
