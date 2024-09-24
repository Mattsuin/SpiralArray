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

        public enum StartPosition
        {
            TopLeft,        // [0,0]
            TopRight,       // [n,0]
            BottomLeft,     // [0,n]
            BottomRight     // [n,n] Where n is decided by the size of the spiral.
        }

        public IndexManager(int spiralSize, RotationDirection direction) 
        { 
            this.spiralSize = spiralSize;
            this.direction = direction;

            StartPosition pos = StartPosition.BottomRight;

            if (direction == RotationDirection.Clockwise)
            {
                pointer = 0;
            }
            else
            {
                pointer = 1;
            }

            switch (pos)
            {
                case StartPosition.TopLeft:
                    x = 0;
                    y = 0;
                    break;
                case StartPosition.TopRight:
                    x = spiralSize - 1;
                    y = 0;
                    pointer = (pointer + 1) % coords.Length;
                    break;
                case StartPosition.BottomLeft:
                    x = 0;
                    y = spiralSize - 1;
                    pointer = (pointer + 3) % coords.Length;
                    break;
                case StartPosition.BottomRight:
                    x = spiralSize - 1;
                    y = spiralSize - 1;
                    pointer = (pointer + 2) % coords.Length;
                    break;
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
        /// Method <c>First</c> returns the initial indices.
        /// </summary>
        /// <returns>Initial indices, like <c>[x,y]</c></returns>
        public int[] First()
        {
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
