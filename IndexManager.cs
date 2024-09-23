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

        /// <summary>
        /// Method <c>Next</c> updates the internal values of <c>x</c> and <c>y</c> according to the current rotation
        /// </summary>
        /// <returns>The new indices, like <c>[x,y]</c></returns>
        public int[] Next()
        {
            x += coords[pointer][0];
            y += coords[pointer][1];

            return [x, y];
        }
        
        /// <summary>
        ///  Method <c>Rotate</c> updates the direction of following calls to <see cref="Next"/>.
        /// </summary>
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
