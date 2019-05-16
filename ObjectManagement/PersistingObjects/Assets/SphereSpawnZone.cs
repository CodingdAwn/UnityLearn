using UnityEngine;

public class SphereSpawnZone : SpawnZone
{
  [SerializeField]
  bool surfaceOnly;

  public override Vector3 SpawnPoint
  {
    get {
      // TransformPoint 将 localPoint 转换成了世界坐标 返回值是经过scale处理得
      // onUnitSphere 是在表面选择随机 inside就是里面随机
      return transform.TransformPoint(
          surfaceOnly ? Random.onUnitSphere : Random.insideUnitSphere);
    }
  }

  void OnDrawGizmos()
  {
    Gizmos.color = Color.cyan;
    Gizmos.matrix = transform.localToWorldMatrix;
    Gizmos.DrawWireSphere(Vector3.zero, 1f);
  }
}
