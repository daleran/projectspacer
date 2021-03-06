﻿using UnityEngine;
using System.Collections;
using UnityEditor;

namespace DalLib.Unity
{
    public class SpriteProcessor : AssetPostprocessor
    {

        void OnPostprocessTexture(Texture2D texture)
        {
            string lowerCaseAssetPath = assetPath.ToLower();
            bool isInSpritesDirectory = lowerCaseAssetPath.IndexOf("/sprites/") != -1;

            if (isInSpritesDirectory)
            {
                TextureImporter textureImporter = (TextureImporter)assetImporter;
                textureImporter.textureType = TextureImporterType.Sprite;
                textureImporter.spritePixelsPerUnit = 32f;
                textureImporter.filterMode = FilterMode.Point;
                textureImporter.textureFormat = TextureImporterFormat.AutomaticTruecolor;
            }
        }
    }
}

