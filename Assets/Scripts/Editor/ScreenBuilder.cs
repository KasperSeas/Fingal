using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
[InitializeOnLoad]
public class ScreenBuilder : Editor {
	
//	public MovieTexture movie;
	//public Material movieMat;
	static ScreenSet[] screenSets;

	static MeshFilter mesh_filter;
	static MeshRenderer mesh_renderer;
	static MeshCollider mesh_collider;


	// Generate Mesh data
	// Initialize arrays
	static Vector3[] vertices;
	static int[] triangles;
	static Vector3[] normals;
	static Vector2[] uvs;


	[MenuItem("Component/Build Screen Mesh")] static void BuildScreenMesh () {

		screenSets = GameObject.FindObjectsOfType<ScreenSet> ();

		foreach(ScreenSet ss in screenSets){
			if (ss.GetComponent<MeshFilter> () == null) {
				Debug.LogError ("ScreenSet "+ss.name+" doesn't have a MeshFilter.");
			}
			if (ss.GetComponent<MeshRenderer> () == null) {
				Debug.LogError ("ScreenSet "+ss.name+" doesn't have a MeshRenderer.");
			}
			if (ss.GetComponent<MeshCollider> () == null) {
				Debug.LogError ("ScreenSet "+ss.name+" doesn't have a MeshCollider.");
			}
		}

		BuildMesh ();
	}



	void Awake(){
//		mesh_filter = GetComponent<MeshFilter> ();
//		mesh_renderer = GetComponent<MeshRenderer> ();
//		mesh_collider = GetComponent<MeshCollider> ();

//		int vertexCount = gameObject.transform.FindChild ("MainScreen").transform.childCount;

//		print (vertexCount);


//		mesh_renderer.sharedMaterial.mainTexture = movie as MovieTexture;
		//mesh_renderer.sharedMaterial = movieMat;
//		movie.loop = true;
//		movie.Play ();
	}

	void Start(){
		
	}



	static void BuildMesh(){
		

//		print ("total VERTS: "+vertices.Length);
		foreach(ScreenSet ss in screenSets){
			int numQuad = ss.transform.childCount;
			int vertexCount = 0;

			vertices = new Vector3[numQuad * 4];
			triangles = new int[numQuad * 2 * 3]; // 2 triangles * 3 points
			normals = new Vector3[numQuad * 4];
			uvs = new Vector2[numQuad * 4];	
			foreach(Transform t in ss.transform){
	//			print ("Building Quad: "+t.name+"...");


				Transform[] quadVertices = new Transform[4];

				for(int i = 0; i < t.childCount; i++){
					quadVertices [i] = t.GetChild (i).transform;
	//				print ("vertex: "+t.GetChild (i).transform.position);
				}

				BuildQuad (ss, t, quadVertices);

	//			for(int i = 0; i < t.childCount; i++){
	//				vertices [vertexCount+i] = t.GetChild (i).transform.localPosition;
	//			}

			}

			mesh_filter = ss.GetComponent<MeshFilter> ();

			// Create Mesh with data
			Mesh mesh = new Mesh ();
			mesh.vertices = vertices;
			mesh.triangles = triangles; 
			mesh.normals = normals;
			mesh.uv = uvs;
			// Assign Mesh to filter, renderer, collider
			mesh_filter.sharedMesh = mesh;

		}

	}


	static void BuildQuad(ScreenSet ss, Transform t, Transform[] quadVertices){
		int id = t.GetSiblingIndex ();
		ScreenQuad quad = new ScreenQuad();
		if (t.GetComponent<ScreenQuad> () != null)
			quad = t.GetComponent<ScreenQuad> ();
		


		// id: Quad ID
		// create vertices
		vertices [(id * 4) + 0] = quadVertices [0].position - ss.transform.position;
		vertices [(id * 4) + 1] = quadVertices [1].position - ss.transform.position;
		vertices [(id * 4) + 2] = quadVertices [2].position - ss.transform.position;
		vertices [(id * 4) + 3] = quadVertices [3].position - ss.transform.position;
		// Triangle A
		triangles [(id*6)+0] = (id*4)+0;
		triangles [(id*6)+1] = (id*4)+3; 
		triangles [(id*6)+2] = (id*4)+2; 
		// Triangle B
		triangles [(id*6)+3] = (id*4)+0;
		triangles [(id*6)+4] = (id*4)+1; 
		triangles [(id*6)+5] = (id*4)+3;
		// create normals
		normals[(id*4)+0] = -Vector3.forward;
		normals[(id*4)+1] = -Vector3.forward;
		normals[(id*4)+2] = -Vector3.forward;
		normals[(id*4)+3] = -Vector3.forward;
		// create uvs
		if (t.GetComponent<ScreenQuad> () != null) {
			uvs [(id * 4) + 0] = quad.uvs[0];
			uvs [(id * 4) + 1] = quad.uvs[1];
			uvs [(id * 4) + 2] = quad.uvs[2];
			uvs [(id * 4) + 3] = quad.uvs[3];	
		} else {
			uvs [(id * 4) + 0] = new Vector2 (0, 1);
			uvs [(id * 4) + 1] = new Vector2 (1, 1);
			uvs [(id * 4) + 2] = new Vector2 (0, 0);
			uvs [(id * 4) + 3] = new Vector2 (1, 0);	
		}
	}


	// LEGACY

	static void buildScreenMeshOLD(){
		int xDiv = 3;
		int yDiv = 3;
		int numScreens = xDiv * yDiv;

		vertices = new Vector3[numScreens * 4];
		triangles = new int[numScreens * 2 * 3]; // 2 triangles * 3 points
		normals = new Vector3[numScreens * 4];
		uvs = new Vector2[numScreens * 4];

		int id = 0;
		for (int j = 0; j < yDiv; j++) {
			for(int i = 0; i < xDiv; i++){
//				Debug.Log(i+", "+j);
//				Debug.Log ((i * (1 / (float)xDiv))+", "+(i+1) * (1/(float)xDiv));
				buildScreen (id++, i*1.5f, j*1.5f, -(j*0.5f), 1, 1, i * (1 / (float)xDiv), (i+1) * (1/(float)xDiv), j * (1 / (float)yDiv), (j+1) * ((1 / (float)yDiv)));
			}
		}

//		buildScreen (0, 0, 0, 0, 1, 1, 0, 0.33f, 0, 1);
//		buildScreen (1, 1, 0, 0, 1, 1, 0.33f, (1+1) * 0.33f, 0, 1);
//		buildScreen (2, 2, 0, 0, 1, 1, 2 * 0.33f, (2+1) * 0.33f, 0, 1);

		// Create M esh with data
		Mesh mesh = new Mesh ();
		mesh.vertices = vertices;
		mesh.triangles = triangles; 
		mesh.normals = normals;
		mesh.uv = uvs;
		// Assign Mesh to filter, renderer, collider
		mesh_filter.mesh = mesh;


	}

	static void buildScreen(int id, float x, float y, float z, float width, float length, float uStart, float uEnd, float vStart, float vEnd){
//		int numVertices = 4;
//		Vector3[] vertices = new Vector3[numVertices];
//		int[] triangles = new int[2 * 3]; // 2 triangles * 3 points
//		Vector3[] normals = new Vector3[numVertices];
//		Vector2[] uvs = new Vector2[numVertices];

		// Face 1
		// create vertices
		vertices[(id*4)+0] = new Vector3(x,y+1,z); 
		vertices[(id*4)+1] = new Vector3((x+1),y+1,z); 
		vertices[(id*4)+2] = new Vector3(x,y,z); 
		vertices[(id*4)+3] = new Vector3((x+1),y,z); 
		// Triangle A
		triangles [(id*6)+0] = (id*4)+0;
		triangles [(id*6)+1] = (id*4)+3; 
		triangles [(id*6)+2] = (id*4)+2; 
		// Triangle B
		triangles [(id*6)+3] = (id*4)+0;
		triangles [(id*6)+4] = (id*4)+1; 
		triangles [(id*6)+5] = (id*4)+3;
		// create normals
		normals[(id*4)+0] = -Vector3.forward;
		normals[(id*4)+1] = -Vector3.forward;
		normals[(id*4)+2] = -Vector3.forward;
		normals[(id*4)+3] = -Vector3.forward;
		// create uvs
		uvs[(id*4)+0] = new Vector2(uStart,vEnd);
		uvs[(id*4)+1] = new Vector2(uEnd,vEnd);
		uvs[(id*4)+2] = new Vector2(uStart,vStart);
		uvs[(id*4)+3] = new Vector2(uEnd,vStart);	


//		Mesh mesh = new Mesh ();
//		mesh.vertices = vertices;
//		mesh.triangles = triangles; 
//		mesh.normals = normals;
//		mesh.uv = uvs;
//		mesh.RecalculateBounds ();	
	}




}
