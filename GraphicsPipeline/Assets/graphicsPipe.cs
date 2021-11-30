using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class graphicsPipe : MonoBehaviour
{
    GameObject myLetter_GO;
    Modle myLetter;
   

    Renderer myRenderer;
    Texture2D screen;
    private List<Vector3> final_image_using_sigle_matxix;
    private float d;



    // Start is called before the first frame updat
    void Start()
    {
    //       Vector2 start = new Vector2(-3.5f, 1.5f);
      //     Vector2 finish = new Vector2(-1, -5);
        screen = new Texture2D(1024,1024, TextureFormat.ARGB32, false);
        
        myRenderer = FindObjectOfType<Renderer>();

        myRenderer.material.mainTexture = screen;
        myRenderer.material.shader = Shader.Find("Transparent/Diffuse");
      
       
        //if (lineclip(ref start, ref finish))
        //{
        //    print("drawLine");
        //}
        //else
        //    print("drop line");

        Vector2Int Testing1 = new Vector2Int(10, 10);
        Vector2Int Testing2 = new Vector2Int(20, 17);

        List<Vector2Int> outputS = breshenham(Testing1, Testing2);


        /*for (int i = 0; i < 4; i++)
        {
            Vector2 inter = intercept(start, finish, i);
            print(inter);
        }
        */

        var fileName = "Matrix.txt";
        var sr = File.CreateText(fileName);


        myLetter = new Modle();
        //myLetter_GO = myLetter.CreateUnityGameObject();

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

        Matrix4x4 single_mateix_for_everything =proj * Matrix4x4.identity  * Matrix4x4.Translate(new Vector3(0, 0, 5)); 
        sr.WriteLine("the everything Matrix");
        write_matrix_to_file(sr, single_mateix_for_everything);

         final_image_using_sigle_matxix = find_image_of(original, single_mateix_for_everything);
        sr.WriteLine("final image using single matrix");
        write_vertices_to_file(sr, final_image_using_sigle_matxix);

        sr.Close();

        
        
            

    }

    

    public static Vector2Int convert(Vector2 point, Texture2D screen)
    {
        return new Vector2Int((int)(((point.x+1)/2)*(screen.width-1)), (int)((( 1+point.y) / 2) * (screen.height - 1)));
    }

    public static List<Vector3> find_image_of(List<Vector3> vertices, Matrix4x4 matrix_of_transform)
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

        Matrix4x4 camera = Matrix4x4.LookAt(new Vector3(0, 0, 0), new Vector3(0,0,1), (new Vector3(0,1,0)).normalized);
        Matrix4x4 proj = Matrix4x4.Perspective(90, 16 / 9, 1, 1000);
        d +=10; ;
        screen = new Texture2D(screen.width, screen.height, TextureFormat.RGBA32, false);
        myRenderer.material.mainTexture = screen;
        
        Matrix4x4 final_matxix = proj*camera* Matrix4x4.Translate(new Vector3(8, 0, 10))*Matrix4x4.Rotate(Quaternion.AngleAxis(d, new Vector3(0,1,0)))*Matrix4x4.Translate(new Vector3(-8, 0, -10)) * Matrix4x4.Translate(new Vector3(0,0,10));
        myLetter.draw(screen, final_matxix);
    }

    public static bool lineclip(ref Vector2 start, ref Vector2 finish)
    {
        Outcode startOutcode = new Outcode(start);
        Outcode finishOutcode = new Outcode(finish);

        if ((startOutcode == new Outcode()) && (finishOutcode == new Outcode()))
        {
            //print("Trivial acepted");
            return true;
        }
        if ((startOutcode * finishOutcode)!= new Outcode())
        {
           // print("Trivial rejected");
            
            return false;
        }
        if( startOutcode==new Outcode())
        {
            //print("start acepted");
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

    public static Vector2 intercept(Vector2 start, Vector2 end, int edgeId)
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

    public static List<Vector2Int> breshenham(Vector2Int start, Vector2Int end)
    {
        List<Vector2Int> output_list = new List<Vector2Int>();

        int x0 = (int) start.x;
        int y0 = (int)start.y;

        int x1 = (int)end.x;
        int y1 = (int)end.y;

        int dx = x1 - x0, dy = y1-y0;

        int p = 2*dy - dx;

        if (dx < 0)
            return breshenham(end, start);

        if (dy > dx)
            return swap_XandY(breshenham(swap_XandY(start), swap_XandY(end)));

        if (dy < 0)
            return negY(breshenham(negY(start), negY(end)));

        while (x0 <= x1)
        {
            Vector2Int addVector = new Vector2Int(x0, y0);
            output_list.Add(addVector);

            x0++;
            if (p <= 0)
            {
                p += 2 * dy;
            }
            else
            {
                y0++;
                p += 2 * (dy - dx);
            }
            
        }
        return output_list;
    }


    public static Vector2Int swap_XandY(Vector2Int vector)
    {
        int x = vector.x;
        int y = vector.y;

        Vector2Int swapedVector = new Vector2Int(y, x);

        return swapedVector;
    }

    public static List<Vector2Int> swap_XandY(List<Vector2Int> inputList)
    {
        List<Vector2Int> output_list = new List<Vector2Int>();

        foreach(Vector2Int vector in inputList)
        {


            output_list.Add(swap_XandY(vector));
        }

        return output_list;
    }

    public static Vector2Int  negY(Vector2Int point)
    {
        return new Vector2Int(point.x, -point.y);
    }

    public static List<Vector2Int> negY(List<Vector2Int> inputList)
    {
        List<Vector2Int> output_list = new List<Vector2Int>();
        foreach(Vector2Int vector in inputList)
        {
            output_list.Add(negY(vector));
        }
        return output_list;
    }

    void floodFill( Vector2Int seed, int fillcollor)
    {
        //seedColor = getColorAt(seed);
        
        
    }



}
