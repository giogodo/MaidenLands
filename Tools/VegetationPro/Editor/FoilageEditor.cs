using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using VegetationPro;


[CustomEditor(typeof(FoliageSystem))]
public class FoilageEditor : Editor
{
    FoliageSystem foliage;

    void OnEnable()
    {
        foliage = target as FoliageSystem;
    }

    void OnValidate()
    {
        foliage = target as FoliageSystem;
    }

    public override void OnInspectorGUI()
    {
        DrawUI();
    }

    void OnSceneGUI()
    {
        DrawHandles();
    }

    void DrawUI()
    {
        EditorGUILayout.Space(5f);

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Grid Node Diameter");
        foliage.foliageSettings.gridNodeDivisons = EditorGUILayout.IntField(foliage.foliageSettings.gridNodeDivisons);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("SuidGrid_0 Node Diameter");
        foliage.foliageSettings.subGrid_0_Divisions = EditorGUILayout.IntField(foliage.foliageSettings.subGrid_0_Divisions);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Foliage Fade Distance");
        foliage.foliageSettings.foliageFadeDistance = EditorGUILayout.FloatField(foliage.foliageSettings.foliageFadeDistance);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space(5f);

        if (GUILayout.Button("Init")) { foliage.Init(); }

    }

    void DrawHandles()
    {
        // draw main grid and and its subdivisions
        Vector3 size = new Vector3(foliage.Terrain.terrainData.size.x, 1f, foliage.Terrain.terrainData.size.z);
        Handles.DrawWireCube(foliage.TerrainCentre, size);

        Utils.Grid.GridPlane grid = foliage.GetGrid();

        if (grid != null)
        {
            foreach (Utils.Grid.TerrainGridNodes n in grid.TerrainGridNode)
            {
                // Gizmos.color = (n.walkable) ? Color.white : Color.red;

                Vector3 handleSize;
                Handles.color = Color.blue;
                foreach (var item in n.gridPlanes)
                {
                    foreach (var node in item.TerrainGridNode)
                    {
                        handleSize = new Vector3(node.Diameter, 0.1f, node.Diameter);
                        Handles.DrawWireCube(node.WorldPos, handleSize);
                    }
                }

                if (n.DistanceFromPlayer > foliage.foliageSettings.foliageFadeDistance)
                {
                    Handles.color = Color.yellow;
                    Handles.DrawLine(n.WorldPos, GameObject.FindGameObjectWithTag("Player").transform.position);
                }

                Handles.color = Color.white;
                handleSize = new Vector3(grid.NodeDiameter, 0.1f, grid.NodeDiameter);
                Handles.DrawWireCube(n.WorldPos, handleSize);
            }

        }

    }
}
