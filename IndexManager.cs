namespace SpiralArray
{
    public class IndexManager
    {
        private int[][] coords = { [1, 0], [0, 1], [-1, 0], [0, -1] };
        private int pointer;
        private int x = 0;
        private int y = 0;
        private readonly int spiralSize;
        private readonly RotationDirection direction;

        public enum RotationDirection
        {
            Clockwise,
            AntiClockwise
        }

        public IndexManager(int spiralSize, RotationDirection direction) 
        { 
            this.spiralSize = spiralSize;
            this.direction = direction;

            if (direction == RotationDirection.Clockwise)
            {
                pointer = 0;
            }
            else
            {
                pointer = 1;
            }
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
            if (direction == RotationDirection.Clockwise)
            {
                pointer += 1;
            }
            else
            {
                pointer -= 1;
            }
            // Keep the pointer within the size of the coords array
            if (pointer == coords.Length)
            {
                pointer = 0;
            }
            else if (pointer < 0)
            {
                pointer = 3;
            }
        }
    }
}
