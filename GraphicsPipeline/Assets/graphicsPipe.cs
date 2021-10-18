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
}
