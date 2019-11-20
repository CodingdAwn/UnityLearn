using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cone_test : MonoBehaviour
{
    public Vector3 pos1;
    public Vector3 pos2;

    public GameObject Prefab;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        for (int i = 0; i < 10000; ++i)
        {
            GameObject go = Object.Instantiate(Prefab);
            go.transform.position = RandomPos();
        }
    }

    private Vector3 RandomPos()
    {
        Vector3 dir = (pos2 - pos1).normalized;

        var vector3 = new Vector3(1, 0, 0);


        var result1 = Quaternion.AngleAxis(RandomAngle(), Vector3.up) * dir;
        var result2 = Quaternion.AngleAxis(RandomAngle(), Vector3.forward) * result1;
        return result2 * RandomLength();
    }

    private float RandomAngle()
    {
        float angle = Random.Range(-30.0f, 30.0f);
        return angle;
    }

    private float RandomLength()
    {
        float dis = Random.Range(1.0f, (pos2 - pos1).magnitude);
        return dis;
    }
}
