using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshInverter : MonoBehaviour
{
    void Start()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh mesh = mf.mesh;
        InsideOut(ref mesh);
        AssetDatabase.CreateAsset(mesh, "Assets/InvertedMesh.asset");
        AssetDatabase.SaveAssets();
    }

    void InsideOut(ref Mesh mesh)
    {
        var triangles = mesh.triangles;
        for (int i = 0; i < triangles.Length; i += 3)
        {
            int tmp = triangles[i + 1];
            triangles[i + 1] = triangles[i + 2];
            triangles[i + 2] = tmp;
        }
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
    }
}
