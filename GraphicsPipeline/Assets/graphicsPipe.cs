using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class graphicsPipe : MonoBehaviour
{
    GameObject myLetter_GO;
    Modle myLetter;
    Matrix4x4 translation, rotation, scale, viewing, projection;

    // Start is called before the first frame updat
    void Start()
    {
        var fileName = "Matrix.txt";
        var sr = File.CreateText(fileName);


        myLetter = new Modle();
        myLetter_GO = myLetter.CreateUnityGameObject();

        List<Vector3> original = myLetter._vertices;
        //sr.WriteLine("Original vertices");
        //write_vertices_to_file(sr,original);

        Matrix4x4 rotationMatrix = Matrix4x4.Rotate(Quaternion.AngleAxis(-14, (new Vector3(8, 3, 3)).normalized));
        //sr.WriteLine("Rotation Matrix");
        //write_matrix_to_file(sr,rotationMatrix);

        List<Vector3> image_after_rotation = find_image_of(original, rotationMatrix);
        //sr.WriteLine("image after rotation vertices");
        //write_vertices_to_file(sr,image_after_rotation);

        Matrix4x4 scaleMatrix = Matrix4x4.Scale(new Vector3(2, 3, 4));
        //sr.WriteLine("scale Matrix");
        //write_matrix_to_file(sr,scaleMatrix);

        List<Vector3> image_after_scale = find_image_of(image_after_rotation, scaleMatrix);
        //sr.WriteLine("image after scale");
        //write_vertices_to_file(sr,image_after_scale);

        Matrix4x4 traslationMatrix = Matrix4x4.Translate(new Vector3(4, 2, 3));
        //sr.WriteLine("translation Matrix");
        //write_matrix_to_file(sr,traslationMatrix);

        List<Vector3> image_after_translation = find_image_of(image_after_scale, traslationMatrix);
        //sr.WriteLine("image after translation vertices");
        //write_vertices_to_file(sr,image_after_rotation);

        Matrix4x4 matrix_of_transformations = rotationMatrix * scale * traslationMatrix;

        
        // Matrix4x4 camera = Matrix4x4.LookAt();
        // Matrix4x4 proj =  Matrix4x4.Perspective()
    }
    private List<Vector3> find_image_of(List<Vector3> vertices, Matrix4x4 matrix_of_transform)
    {
        List<Vector3> new_image = new List<Vector3>();
        foreach (Vector3 v in vertices)
            new_image.Add(matrix_of_transform * v);

        

        return new_image;

    }

    void write_vertices_to_file(StreamWriter sr, List<Vector3> vertices)
    {
        foreach (var val in vertices)
        sr.WriteLine(val);
        sr.Close();

    }

    void write_matrix_to_file(StreamWriter sr, Matrix4x4 matrix)
    {
           
            sr.WriteLine(matrix);
            sr.Close();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
