namespace SpiralArray
{
    public class SpiralArray
    {
        static int[] Spiral(int[] array)
        {
            int arraySize = array.Length;
            double testSpiral = Math.Sqrt(arraySize);
            int spiralSize = (int)testSpiral;

            // Check if array can form a square with equal sides.
            if (testSpiral != spiralSize)
            {
                throw new ArgumentException("Invalid array size");
            }

            int x = 0, y = 0;
            int stepCounter = 0;
            int rotationCounter = -1;
            int step = spiralSize - 1;

            for (int i = 1; i < arraySize; i++)
            {
                // Do stuff first

                stepCounter++;
                if (stepCounter == step)
                {
                    stepCounter = 0;
                    // Rotate direction.
                    rotationCounter++;
                }

                if (rotationCounter == 2)
                {
                    rotationCounter = 0;
                    step--;
                }
            }

            // Temp return statement
            return array;
        }

        static void Main(string[] args)
        {
            /*
             * Given the single-dimensional array [1,2,3,4,5,6,7,8,9] the array [1,2,3,8,9,4,7,6,5] is returned.
             */
            int[] singleDimensionArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9};
            Spiral(singleDimensionArray);

            /*
             * Given the two dimensional array [[1,2,3], the array [[1,2,3], is returned.
             *                                  [4,5,6],            [8,9,4],
             *                                  [7,8,9]]            [7,6,5]
             */
        }
    }
}
