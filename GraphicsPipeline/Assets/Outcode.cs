
using UnityEngine;

public class Outcode 
{
    internal bool up, down, left, right;

    public Outcode(Vector2 v)
    {
        up = v.y > 1;
        down = v.y < -1;
        left = v.x < -1;
        right = v.x > 1;

    }

    public Outcode(bool up_arg, bool down_arg, bool left_arg, bool right_arg)
    {
        up = up_arg;
        down = down_arg;
        left = left_arg;
        right = right_arg;
    }
    public Outcode()
    {

    }

   public static bool operator == (Outcode A, Outcode B)
    {
        return (A.up == B.up)&&(A.down==B.down)&&(A.left==B.left)&&(A.right==B.right);
    }
    public static bool operator != (Outcode A, Outcode B)
    {
        return !(A==B);
    }

    public static Outcode operator * (Outcode A, Outcode B)
    {
        return new Outcode(A.up && B.up, A.down&&B.down, A.left&&B.left,A.right&&B.right);
    }
    public static Outcode operator + (Outcode A, Outcode B)
    {
        return new Outcode(A.up || B.up, A.down || B.down, A.left || B.left, A.right || B.right);
    }
}
