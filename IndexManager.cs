namespace SpiralArray
{
    public class IndexManager
    {
        private int[][] coords = { [1, 0], [0, 1], [-1, 0], [0, -1] };
        private int pointer = 0;
        private int x = 0;
        private int y = 0;
        private readonly int spiralSize;

        public IndexManager(int spiralSize) 
        { 
            this.spiralSize = spiralSize;
        }

        public int[] Next()
        {
            x += coords[pointer][0];
            y += coords[pointer][1];

            return [x, y];
        }

        public void Rotate()
        {
            // Keep the pointer within the size of the coords array
            pointer += 1;
            if (pointer == coords.Length)
            {
                pointer = 0;
            }
        }
    }
}
