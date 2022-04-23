using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class roomPlacer : MonoBehaviour
{
    public Transform Player;
    public Room[] RoomPrefabs;
    public Room StartRoom;

    private Room[,] spawnedRooms;

    //private List<Room> spawndRooms = new List<Room>();

    private IEnumerator Start()
    {
        spawnedRooms = new Room[11,11];
        spawnedRooms[5, 5] = StartRoom;

        for (int i = 0; i < 12; i++)
        {
            PlaceOneRoom();
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }

   
    void PlaceOneRoom()
    {
        HashSet<Vector2Int> vacantPlace = new HashSet<Vector2Int>();

        for (int x = 0; x < spawnedRooms.GetLength(0); x++)
        {
            for (int y = 0; y < spawnedRooms.GetLength(1); y++)
            {
                if (spawnedRooms[x, y] == null) continue;

                int maxX = spawnedRooms.GetLength(0) - 1;
                int maxY = spawnedRooms.GetLength(1) - 1;

                if (x > 0 && spawnedRooms[x - 1, y] == null) vacantPlace.Add(new Vector2Int(x - 1, y));
                if (y > 0 && spawnedRooms[x, y - 1] == null) vacantPlace.Add(new Vector2Int(x, y - 1));
                if (x < maxX && spawnedRooms[x + 1, y] == null) vacantPlace.Add(new Vector2Int(x + 1, y));
                if (y < maxY && spawnedRooms[x, y + 1] == null) vacantPlace.Add(new Vector2Int(x, y + 1));
            }
        }

        Room newRoom = Instantiate(RoomPrefabs[Random.Range(0, RoomPrefabs.Length)]);

        int Limit = 500;
        while (Limit-- > 0)
        {
            Vector2Int position = vacantPlace.ElementAt(Random.Range(0, vacantPlace.Count));

            newRoom.RotateRandom();
            if( ConnectToSomething(newRoom, position)) 
            {
                newRoom.transform.position = new Vector3((position.x - 5) * 10, 0, (position.y - 5) * 10);
                spawnedRooms[position.x, position.y] = newRoom;
                return;
            }
            
        }
        Destroy(newRoom.gameObject);
    }

    private bool ConnectToSomething(Room room, Vector2Int p)
    {
        int maxX = spawnedRooms.GetLength(0) - 1;
        int maxY = spawnedRooms.GetLength(1) - 1;

        List<Vector2Int> neighbours = new List<Vector2Int>();
        if (room.doorU != null && p.y < maxY && spawnedRooms[p.x, p.y + 1]?.doorD != null) neighbours.Add(Vector2Int.up);
        if (room.doorD != null && p.y > 0 && spawnedRooms[p.x, p.y - 1]?.doorU != null) neighbours.Add(Vector2Int.down);
        if (room.doorR != null && p.x < maxX && spawnedRooms[p.x + 1, p.y]?.doorL != null) neighbours.Add(Vector2Int.right);
        if (room.doorL != null && p.x > 0 && spawnedRooms[p.x - 1, p.y]?.doorR != null) neighbours.Add(Vector2Int.left);

        if (neighbours.Count == 0) return false;

        Vector2Int selectedDirection = neighbours[Random.Range(0, neighbours.Count)];
        Room selectedRoom = spawnedRooms[p.x + selectedDirection.x, p.y + selectedDirection.y];

        if(selectedDirection == Vector2Int.up)
        {
            room.doorU.SetActive(false);
            selectedRoom.doorD.SetActive(false);
        }

        if (selectedDirection == Vector2Int.down)
        {
            room.doorD.SetActive(false);
            selectedRoom.doorU.SetActive(false);
        }

        if (selectedDirection == Vector2Int.right)
        {
            room.doorR.SetActive(false);
            selectedRoom.doorL.SetActive(false);
        }

        if (selectedDirection == Vector2Int.left)
        {
            room.doorL.SetActive(false);
            selectedRoom.doorR.SetActive(false);
        }

        return true;
    }
}
