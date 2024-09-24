namespace SpiralArray
{
    public class SpiralArray
    {
        static int[] Spiral(int[] array, IndexManager.RotationDirection direction)
        {
            int arraySize = array.Length;
            double testSpiral = Math.Sqrt(arraySize);
            int spiralSize = (int)testSpiral;

            // Check if array can form a square with equal sides.
            if (testSpiral != spiralSize)
            {
                throw new ArgumentException("Invalid array size");
            }

            int stepCounter = 0;
            int rotationCounter = -1;
            int step = spiralSize - 1;
            int[] spiralArray = new int[arraySize];
            var manager = new IndexManager(spiralSize, direction);

            // First entry, excluded from loop
            spiralArray[0] = array[0];

            for (int i = 1; i < arraySize; i++)
            {
                var coords = manager.Next();
                spiralArray[coords[0] + coords[1] * spiralSize] = array[i];
                
                stepCounter++;
                if (stepCounter == step)
                {
                    stepCounter = 0;
                    manager.Rotate();
                    rotationCounter++;
                }

                if (rotationCounter == 2)
                {
                    rotationCounter = 0;
                    step--;
                }
            }
            return spiralArray;
        }

        // Simple method to print a given array
        private static void PrintArray(int[] array)
        {
            Console.Write("[");
            for (int i = 0; i < array.Length - 1; i++)
            {
                Console.Write($"{array[i]},");
            }
            Console.WriteLine($"{array[array.Length - 1]}]");
        }

        static void Main(string[] args)
        {
            /*
             * Given the single-dimensional array [1,2,3,4,5,6,7,8,9] the array [1,2,3,8,9,4,7,6,5] is returned.
             */
            int[] singleDimensionArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9};
            PrintArray(Spiral(singleDimensionArray, IndexManager.RotationDirection.Clockwise));

            /*
             * Given the single-dimensional array [1,2,3,4,5,6,7,8,9] the array [1,8,7,2,9,6,3,4,5] is returned.
             */
            PrintArray(Spiral(singleDimensionArray, IndexManager.RotationDirection.AntiClockwise));

            /*
             * Given the two dimensional array [[1,2,3], the array [[1,2,3], is returned.
             *                                  [4,5,6],            [8,9,4],
             *                                  [7,8,9]]            [7,6,5]
             */
        }
    }
}
