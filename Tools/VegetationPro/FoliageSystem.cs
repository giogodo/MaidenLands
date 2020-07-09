using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace VegetationPro
{
    [System.Serializable]
    public class FoliageSettings
    {
        public int gridNodeDivisons = 2;
        public int subGrid_0_Divisions = 2;

        public float foliageFadeDistance = 300f;
    }


    [System.Serializable]
    public class FoliageSystem : MonoBehaviour
    {
        public FoliageSettings foliageSettings = new FoliageSettings();

        // grids that will cover entire terrain
        Utils.Grid.GridPlane grid;

        public Utils.Grid.GridPlane GetGrid()
        {
            return grid;
        }

        // **************************** TERRAIN *************************** //
        Terrain terrain = null;
        Vector3 terrainCentre = new Vector3();
        
        public Terrain Terrain { get { return terrain; } }

        public Vector3 TerrainCentre { get { return terrainCentre; } }
        // **************************** TERRAIN *************************** //

        void OnEnable() { Init(); }

        void OnValidate() { Init(); }

        void Start()
        {
        }

        public void Init()
        {
            // get the terrain
            if (!terrain) terrain = Terrain.activeTerrain;
            if (terrain == null) { Debug.LogError("No terrain selected"); return; }

            // get terrain centre
            Vector3 size = terrain.terrainData.size;
            terrainCentre = new Vector3(size.x / 2, 0f, size.z / 2);

            grid = new Utils.Grid.GridPlane();
            Vector2 gridSize = new Vector2(terrain.terrainData.size.x, terrain.terrainData.size.z);
            grid.CreateGrid(gridSize, 1000 / foliageSettings.gridNodeDivisons, terrainCentre);

            Utils.Grid.TerrainGridNodes node;
            for (int x = 0; x < grid.TerrainGridNode.Length/foliageSettings.gridNodeDivisons; x++)
            {
                for (int y = 0; y < grid.TerrainGridNode.Length/ foliageSettings.gridNodeDivisons; y++)
                {
                    node = grid.TerrainGridNode[x, y];

                    // add a subdivision to this node
                    Vector2 subGridSize = new Vector2(node.Diameter, node.Diameter);
                    Utils.Grid.GridPlane subGrid = new Utils.Grid.GridPlane();
                    subGrid.CreateGrid(subGridSize, node.Diameter/foliageSettings.subGrid_0_Divisions, node.WorldPos);
                    node.gridPlanes.Add(subGrid);
                }
            }
        }

        void Update()
        {
            foreach (var item in grid.TerrainGridNode)
            {


                //foreach (var node in item.gridPlanes)
                //{
                //    foreach (var subNode in node.TerrainGridNode)
                //    {

                //    }
                //}
            }
        }

        public static void PlaceGroundCover()
        {
        }

        public static void PlaceBush()
        {
        }

        public static void PlaceTree()
        {
        }
    }
}
