namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Exercise!");

            BuildingVisualizationDiagramTest();
        }

        private static void BuildingVisualizationDiagramTest()
        {
            var building = new Building();

            var floor1 = new Floor(1);
            var room101 = new Room("101");
            var room102 = new Room("102");
            var room103 = new Room("103");

            floor1.AddRoom(room101);
            floor1.AddRoom(room102);
            floor1.AddRoom(room103);

            var floor2 = new Floor(2);
            var room201 = new Room("201");
            var room202 = new Room("202");

            floor2.AddRoom(room201);
            floor2.AddRoom(room202);

            building.AddFloor(floor1);
            building.AddFloor(floor2);

            var buidlingAsGraphFactory = new BuildingAsGraphFactory();
            var mermaidGraph = buidlingAsGraphFactory.Create("Mermaid");
            var mermaidResult = mermaidGraph.GenerateBuildingGraph(building);
            Console.WriteLine("Mermaid graph:");
            Console.WriteLine(mermaidResult + "\n");

            var dgraphGraph = buidlingAsGraphFactory.Create("Dgraph");
            var dgraphResult = dgraphGraph.GenerateBuildingGraph(building);
            Console.WriteLine("Dgraph graph:");
            Console.WriteLine(dgraphResult);
        }
    }
}
