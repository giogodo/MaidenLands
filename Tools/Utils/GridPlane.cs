using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Utils
{

    namespace Grid
    {
        [System.Serializable]
        public class Node
        {
            Vector3 worldPos = new Vector3();
            public Vector3 WorldPos { get { return worldPos; } }


            float gridDiam = -1;
            public float Diameter { get { return gridDiam; } }

            public Node(Vector3 _worldPos, float _gridDiam)
            {
                worldPos = _worldPos;
                gridDiam = _gridDiam;
            }
        }

        /// <summary>
        /// TerrainGridNode is subclassed from Node to keep original Node class 
        /// reusable.
        /// </summary>
        public class TerrainGridNodes : Node
        {
            public List<GridPlane> gridPlanes = new List<GridPlane>();

            float distance = -1f;
            public float DistanceFromPlayer {
                get { return Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, WorldPos); }
            }

            public TerrainGridNodes(Vector3 _worldPos, float _gridDiam) : base(_worldPos, _gridDiam)
            {
            }
        }

        [System.Serializable]
        public class GridPlane
        {
            Vector2 gridWorldSize;
            public Vector3 GridWorldSize { get { return new Vector3(gridWorldSize.x, 1, gridWorldSize.y); } }

            // number of grids that would fit in x and y directions
            int gridSizeX, gridSizeY;

            float nodeRadius;
            float nodeDiameter;
            public float NodeDiameter { get { return nodeDiameter; } }

            TerrainGridNodes[,] nodes;
            public TerrainGridNodes[,] TerrainGridNode { get { return nodes; } }

            Transform transform = null;

            public GridPlane CreateGrid(Vector2 _gridWorldSize, float _nodeDiameter, Vector3 position)
            {
                gridWorldSize = _gridWorldSize;
                nodeDiameter = _nodeDiameter;

                nodeRadius = nodeDiameter / 2;

                gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
                gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);

                nodes = new TerrainGridNodes[gridSizeX, gridSizeY];

                Vector3 worldBottomLeft = position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;

                for (int x = 0; x < gridSizeX; x++)
                {
                    for (int y = 0; y < gridSizeY; y++)
                    {
                        Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                        nodes[x, y] = new TerrainGridNodes(worldPoint, nodeDiameter);
                    }
                }

                return this;
            }

        }
    }
}