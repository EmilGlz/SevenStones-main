using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class Wardrobe : MonoBehaviour
{
    Dictionary<string, Transform> modelBones;
    public void Wear(GameObject sourcePart, GameObject targetModel)
    {
        modelBones = new Dictionary<string, Transform>();
        AddAvatarBones(targetModel.transform);

        var skinnedMeshRenderers = sourcePart.GetComponentsInChildren<SkinnedMeshRenderer>();
        var targetClothing = AddChild(sourcePart, targetModel.transform);

        AddParts(skinnedMeshRenderers, targetClothing);
    }

    private void AddParts(SkinnedMeshRenderer[] skinnedMeshRenderers, GameObject targetClothing)
    {
        foreach (var sourceRenderer in skinnedMeshRenderers)
        {
            var targetRenderer = AddSkinnedMeshRenderer(sourceRenderer, targetClothing);
            targetRenderer.bones = GetTransform(sourceRenderer.bones, modelBones);
        }
    }

    private void AddAvatarBones(Transform transform)
    {
        if (modelBones.ContainsKey(transform.name))
        {
            modelBones.Remove(transform.name);
            modelBones.Add(transform.name, transform);
        }
        else
        {
            modelBones.Add(transform.name, transform);
        }
        foreach (Transform child in transform)
        {

            AddAvatarBones(child);
        }
    }

    private GameObject AddChild(GameObject source, Transform parent)
    {
        source.transform.parent = parent;

        foreach (Transform child in source.transform)
        {
            Object.Destroy(child.gameObject);
        }

        return source;
    }

    private SkinnedMeshRenderer AddSkinnedMeshRenderer(SkinnedMeshRenderer source, GameObject parent)
    {
        GameObject meshObject = new GameObject(source.name);
        meshObject.transform.parent = parent.transform;

        var target = meshObject.AddComponent<SkinnedMeshRenderer>();
        target.sharedMesh = source.sharedMesh;
        target.materials = source.sharedMaterials;
        return target;
    }

    private Transform[] GetTransform(Transform[] sourcesBones, Dictionary<string, Transform> boneCatalog)
    {
        var targets = new Transform[sourcesBones.Length];
        for (var index = 0; index < sourcesBones.Length; index++)
        {
            targets[index] = boneCatalog[sourcesBones[index].name];
        }
        return targets;
    }
}