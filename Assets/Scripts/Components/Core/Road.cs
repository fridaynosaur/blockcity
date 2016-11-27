using UnityEngine;
using System.Collections;

namespace BlockCity {
		
	public class Road : Block {
		public Vector3 Position2 { get; private set; }
		public float Width { get; private set; }
		public float Length { get; private set; }
		public Vector3[] Vertices { get; private set; }
		public int[] Triangles { get; private set; }
		public Vector2[] Uv { get; private set; }
		public Vector3[] Normals { get; private set; }

		public void Init(int id, Vector3 start, Vector3 end, Vector3 size) {
			this.Init (id, start, Vector3.one);
			this.Position2 = end;

			this.Length = Vector3.Distance (start, end);
			this.Width = size.x;
		}

		private void SetVertices() {
			Vertices = new Vector3[] {
				new Vector3 (0, 0, -Width/2),
				new Vector3 (Length, 0, -Width/2), 
				new Vector3 (Length, 0, Width/2),
				new Vector3 (0, 0, Width/2),
			};
		}

		private void SetTriangles() {
			Triangles = new int[] {
				1, 0, 2,
				2, 0, 3
			};
		}

		private void SetUv() {
			Uv = new Vector2[] {
				new Vector2(0, 0),
				new Vector2(Length, 0),
				new Vector2(Length, 1),
				new Vector2(0, 1)
			};
		}

		private void SetNormals() {
			Normals = new Vector3[] {
				Vector3.up,
				Vector3.up,
				Vector3.up,
				Vector3.up
			};
		}

		public Mesh GetMesh() {
			Mesh mesh = new Mesh ();

			SetVertices ();
			SetTriangles ();
			SetUv ();
			SetNormals ();

			mesh.vertices = Vertices;
			mesh.triangles = Triangles;
			mesh.uv = Uv;
			mesh.normals = Normals;

			return mesh;
		}

		public Mesh CreateMesh(float width, float height)
		{
			Mesh m = new Mesh();
			m.name = "RoadMesh";
			m.vertices = new Vector3[] {
				new Vector3(-width, 0, -height),
				new Vector3(width, 0, -height),
				new Vector3(width, 0, height),
				new Vector3(-width, 0, height)
			};
			m.uv = new Vector2[] {
				new Vector2 (0, 0),
				new Vector2 (0, 1),
				new Vector2(1, 1),
				new Vector2 (1, 0)
			};
			m.triangles = new int[] { 1, 0, 2, 2, 0, 3};
			m.RecalculateNormals();

			return m;
		}

		public Mesh CreateMesh() {
			return CreateMesh (Width, Length);
		}
	}

}
