using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LOD_Group
{
    public List<GrassPlane> grassPlanes = new List<GrassPlane>();

    // the amount of grass planes to be removed
    public int meshReduction = 0;
}


/// <summary>
/// these vertices in a grassplane can be modified to better
/// fit the grassplane to terrain
/// </summary>
[System.Serializable]
public class GroundVert
{
    public Vector3 vertex = Vector3.zero;
    public List<Vector3> influencedVerts = new List<Vector3>();

    public bool showInfluencedVerts = true;
    public string showInfluencedButtonText = "Show";

    public GroundVert(Vector3 vert)
    {
        showInfluencedButtonText = "Show";
        vertex = vert;
    }

    public void ClearInfluenced()
    {
        influencedVerts.Clear();
    }
}


/// <summary>
/// an individual plane of grass
/// </summary>
[System.Serializable]
public class GrassPlane
{
    public Transform transform;
    public Vector3[] originalVerts = new Vector3[0];
    public List<GroundVert> groundVerts = new List<GroundVert>();

    public bool isSelected = false;
    bool isSaved = false;

    public GroundVert AddGroundVert(Vector3 vert)
    {
        GroundVert groundVert = new GroundVert(vert);
        groundVerts.Add(groundVert);
        return groundVert;
    }

    public void RemoveGroundVert(GroundVert groundVert)
    {
        if (groundVerts.Contains(groundVert))
            groundVerts.Remove(groundVert);
    }

    public void AdjustToGround()
    {
        LayerMask mask = LayerMask.NameToLayer("Ground");
        if (!isSaved) { SaveOriginal(); isSaved = true; }

        Vector3[] vertices = transform.GetComponent<MeshFilter>().sharedMesh.vertices;
        float distance = float.MinValue;

        RaycastHit hitInfo = new RaycastHit();
        foreach (var item in groundVerts)
        {
            Vector3 groundVert = item.vertex;

            Vector3 from = transform.TransformPoint(item.influencedVerts[0]);
            Vector3 to = (from - transform.TransformPoint(item.vertex)).normalized * 10f;

            // if vertex is above ground
            if (Physics.Raycast(from, -to, out hitInfo, mask))
            {
                for (int i = 0; i < vertices.Length; i++)
                {
                    if (vertices[i] == groundVert)
                    {
                        // first note the vector difference between current position of this
                        // vertex and hitPoint
                        if (hitInfo.transform.name != "Terrain") { Debug.Log("not terrain"); return; }
                        distance = Vector3.Distance(transform.TransformPoint(vertices[i]), hitInfo.point);
                        vertices[i] = transform.InverseTransformPoint(hitInfo.point);
                    }
                }

                //apply this difference to the verts that will be
                //effected by this groundVert
                foreach (var effectedVert in item.influencedVerts)
                {
                    for (int i = 0; i < vertices.Length; i++)
                    {
                        if(vertices[i] == effectedVert)
                        {
                            Vector3 p2 = transform.TransformPoint(vertices[i]) + (-((to.normalized) * distance));
                            vertices[i] = transform.InverseTransformPoint(p2);
                        }
                    }
                }
            }
        }

        Mesh mesh = transform.GetComponent<MeshFilter>().sharedMesh;
        Mesh newmesh = new Mesh();
        newmesh.vertices = mesh.vertices;
        newmesh.triangles = mesh.triangles;
        newmesh.uv = mesh.uv;
        newmesh.normals = mesh.normals;
        newmesh.tangents = mesh.tangents;

        Color[] colors = mesh.colors;
        for (int i = 0; i < mesh.colors.Length; ++i)
            colors[i].a = colors[i].grayscale;
        newmesh.colors = mesh.colors;

        transform.GetComponent<MeshFilter>().sharedMesh = newmesh;
        transform.GetComponent<MeshFilter>().sharedMesh.vertices = vertices;
        isSaved = false;
    }

    public void SaveOriginal()
    {
        originalVerts = transform.GetComponent<MeshFilter>().sharedMesh.vertices;
    }

    public void UndoChanges()
    {
        transform.GetComponent<MeshFilter>().sharedMesh.vertices = originalVerts;
    }

    /// <summary>
    /// returns a vector perpendicular to plane
    /// </summary>
    public Vector3 GetParallel()
    {
        List<Triangle> triangles = Geometry.UnityMeshToTriangles(transform.GetComponent<Mesh>(), transform);
        Triangle tri = triangles[0];

        var sideA = tri.b - tri.a;
        var sideB = tri.c - tri.a;

        var perp = Vector3.Cross(sideA, sideB);
        var perpLength = perp.magnitude;
        perp /= perpLength;
        var parallel = Vector3.Cross(perp, Vector3.right);

        return parallel;
    }

    public void AutoDetectVerts()
    {
        groundVerts.Clear();

        var originalEuler = transform.eulerAngles;
        transform.eulerAngles = new Vector3(originalEuler.x, 0, 0);

        Mesh mesh = transform.GetComponent<MeshFilter>().sharedMesh;

        // determine ground verts
        foreach (var item in mesh.vertices)
        {
            Vector3 vertex = transform.TransformPoint(item);
            if (vertex.y < 0.15f)
                AddGroundVert(item);
        }

        // determine effected vertices of each ground vert
        foreach (var item in groundVerts)
        {
            foreach (var vert in mesh.vertices)
            {
                // meaning its a ground vert
                if (transform.TransformPoint(vert).y < 0.15f) continue;

                // create a line segment
                List<Triangle> triangles = Geometry.UnityMeshToTriangles(mesh, transform);
                Triangle tri = triangles[0];

                var sideA = tri.b - tri.a;
                var sideB = tri.c - tri.a;

                var perp = Vector3.Cross(sideA, sideB);
                var perpLength = perp.magnitude;
                perp /= perpLength;
                var parallel = Vector3.Cross(perp, Vector3.right);

                Vector3 p1 = transform.TransformPoint(item.vertex);
                Vector3 p2 = p1 + (parallel * 5f);

                if (Utils.Utils.IsColinear(p1, p2, transform.TransformPoint(vert)))
                {
                    item.influencedVerts.Add(vert);
                }
            }
        }

        transform.eulerAngles = originalEuler;
    }
}


public class GrassPatch : MonoBehaviour
{
    public GameObject parent = null;
    public List<GrassPlane> grassPlanes = new List<GrassPlane>();

    public GrassPatchUtils utils = new GrassPatchUtils();

    // ************************** LOD Settings ************************** //
    public enum LOD_Level { LOD_0, LOD_1, LOD_2 }
    public LOD_Level lodLevel = LOD_Level.LOD_1;

    public LOD_Group lodGroup0 = new LOD_Group(); // original LOD
    public LOD_Group lodGroup1 = new LOD_Group();
    public LOD_Group lodGroup2 = new LOD_Group();

    // ************************** LOD Settings ************************** //

    public GrassPlane AddGrassPlane()
    {
        GrassPlane newPlane = new GrassPlane();
        grassPlanes.Add(newPlane);
        return newPlane;
    }

    public void RemoveGrassPlane(int index)
    {
        if (grassPlanes[index].transform != null) DestroyImmediate(grassPlanes[index].transform.gameObject);
        grassPlanes.RemoveAt(index);
    }


    public void AutoDetectVerts()
    {
        foreach(var item in grassPlanes)
        {
            item.AutoDetectVerts();
        }
    }

    //combine the grass patches together
    //into one mesh
    public void CombinePatches()
    {
        MeshFilter[] meshFilters = new MeshFilter[grassPlanes.Count];//  GetComponentsInChildren<MeshFilter>();

        int i = 0;
        foreach (var item in grassPlanes)
        {
            meshFilters[i] = item.transform.GetComponent<MeshFilter>();
            i++;
        }

        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        i = 0;
        while (i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
            i++;
        }

        if (!transform.GetComponent<MeshFilter>()) transform.gameObject.AddComponent<MeshFilter>();
        if (!transform.GetComponent<MeshRenderer>()) transform.gameObject.AddComponent<MeshRenderer>();
        transform.GetComponent<MeshFilter>().mesh = new Mesh();
        transform.GetComponent<MeshFilter>().sharedMesh.CombineMeshes(combine);
        transform.gameObject.SetActive(true);
    }

    public void Place()
    {
        foreach (var item in grassPlanes)
        {
            item.AdjustToGround();
        }
    }

    public void Create_LOD_Groups()
    {
        // indexes of grassPlanes in grassPatch to be removed in this LOD group

        Debug.Log("LOD Groups Generated");
    }

    List<GrassPlane> GetRandomInt(List<GrassPlane> list, List<int> excluded = null)
    {
        return null;
    }
}


[System.Serializable]
public class GrassPatchUtils
{
    // list of individual grass planes and ground cover plants to be combined into
    // one single grass clump
    public List<GameObject> grassObjects = new List<GameObject>();
    public List<Vector3> scatteredPoints = new List<Vector3>();

    // radius in which to place grass clumps
    public float scatterradius = 1.5f;

    // method to generate random locations within clumpScatterradius individual 
    public enum ScatterMethod { RandomInsideCircle }
    public ScatterMethod scatterMethod = ScatterMethod.RandomInsideCircle;

    public int scatterAmoumt = 6; // for RandomInsideCircle

    public GrassPatchUtils()
    {
    }

    public void Scatter(GrassPatch patch)
    {
        scatteredPoints.Clear();
        // RemoveDistribution(patch);

        for (int i = 0; i < scatterAmoumt; i++)
        {
            Vector3 pos = Random.insideUnitCircle * scatterradius;
            scatteredPoints.Add(new Vector3(pos.x, 0, pos.y));
        }
    }

    public void Distribute(GrassPatch patch)
    {
        Transform parent = GameObject.FindGameObjectWithTag("Foliage").transform;

        foreach (var point in scatteredPoints)
        {
            GameObject clump = Object.Instantiate(grassObjects[Random.Range(0, grassObjects.Count-1)]);

            clump.transform.position = patch.transform.TransformPoint(point);

            Randomize(clump);

            GrassPlane plane = patch.AddGrassPlane();
            plane.transform = clump.transform;

            clump.transform.parent = parent;
        }
    }

    void RemoveDistribution(GrassPatch patch)
    {
        for (int i = 0; i < patch.grassPlanes.Count; i++)
        {
            patch.RemoveGrassPlane(i);
        }
    }

    public void Combine() { }

    public void Randomize(GameObject obj)
    {
        obj.transform.eulerAngles = new Vector3(0f, Random.Range(-90f, 90f), 0f);

        var scaleOffset = UnityEngine.Random.Range(-0.1f, 0.1f);
        obj.transform.localScale += new Vector3(scaleOffset, scaleOffset, scaleOffset);
    }
}