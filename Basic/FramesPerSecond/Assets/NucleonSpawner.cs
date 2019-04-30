using UnityEngine;

public class NucleonSpawner : MonoBehaviour
{
    public float timeBetweenSpawns;

    public float spwanDistance;

    public Nucleon[] nucleonsPrefabs;

    private float timeSinceLastSpawn;

    private void FixedUpdate()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= timeBetweenSpawns)
        {
            timeSinceLastSpawn -= timeBetweenSpawns;
            SpawnNucleon();
        }
    }

    private void SpawnNucleon()
    {
        Nucleon prefab = nucleonsPrefabs[Random.Range(0, nucleonsPrefabs.Length)];
        Nucleon spawn = Instantiate<Nucleon>(prefab);

        spawn.transform.localPosition = Random.onUnitSphere * spwanDistance;
    }
}
