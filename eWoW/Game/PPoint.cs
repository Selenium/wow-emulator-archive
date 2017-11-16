using System;
using System.Collections;

using ErrorLog;

namespace eWoW
{
	public class PPoint
	{
		DBMemory data;
		string file;
		bool change=false;

		public PPoint(string file)
		{
			this.file=file;
			data = new DBMemory(file, true, new DB.ReadSectionFunction(DB.ConvertType));
		}

		public int TotalCount()
		{
			int count=0;
			foreach(string map in data.Keys())
			{
				Hashtable h=data.Get(map);
				ArrayList v=h["PP"] as ArrayList;
				count+=v.Count;
			}
			return count;
		}

		public void Save()
		{
			if(change)data.SaveCache(file);
			change=false;
		}

		int FindHash(ArrayList points, int hash)
		{
			int start=0;
			int end=points.Count;
			while(start<end-1)
			{
				int p=(start+end)/2;
				int ph=points[p].GetHashCode();
				if( ph > hash )end=p;
				if( ph == hash )break;
				if( ph < hash )start=p;
			}
			return start;
		}

		ArrayList GetNearPoints(int map, Position pos, float distance)
		{
			Hashtable h=data.Get("MAP " + map.ToString());
			if (h == null)
			{
				Log.WriteEvent( "GetNearPoints no MAP " + map.ToString() );
				return null;
			}
			ArrayList points=h["PP"] as ArrayList;

			MapPosition m=new MapPosition(pos, 0);
			int mh=m.GetHashCode();

			int mhlow=mh-(int)Math.Abs( (pos.x+distance) *distance);
			if(mhlow<0)mhlow=0;

			int mhhigh=mh+(int)Math.Abs( (pos.y+distance) *distance);

			ArrayList ret=new ArrayList();

			int center=FindHash(points, mh);
			for(int p=center; p>=0; p--)
			{
				MapPosition t=points[p] as MapPosition;
				if( t.GetHashCode() < mhlow )break;
				if( t.Distance(m) > distance )continue;
				ret.Add(t);
			}

			for(int p=center; p<points.Count; p++)
			{
				MapPosition t=points[p] as MapPosition;
				if( t.GetHashCode() > mhhigh )break;
				if( t.Distance(m) > distance )continue;
				ret.Add(t);
			}
			return ret;
		}

		class CalXYZ:IComparer
		{
			#region IComparer ≥…‘±

			public int Compare(object x, object y)
			{
				MapPosition a=(MapPosition)x;
				MapPosition b=(MapPosition)y;

				return a.Distance( Position.Null ).CompareTo( b.Distance(Position.Null) );
			}

			#endregion
		}


		ArrayList GetNear3Points(ArrayList points, Position pos)
		{
			ArrayList n=new ArrayList();
			foreach(MapPosition m in points)
			{
				Position p=m.Pos;
				p.x-=pos.x;
				p.y-=pos.y;
				p.z-=pos.z;
				n.Add( new MapPosition( p, m.Flags) );
			}
			n.Sort(new CalXYZ());

			ArrayList ret=new ArrayList();
			for(int i=0; i<3; i++)
			{
				Position p=(n[i] as MapPosition).Pos;
				p.x+=pos.x;
				p.y+=pos.y;
				p.z+=pos.z;
				ret.Add( new MapPosition( p, (n[i] as MapPosition).Flags));
			}
			return ret;
		}

		float GetMapZ(ArrayList points, float x, float y)
		{
			Position[] pts=new Position[3];
			for(int i=0; i<3; i++)
			{
				pts[i]=(points[i] as MapPosition).Pos;
			}

			// 1 and 2 at same level, exchange 0 and 1
			if(pts[1].z >= pts[2].z - 0.1 && pts[1].z <= pts[2].z + 0.1)
			{
				pts[1]=pts[0];
				pts[0]=(points[1] as MapPosition).Pos;
			}

			// 0 and 1 and 2 at same level, then return z
			if(pts[1].z >= pts[2].z - 0.1 && pts[1].z <= pts[2].z + 0.1)
			{
				return pts[1].z;
			}

			pts[1].x -= pts[0].x;
			pts[1].y -= pts[0].y;
			pts[1].z -= pts[0].z;

			pts[2].x -= pts[0].x;
			pts[2].y -= pts[0].y;
			pts[2].z -= pts[0].z;

			x -= pts[0].x;
			y -= pts[0].y;

			// get zero point
			double kx=pts[2].x - (pts[2].x - pts[1].x) * pts[2].z / (pts[2].z - pts[1].z);
			double ky=pts[2].y - (pts[2].y - pts[1].y) * pts[2].z / (pts[2].z - pts[1].z);

			if(ky>-0.1 && ky<0.1) // at y map
			{
				if(pts[2].x > -0.1 && pts[2].x < 0.1) return pts[0].z + x * pts[1].z / pts[1].x;
				return pts[0].z + x * pts[2].z / pts[2].x;
			}

			if(kx>-0.1 && kx<0.1) // at x map
			{
				if(pts[2].y > -0.1 && pts[2].y < 0.1) return pts[0].z + y * pts[1].z / pts[1].y;
				return pts[0].z + y * pts[2].z / pts[2].y;
			}

			double d1=Math.Abs(ky*pts[2].x - kx*pts[2].y) / Math.Sqrt(kx*kx + ky*ky); 
			double d2=Math.Abs(ky*x - kx*y) / Math.Sqrt(kx*kx + ky*ky); 

			return (float)(pts[0].z + pts[2].z * d2/d1 );
		}

		public void GetDest(int map, Position pos, float ang, float distance, out Position dest)
		{
			pos.CalPoint(ang, distance, out dest);
			ArrayList points=GetNearPoints(map, dest, 30);
			if (points == null)
			{
				Log.WriteEvent( "public void GetDest no points" );
				return;
			}
			if(points.Count<3)return;
			points=GetNear3Points(points, dest);
			dest.z=GetMapZ(points, dest.x, dest.y);
		}

		public void UpdatePoint(int map, Position pos)
		{
			Hashtable h=data.Get("MAP " + map.ToString());
			ArrayList points=h["PP"] as ArrayList;

			// 1. check pos is right

			// 2. add pos to points

			change=true;
		}
	}
}
