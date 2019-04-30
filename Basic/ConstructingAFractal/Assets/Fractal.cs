using UnityEngine;
using System.Collections;

public class Fractal : MonoBehaviour
{

    public Mesh[] meshes;

    public Material material;

    public int maxDepth;

    public float childScale;

    public float spawnProbability;

    public float maxRotationSpeed;

    public float maxTwist;

    private float rotationSeppd;

    private int depth;

    private Material[,] materials;

    private static Vector3[] childDirection = {
        Vector3.up,
        Vector3.right,
        Vector3.left,
        Vector3.forward,
        Vector3.back };

    private static Quaternion[] childOrientations = {
        Quaternion.identity,
        Quaternion.Euler(0f, 0f, -90f),
        Quaternion.Euler(0f, 0f, 90f),
        Quaternion.Euler(90f, 0f, 0f),
        Quaternion.Euler(-90f, 0f, 0f) };

    private void Start()
    {
        if (materials == null)
        {
            InitializeMaterials();
        }

        gameObject.AddComponent<MeshFilter>().mesh = meshes[Random.Range(0,2)];
        gameObject.AddComponent<MeshRenderer>().material = materials[depth, Random.Range(0,2)];

        rotationSeppd = Random.Range(-maxRotationSpeed, maxRotationSpeed);
        transform.Rotate(Random.Range(-maxTwist, maxTwist), 0f, 0f);
        // 递归增加
        if (depth < maxDepth)
        {
            StartCoroutine(CreateChildren());
        }
    }

    private void InitializeMaterials()
    {
        materials = new Material[maxDepth + 1, 2];
        for (int i = 0; i <= maxDepth; ++i)
        {
            float t = i / (maxDepth - 1f);
            t *= t;
            materials[i, 0] = new Material(material);
            materials[i, 0].color =
            Color.Lerp(Color.white, Color.yellow, t);

            materials[i, 1] = new Material(material);
            materials[i, 1].color =
            Color.Lerp(Color.white, Color.cyan, t);
        }
        materials[maxDepth, 0].color = Color.magenta;
        materials[maxDepth, 1].color = Color.red;
    }

    private void Initialize(Fractal parent, int childIndex)
    {
        meshes = parent.meshes;
        materials = parent.materials;
        maxDepth = parent.maxDepth;
        childScale = parent.childScale;
        depth = parent.depth + 1;
        transform.parent = parent.transform;
        spawnProbability = parent.spawnProbability;
        maxRotationSpeed = parent.maxRotationSpeed;
        maxTwist = parent.maxTwist;

        transform.localScale = Vector3.one * childScale;
        transform.localPosition = childDirection[childIndex] * (0.5f + 0.5f * childScale);

        transform.localRotation = childOrientations[childIndex];
    }

    private IEnumerator CreateChildren()
    {
        for (int i = 0; i < childDirection.Length; ++i)
        {
            if (Random.value < spawnProbability)
            {
                yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
                new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, i);
            }
        }
    }

    private void Update()
    {
        transform.Rotate(0f, rotationSeppd * Time.deltaTime, 0f);
    }
}