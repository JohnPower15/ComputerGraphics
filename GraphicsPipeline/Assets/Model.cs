using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modle
{
    int hellow;

    List<Vector3> verticies;
    List<Vector3Int> faces;
    List<Vector2> _texture_coordinates;
    List<Vector3Int> _texture_index_list;
    List<Vector3> normals;
    
    public List<Vector3> _vertices { get { return verticies; } }
    public List<int> _index_list
    {
        get
        {
            List<int> output = new List<int>();
            foreach (Vector3Int v in faces)
            {
                output.Add(v.x);
                output.Add(v.y);
                output.Add(v.z);
            }

            return output;
        }
    }

    public Modle()
    {
        loadData();
    }

    private void loadData()
    {
        verticies = new List<Vector3>();
        faces = new List<Vector3Int>();

        //top left
        //0
        verticies.Add(new Vector3(-1, 2, 0.5f));
        //1
        verticies.Add(new Vector3(-1, 2, -0.5f));

        //top left mid
        //2
        verticies.Add(new Vector3(0, 2, 0.5f));
        //3
        verticies.Add(new Vector3(0, 2, -0.5f));

        //top right mid
        //4
        verticies.Add(new Vector3(1, 2, 0.5f));
        //5
        verticies.Add(new Vector3(1, 2, -0.5f));

        //top right
        //6
        verticies.Add(new Vector3(2, 2, 0.5f));
        //7
        verticies.Add(new Vector3(2, 2, -0.5f));

        //top botom left
        //8
        verticies.Add(new Vector3(-1, 1, 0.5f));
        //9
        verticies.Add(new Vector3(-1, 1, -0.5f));

        //top bottom right
        //10
        verticies.Add(new Vector3(2, 1, 0.5f));
        //11
        verticies.Add(new Vector3(2, 1, -0.5f));

        //neck top left
        //12
        verticies.Add(new Vector3(0, 1, 0.5f));
        //13
        verticies.Add(new Vector3(0, 1, -0.5f));

        //neck top right
        //14
        verticies.Add(new Vector3(1, 1, 0.5f));
        //15
        verticies.Add(new Vector3(1, 1, -0.5f));

        //neck mid left
        //16
        verticies.Add(new Vector3(0, 0, 0.5f));
        //17
        verticies.Add(new Vector3(0, 0, -0.5f));

        //neck mid right
        //18
        verticies.Add(new Vector3(1, 0, 0.5f));
        //19
        verticies.Add(new Vector3(1, 0, -0.5f));

        //neck bottom left
        //20
        verticies.Add(new Vector3(0, -1, 0.5f));
        //21
        verticies.Add(new Vector3(0, -1, -0.5f));

        //neck bottom right
        //22
        verticies.Add(new Vector3(1, -1, 0.5f));
        //23
        verticies.Add(new Vector3(1, -1, -0.5f));

        //bottom left
        //24
        verticies.Add(new Vector3(-1, -2, 0.5f));
        //25
        verticies.Add(new Vector3(-1, -2, -0.5f));

        //bottom mid
        //26
        verticies.Add(new Vector3(0, -2, 0.5f));
        //27
        verticies.Add(new Vector3(0, -2, -0.5f));

        //bottom right
        //28
        verticies.Add(new Vector3(1, -2, 0.5f));
        //29
        verticies.Add(new Vector3(1, -2, -0.5f));

        //hook top left
        //30
        verticies.Add(new Vector3(-2, 0, 0.5f));
        //31
        verticies.Add(new Vector3(-2, 0, -0.5f));

        //hook top right
        //32
        verticies.Add(new Vector3(-1, 0, 0.5f));
        //33
        verticies.Add(new Vector3(-1, 0, -0.5f));

        //hook bottom left
        //34
        verticies.Add(new Vector3(-2, -1, 0.5f));
        //35
        verticies.Add(new Vector3(-2, -1, -0.5f));

        //hook bottom right
        //36
        verticies.Add(new Vector3(-1, -1, 0.5f));
        //37
        verticies.Add(new Vector3(-1, -1, -0.5f));


        _texture_index_list = new List<Vector3Int>();
        normals = new List<Vector3>();

        //left top face
        faces.Add(new Vector3Int(0, 1, 9));
        faces.Add(new Vector3Int(0, 9, 8)); 
        _texture_index_list.Add(new Vector3Int(2, 3, 0)); _texture_index_list.Add(new Vector3Int(2, 0, 1));
        normals.Add(Vector3.left);
        normals.Add(Vector3.left);

        //top face
        faces.Add(new Vector3Int(0, 7, 1));
        faces.Add(new Vector3Int(0, 6, 7));
        _texture_index_list.Add(new Vector3Int(2, 3, 0)); _texture_index_list.Add(new Vector3Int(2, 0, 1));
        normals.Add(Vector3.up);
        normals.Add(Vector3.up);

        //neck face left
        faces.Add(new Vector3Int(12, 13, 21));
        faces.Add(new Vector3Int(12, 21, 20));
        _texture_index_list.Add(new Vector3Int(2, 3, 0)); _texture_index_list.Add(new Vector3Int(2, 0, 1));
        normals.Add(Vector3.left);
        normals.Add(Vector3.left);

        //arm top
        faces.Add(new Vector3Int(20, 21, 37));
        faces.Add(new Vector3Int(20, 37, 36));
        _texture_index_list.Add(new Vector3Int(2, 3, 0)); _texture_index_list.Add(new Vector3Int(2, 0, 1));
        normals.Add(Vector3.up);
        normals.Add(Vector3.up);

        //hook top face
        faces.Add(new Vector3Int(30, 33, 31));
        faces.Add(new Vector3Int(30, 32, 33));
        _texture_index_list.Add(new Vector3Int(2, 3, 0)); _texture_index_list.Add(new Vector3Int(2, 0, 1));
        normals.Add(Vector3.up);
        normals.Add(Vector3.up);

        //hook left face
        faces.Add(new Vector3Int(30, 31, 35));
        faces.Add(new Vector3Int(30, 35, 34));
        _texture_index_list.Add(new Vector3Int(2, 3, 0)); _texture_index_list.Add(new Vector3Int(2, 0, 1));
        normals.Add(Vector3.left);
        normals.Add(Vector3.left);

        //hook bottom face slanted
        faces.Add(new Vector3Int(24, 34, 35));
        faces.Add(new Vector3Int(24, 35, 25));
        _texture_index_list.Add(new Vector3Int(2, 3, 0)); _texture_index_list.Add(new Vector3Int(2, 0, 1));
        normals.Add(Vector3.left);
        normals.Add(Vector3.left);

        //main face forword
        faces.Add(new Vector3Int(0, 10, 6));
        faces.Add(new Vector3Int(0, 8, 10));
        _texture_index_list.Add(new Vector3Int(2, 3, 0)); _texture_index_list.Add(new Vector3Int(2, 0, 1));
        normals.Add(Vector3.forward);
        normals.Add(Vector3.forward);

        faces.Add(new Vector3Int(12, 28, 14));
        faces.Add(new Vector3Int(12, 26, 28));
        _texture_index_list.Add(new Vector3Int(2, 3, 0)); _texture_index_list.Add(new Vector3Int(2, 0, 1));
        normals.Add(Vector3.forward);
        normals.Add(Vector3.forward);

        faces.Add(new Vector3Int(20, 34, 24));
        faces.Add(new Vector3Int(20, 24, 26));
        _texture_index_list.Add(new Vector3Int(2, 3, 0)); _texture_index_list.Add(new Vector3Int(2, 0, 1));
        normals.Add(Vector3.forward);
        normals.Add(Vector3.forward);

        faces.Add(new Vector3Int(30, 36, 32));
        faces.Add(new Vector3Int(30, 34, 36));
        _texture_index_list.Add(new Vector3Int(2, 3, 0)); _texture_index_list.Add(new Vector3Int(2, 0, 1));
        normals.Add(Vector3.forward);
        normals.Add(Vector3.forward);

        //top bottom left face
        faces.Add(new Vector3Int(9, 13, 12));
        faces.Add(new Vector3Int(9, 12, 8));
        _texture_index_list.Add(new Vector3Int(2, 3, 0)); _texture_index_list.Add(new Vector3Int(2, 0, 1));
        normals.Add(Vector3.down);
        normals.Add(Vector3.down);

        //top bottom right face
        faces.Add(new Vector3Int(10, 15, 11));
        faces.Add(new Vector3Int(10, 14, 15));
        _texture_index_list.Add(new Vector3Int(2, 3, 0)); _texture_index_list.Add(new Vector3Int(2, 0, 1));
        normals.Add(Vector3.down);
        normals.Add(Vector3.down);

        //top right face
        faces.Add(new Vector3Int(6, 11, 7));
        faces.Add(new Vector3Int(6, 10, 11));
        _texture_index_list.Add(new Vector3Int(2, 3, 0)); _texture_index_list.Add(new Vector3Int(2, 0, 1));
        normals.Add(Vector3.right);
        normals.Add(Vector3.right);

        //neck right face
        faces.Add(new Vector3Int(14, 29, 15));
        faces.Add(new Vector3Int(14, 28, 29));
        _texture_index_list.Add(new Vector3Int(2, 3, 0)); _texture_index_list.Add(new Vector3Int(2, 0, 1));
        normals.Add(Vector3.right);
        normals.Add(Vector3.right);

        //bottom face
        faces.Add(new Vector3Int(24, 25, 29));
        faces.Add(new Vector3Int(24, 29, 28));
        _texture_index_list.Add(new Vector3Int(2, 3, 0)); _texture_index_list.Add(new Vector3Int(2, 0, 1));
        normals.Add(Vector3.down);
        normals.Add(Vector3.down);

        //hook right face
        faces.Add(new Vector3Int(32, 37, 33));
        faces.Add(new Vector3Int(32, 36, 37));
        _texture_index_list.Add(new Vector3Int(2, 3, 0)); _texture_index_list.Add(new Vector3Int(2, 0, 1));
        normals.Add(Vector3.right);
        normals.Add(Vector3.right);

        //main back face 
        faces.Add(new Vector3Int(1, 7, 11));
        faces.Add(new Vector3Int(1, 11, 9));
        _texture_index_list.Add(new Vector3Int(2, 3, 0)); _texture_index_list.Add(new Vector3Int(2, 0, 1));
        normals.Add(Vector3.back);
        normals.Add(Vector3.back);

        faces.Add(new Vector3Int(13, 15, 29));
        faces.Add(new Vector3Int(13, 29, 27));
        _texture_index_list.Add(new Vector3Int(2, 3, 0)); _texture_index_list.Add(new Vector3Int(2, 0, 1));
        normals.Add(Vector3.back);
        normals.Add(Vector3.back);

        faces.Add(new Vector3Int(21, 27, 25));
        faces.Add(new Vector3Int(21, 25, 35));
        _texture_index_list.Add(new Vector3Int(2, 3, 0)); _texture_index_list.Add(new Vector3Int(2, 0, 1));
        normals.Add(Vector3.back);
        normals.Add(Vector3.back);

        faces.Add(new Vector3Int(31, 37, 35));
        faces.Add(new Vector3Int(31, 33, 37));
        _texture_index_list.Add(new Vector3Int(2, 3, 0)); _texture_index_list.Add(new Vector3Int(2, 0, 1));
        normals.Add(Vector3.back);
        normals.Add(Vector3.back);

        _texture_coordinates = new List<Vector2>();

        //0
        _texture_coordinates.Add(new Vector2(0, 0));
        //1
        _texture_coordinates.Add(new Vector2(200, 0));
        //2
        _texture_coordinates.Add(new Vector2(0, 66));
        //3
        _texture_coordinates.Add(new Vector2(73, 66));
        //4
        _texture_coordinates.Add(new Vector2(147, 66));
        //5
        _texture_coordinates.Add(new Vector2(200, 66));
        //6
        _texture_coordinates.Add(new Vector2(0, 418));
        //7
        _texture_coordinates.Add(new Vector2(33, 418));
        //8
        _texture_coordinates.Add(new Vector2(33, 458));
        //9
        _texture_coordinates.Add(new Vector2(73, 458));
       //10
        _texture_coordinates.Add(new Vector2(0, 478));
        //11
        _texture_coordinates.Add(new Vector2(31, 511));
        //12
        _texture_coordinates.Add(new Vector2(146, 511));
        
        //13
        _texture_coordinates.Add(new Vector2(313, 0));
        //14
        _texture_coordinates.Add(new Vector2(511, 511));
        //15
        _texture_coordinates.Add(new Vector2(313, 66));
        //16
        _texture_coordinates.Add(new Vector2(366, 66));
        //17
        _texture_coordinates.Add(new Vector2(439, 66));
        //18
        _texture_coordinates.Add(new Vector2(511, 66));
        //19
        _texture_coordinates.Add(new Vector2(479, 418));
        //20
        _texture_coordinates.Add(new Vector2(511, 418));
        //21
        _texture_coordinates.Add(new Vector2(440, 458));
        //22
        _texture_coordinates.Add(new Vector2(479, 458));
        //23
        _texture_coordinates.Add(new Vector2(511, 478));
        //24
        _texture_coordinates.Add(new Vector2(478, 511));
        //25
        _texture_coordinates.Add(new Vector2(366, 511));


        _texture_coordinates = ConvertToRelitive(_texture_coordinates);

    }

    private List<Vector2> ConvertToRelitive(List<Vector2> texture_coordinates)
    {
        List<Vector2> outputList = new List<Vector2>();

        foreach(Vector2 v in texture_coordinates)
        {
            outputList.Add(new Vector2(v.x/511f,(511-v.y)/511));
        }

        return outputList;
    }

    public GameObject CreateUnityGameObject()
    {
        Mesh mesh = new Mesh();
        GameObject newGO = new GameObject();
        MeshFilter mesh_filter = newGO.AddComponent<MeshFilter>();
        MeshRenderer mesh_renderer = newGO.AddComponent<MeshRenderer>();




        List<Vector3> coords = new List<Vector3>();
        List<int> dummy_indices = new List<int>();
        List<Vector2> text_coords = new List<Vector2>();
        List<Vector3> normalz = new List<Vector3>();

        for (int i = 0; i < faces.Count; i++)
        {
            Vector3 normal_for_face = normals[i / 3];
            normal_for_face = new Vector3(normal_for_face.x, normal_for_face.y, -normal_for_face.z);
            coords.Add(verticies[faces[i].x]); dummy_indices.Add(i*3); text_coords.Add(_texture_coordinates[_texture_index_list[i].x]); normalz.Add(normal_for_face);
            coords.Add(verticies[faces[i].y]); dummy_indices.Add(i*3 + 1); text_coords.Add(_texture_coordinates[_texture_index_list[i].y]); normalz.Add(normal_for_face);
            coords.Add(verticies[faces[i].z]); dummy_indices.Add(i*3 + 2); text_coords.Add(_texture_coordinates[_texture_index_list[i].z]); normalz.Add(normal_for_face);
        }

        mesh.vertices = coords.ToArray();
        mesh.triangles = dummy_indices.ToArray();
        mesh.uv = text_coords.ToArray();
        mesh.normals = normalz.ToArray(); ;

        mesh_filter.mesh = mesh;
        return newGO;

    }
}
