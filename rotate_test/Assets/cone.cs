using UnityEngine;
using Random = UnityEngine.Random;

public class cone : MonoBehaviour
{
    public int Count;
    public float R;
    public float T;

    private void OnDrawGizmos()
    {
        Vector3 from = new Vector3(10, 0, 0);
        Vector3 to = transform.position;
        Vector3 dir = to - from;
        Gizmos.color = Color.green;
        Gizmos.DrawLine(from, to);
        Gizmos.DrawSphere(to, 0.1f);
        Gizmos.color = Color.red;
        for (int i = 0; i < Count; i++)
        {

            Vector3 n = new Vector3();
            if (dir.x != 0)
            {
                n.y = Random.Range(-1f, 1f);
                n.z = Random.Range(-1f, 1f);
                n.x = (-dir.z * n.z - dir.y * n.y) / dir.x;
            }
            else if (dir.y != 0)
            {
                n.x = Random.Range(-1f, 1f);
                n.z = Random.Range(-1f, 1f);
                n.y = (-dir.x * n.x - dir.z * n.z) / dir.y;
            }
            else if (dir.z != 0)
            {
                n.x = Random.Range(-1f, 1f);
                n.y = Random.Range(-1f, 1f);
                n.z = (-dir.x * n.x - dir.y * n.y) / dir.z;
            }

            n = n.normalized * Mathf.Sqrt(Random.Range(0, R));
            //n = n.normalized * Random.Range(0, R);
            float t = Random.Range(T, 1f);
            Gizmos.DrawSphere(from + dir * t + n * t, 0.1f);
        }
    }
}