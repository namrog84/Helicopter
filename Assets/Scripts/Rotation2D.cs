using UnityEngine;
using System.Collections;

public static class Rotation2D {


    private static Quaternion rotation = new Quaternion();

    private static Vector3 up = new Vector3(0, 0, 1);
  //  private static Vector3 up = new Vector3(0, 0, 1);
 //   private static Vector3 up = new Vector3(0, 0, 1);


    public static Quaternion SmoothLookAt(Transform transform, Vector3 target, Vector3 axis, float speed)
    {
        if (axis == up || axis == -up)
        {
            target.y = transform.position.y;
            if (target.y >= transform.position.y)
                rotation = Quaternion.LookRotation(target - transform.position, up);
            else
                rotation = Quaternion.LookRotation(target - transform.position, -up);
        }
        else if (axis == Vector3.right || axis == -Vector3.right)
        {
            target.x = transform.position.x;
            if (target.x >= transform.position.x)
                rotation = Quaternion.LookRotation(target - transform.position, Vector3.right);
            else
                rotation = Quaternion.LookRotation(target - transform.position, -Vector3.right);
        }
        else if (axis == Vector3.forward || axis == -Vector3.forward)
        {
            target.z = transform.position.z;
            if (target.z >= transform.position.z)
                rotation = Quaternion.LookRotation(target - transform.position, Vector3.forward);
            else
                rotation = Quaternion.LookRotation(target - transform.position, -Vector3.forward);
        }
        return Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);
    }

}
