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

    void Start()
    {
        spawnedRooms = new Room[11,11];
        spawnedRooms[5, 5] = StartRoom;

        for (int i = 0; i < 12; i++)
        {
            PlaceOneRoom();
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
        Vector2Int position = vacantPlace.ElementAt(Random.Range(0, vacantPlace.Count));
        newRoom.transform.position = new Vector3((position.x - 5) * 11, 0, (position.y - 5) * 8);

        spawnedRooms[position.x, position.y] = newRoom;
    }


}
