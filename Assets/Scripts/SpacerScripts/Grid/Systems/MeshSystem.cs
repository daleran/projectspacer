﻿using UnityEngine;
using System.Collections.Generic;
using DalLib.Unity;
using DalLib.Math;

namespace ProjectSpacer
{

    public class MeshSystem : MonoBehaviour
    {

        public GameObject parent;
        Grid grid;

        public MeshFilter meshFilter;
        public MeshRenderer meshRenderer;


        public MeshData meshData;


        public void InitializeSystem()
        {
            parent = gameObject;
            grid = parent.GetRequiredComponent<Grid>();
            meshFilter = parent.GetOrAddComponent<MeshFilter>();
            meshRenderer = parent.GetOrAddComponent<MeshRenderer>();

            meshData = new MeshData();

        }

        public void BuildMesh(Vector2 center)
        {
            meshData.Clear();

            foreach (KeyValuePair<Vector2Int, Tile> kvp in grid.TileData)
            {
                //Debug.Log("Building Tile: " + kvp.Value.TileInfo.name + " at " + kvp.Key.ToString());
                Vector3 offset = new Vector3(kvp.Key.x - center.x + GV.halfTileSize, kvp.Key.y - center.y + GV.halfTileSize, 0f);
                meshData += kvp.Value.GetMeshData(kvp.Key);
            }

            meshFilter.mesh.Clear();
            meshFilter.mesh.vertices = meshData.vertices.ToArray();
            meshFilter.mesh.triangles = meshData.triangles.ToArray();
            meshFilter.mesh.uv = meshData.uv.ToArray();
            meshFilter.mesh.colors32 = meshData.colors.ToArray();
            meshRenderer.sharedMaterial = GV.atlas;
            meshFilter.mesh.RecalculateNormals();
            meshFilter.mesh.RecalculateBounds();
            meshFilter.mesh.Optimize();
        }





    }
}
