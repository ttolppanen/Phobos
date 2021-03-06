using System.IO;
using UnityEngine;

namespace UnityEditor.U2D.PSD
{
#pragma warning disable CS0618 // Type or member is obsolete
    [UnityEditor.AssetImporters.ScriptedImporter(1, "psd", AutoSelect = false)]
#pragma warning restore CS0618 // Type or member is obsolete
    internal class PSDImporterOverride : PSDImporter
    {

        [MenuItem("Assets/2D Importer", false, 30)]
        [MenuItem("Assets/2D Importer/Change PSD File Importer", false, 30)]
        static void ChangeImporter()
        {
            foreach (var obj in Selection.objects)
            {
                var path = AssetDatabase.GetAssetPath(obj);
                var ext = System.IO.Path.GetExtension(path);
                if (ext == ".psd")
                {
                    var importer = AssetImporter.GetAtPath(path);
                    if (importer is PSDImporterOverride)
                    {
                        Debug.Log(string.Format("{0} is now imported with TextureImporter", path));
                        AssetDatabase.ClearImporterOverride(path);
                    }
                    else
                    {
                        Debug.Log(string.Format("{0} is now imported with PSDImporter", path));
                        AssetDatabase.SetImporterOverride<PSDImporterOverride>(path);
                    }
                }
            }
        }
    }
}
