using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class graphicsPipe : MonoBehaviour
{
    GameObject myLetter_GO;
    Modle myLetter;
    

    // Start is called before the first frame updat
    void Start()
    {
           Vector2 start = new Vector2(-3.5f, 1.5f);
           Vector2 finish = new Vector2(-1, -5);
           

        if (lineclip(ref start, ref finish))
        {
            print("drawLine");
        }
        else
            print("drop line");
        
        
        /*for (int i = 0; i < 4; i++)
        {
            Vector2 inter = intercept(start, finish, i);
            print(inter);
        }
        */

        var fileName = "Matrix.txt";
        var sr = File.CreateText(fileName);


        myLetter = new Modle();
        myLetter_GO = myLetter.CreateUnityGameObject();

        List<Vector3> original = myLetter._vertices;
        sr.WriteLine("Original vertices");
        write_vertices_to_file(sr,original);

        Matrix4x4 rotationMatrix = Matrix4x4.Rotate(Quaternion.AngleAxis(-14, (new Vector3(8, 3, 3)).normalized));
        sr.WriteLine("Rotation Matrix");
        write_matrix_to_file(sr,rotationMatrix);

        List<Vector3> image_after_rotation = find_image_of(original, rotationMatrix);
        sr.WriteLine("image after rotation vertices");
        write_vertices_to_file(sr,image_after_rotation);

       // Matrix4x4 scaleMatrix = Matrix4x4.Scale(new Vector3(8, 2, 3));
        Matrix4x4 scaleMatrix = Matrix4x4.Scale(new Vector3(1, 1, 1));
        sr.WriteLine("scale Matrix");
        write_matrix_to_file(sr,scaleMatrix);

        List<Vector3> image_after_scale = find_image_of(image_after_rotation, scaleMatrix);
        sr.WriteLine("image after scale");
        write_vertices_to_file(sr,image_after_scale);

        Matrix4x4 traslationMatrix = Matrix4x4.Translate(new Vector3(1, -2, 4));
        sr.WriteLine("translation Matrix");
        write_matrix_to_file(sr,traslationMatrix);

        List<Vector3> image_after_translation = find_image_of(image_after_scale, traslationMatrix);
        sr.WriteLine("image after translation vertices");
        write_vertices_to_file(sr,image_after_translation);

        Matrix4x4 matrix_of_transformations = traslationMatrix  * scaleMatrix * rotationMatrix;
        sr.WriteLine("transformation Matrix");
        write_matrix_to_file(sr,matrix_of_transformations);
        

        List<Vector3> image_after_transformations = find_image_of(original, matrix_of_transformations);
        sr.WriteLine("image after transformation");
        write_vertices_to_file(sr, image_after_transformations);
        


        Matrix4x4 camera = Matrix4x4.LookAt(new Vector3(10,6,53), new Vector3(3,8,3), (new Vector3(4,3,8)).normalized);
        sr.WriteLine("camera Matrix");
        write_matrix_to_file(sr, camera);

        List<Vector3> image_after_viewing = find_image_of(image_after_translation, camera);
        sr.WriteLine("image after camera vertices");
        write_vertices_to_file(sr, image_after_viewing);

        Matrix4x4 proj = Matrix4x4.Perspective(90, 16 / 9, 1, 1000);
        sr.WriteLine("projection Matrix");
        write_matrix_to_file(sr, proj);

        List<Vector3> final_image = find_image_of(image_after_viewing, proj);
        sr.WriteLine("final image");
        write_vertices_to_file(sr, final_image);

        Matrix4x4 single_mateix_for_everything =proj * camera  * matrix_of_transformations ;
        sr.WriteLine("the everything Matrix");
        write_matrix_to_file(sr, single_mateix_for_everything);

        List<Vector3> final_image_using_sigle_matxix = find_image_of(original, single_mateix_for_everything);
        sr.WriteLine("final image using single matrix");
        write_vertices_to_file(sr, final_image_using_sigle_matxix);

        sr.Close();
    }
    private List<Vector3> find_image_of(List<Vector3> vertices, Matrix4x4 matrix_of_transform)
    {
        List<Vector3> new_image = new List<Vector3>();
        foreach (Vector3 v in vertices)
            new_image.Add(matrix_of_transform * new Vector4(v.x,v.y,v.z,1));

      

        return new_image;

    }

    void write_vertices_to_file(StreamWriter sr, List<Vector3> vertices)
    {
        foreach (var val in vertices)
        sr.WriteLine(val.x + " , " + val.y + " , " + val.z);
        //sr.Close();

    }

    void write_matrix_to_file(StreamWriter sr, Matrix4x4 matrix)
    {
           
            sr.WriteLine(matrix);
            //sr.Close();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    bool lineclip(ref Vector2 start, ref Vector2 finish)
    {
        Outcode startOutcode = new Outcode(start);
        Outcode finishOutcode = new Outcode(finish);

        if ((startOutcode == new Outcode()) && (finishOutcode == new Outcode()))
        {
            print("Trivial acepted");
            return true;
        }
        if ((startOutcode * finishOutcode)!= new Outcode())
        {
            print("Trivial rejected");
            start = new Vector2(0, 0);
            return false;
        }
        if( startOutcode==new Outcode())
        {
            print("start acepted");
            return lineclip(ref finish, ref start);
        }
        if (startOutcode.up)
        {
            print("above clip");
            start = intercept(start, finish, 0);
            return lineclip(ref start, ref finish);
        }
        if (startOutcode.down)
        {
            print("down clip");
            start = intercept(start, finish, 1);
            return lineclip(ref start, ref finish);
        }
        if (startOutcode.left)
        {
            print("left clip");
            start = intercept(start, finish, 2);
            return lineclip(ref start, ref finish);
        }
        if (startOutcode.right)
        {
            print("right clip");
            start = intercept(start, finish, 3);
            return lineclip(ref start, ref finish);
        }
        //work to do

        return false;
    }

    Vector2 intercept(Vector2 start, Vector2 end, int edgeId)
    {
        float m = (end.y - start.y) / (end.x - start.x);
        switch (edgeId) {
            case 0:
                return new Vector2(start.x+(1-start.y)/m,1);
            case 1:
                return new Vector2(start.x + (-1 - start.y) / m, -1);
            case 2:
                return new Vector2(-1, start.y + m * (-1 - start.x));
            default:
                return new Vector2(1, start.y + m * (1 - start.x));
        }

    }

    

}
