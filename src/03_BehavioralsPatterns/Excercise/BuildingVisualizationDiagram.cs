using System.Text;

namespace Exercise
{
    public class Room
    {
        public string Name { get; set; }

        public Room(string name)
        {
            Name = name;
        }
    }

    public class Floor
    {
        public int Number { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();

        public Floor(int number)
        {
            Number = number;
        }

        public void AddRoom(Room room)
        {
            if (Rooms.Any(r => r.Name == room.Name))
            {
                throw new Exception("Rooms must have unique names");
            }
            Rooms.Add(room);
        }
    }

    public class Building
    {
        public List<Floor> Floors { get; set; } = new List<Floor>();

        public void AddFloor(Floor floor)
        {
            Floors.Add(floor);
        }
    }

    // Abstract strategy
    public interface IBuildingGraph
    {
        public string GenerateBuildingGraph(Building building);
    }

    // Concrete strategy 1
    class MermaidGraph : IBuildingGraph
    {
        public string GenerateBuildingGraph(Building building)
        {
            var sb = new StringBuilder();
            sb.AppendLine("graph TD");
            sb.AppendLine($"    Building[\"Building\"]");
            foreach (var floor in building.Floors)
            {
                var floorId = $"Floor{floor.Number}";
                sb.AppendLine($"    Building --> {floorId}[\"Floor {floor.Number}\"]");
                foreach (var room in floor.Rooms)
                {
                    var roomId = $"Room{floor.Number}{room.Name}";
                    sb.AppendLine($"    {floorId} --> {roomId}[\"Room {room.Name}\"]");
                }
            }
            return sb.ToString();
        }
    }

    // Concrete strategy 2
    class DgraphGraph : IBuildingGraph
    {
        public string GenerateBuildingGraph(Building building)
        {
            var sb = new StringBuilder();
            sb.AppendLine("digraph BuildingStructure {");
            sb.AppendLine("    rankdir=TB;");
            sb.AppendLine("    node [shape=box];");
            sb.AppendLine($"    \"Building\" [label=\"Building\", shape=ellipse, style=filled, fillcolor=lightblue];");
            foreach (var floor in building.Floors)
            {
                var floorId = $"Floor_{floor.Number}";
                sb.AppendLine($"    \"Building\" -> \"{floorId}\";");
                sb.AppendLine($"    \"{floorId}\" [label=\"Floor {floor.Number}\", style=filled, fillcolor=lightyellow];");
                foreach (var room in floor.Rooms)
                {
                    var roomId = $"Room_{floor.Number}_{room.Name}";
                    sb.AppendLine($"    \"{floorId}\" -> \"{roomId}\";");
                    sb.AppendLine($"    \"{roomId}\" [label=\"Room {room.Name}\", style=filled, fillcolor=lightgreen];");
                }
            }
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
