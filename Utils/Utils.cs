using System.IO;
using UnityEngine;

namespace CatUI
{
    public static class Utils
    {
        internal static Sprite LoadSpriteFromDisk(this string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return null;
            }

            byte[] data = File.ReadAllBytes(path);

            if (data == null || data.Length <= 0)
            {
                return null;
            }

            Texture2D tex = new Texture2D(512, 512);

            if (!ImageConversion.LoadImage(tex, data))
            {
                return null;
            }

            Sprite sprite = Sprite.Create(tex, new Rect(0f, 0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 200, 1000u, SpriteMeshType.FullRect, Vector4.zero, false);

            sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;

            return sprite;
        }
    }
}
