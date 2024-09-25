namespace SpiralArray
{
    public class SpiralArray
    {
        static int[] Spiral(int[] array, IndexManager.RotationDirection direction, IndexManager.StartPosition position, bool inverted = false)
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
            var manager = new IndexManager(spiralSize, direction, position);

            int startIndex = 0;
            if (inverted)
            {
                startIndex = array.Length - 1;
            }

            // First entry, excluded from loop
            var coords = manager.First();
            spiralArray[coords[0] + coords[1] * spiralSize] = array[startIndex];

            for (int i = 1; i < arraySize; i++)
            {
                coords = manager.Next();
                int selectionIndex = Math.Abs(startIndex - i);
                spiralArray[coords[0] + coords[1] * spiralSize] = array[selectionIndex];
                
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

        static int[,] Spiral(int[,] array, IndexManager.RotationDirection direction, IndexManager.StartPosition position, bool inverted = false)
        {
            int arrayWidth = array.GetLength(0);
            int arrayHeight = array.GetLength(1);

            // Check if array can form a square with equal sides.
            if (arrayHeight != arrayWidth)
            {
                throw new ArgumentException("Invalid array size");
            }

            int stepCounter = 0;
            int rotationCounter = -1;
            int step = arrayWidth - 1;

            int[,] spiralArray = new int[arrayWidth, arrayHeight];
            var manager = new IndexManager(arrayWidth, direction, position);

            int startIndex = 0;
            if (inverted)
            {
                startIndex = arrayWidth - 1;
            }

            int[] coords;

            for (int i = 0; i < arrayWidth; i++)
            {
                for (int j = 0; j < arrayHeight; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        // First entry
                        coords = manager.First();
                        spiralArray[coords[0], coords[1]] = array[startIndex, startIndex];
                        continue;
                    }
                    coords = manager.Next();
                    int selectionX = Math.Abs(startIndex - i);
                    int selectionY = Math.Abs(startIndex - j);
                    spiralArray[coords[1],coords[0]] = array[selectionX,selectionY];

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
            }
            return spiralArray;
        }

        // Simple method to print a given single-dimensional array
        private static void PrintArray(int[] array)
        {
            Console.Write("[");
            for (int i = 0; i < array.Length - 1; i++)
            {
                Console.Write($"{array[i]},");
            }
            Console.WriteLine($"{array[array.Length - 1]}]\n");
        }

        // Simple method to print a given two dimensional array
        private static void PrintArray(int[,] array)
        {
            Console.Write("[");
            for(int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write("[");
                for(int j = 0; j < array.GetLength(1) - 1; j++)
                {
                    Console.Write($"{array[i, j]},");
                }
                var end = (i == array.GetLength(0) - 1) ? "]]" : "]";
                Console.WriteLine($"{array[i, array.GetLength(1) - 1]}{end}");
                Console.Write(" ");
            }
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            int[] singleDimensionArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] largeSingleDimensionArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            int[,] multiDimensionalArray = {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}};
            /*
             * With Clockwise rotation and topleft starting position,
             * the given single-dimensional array [1,2,3,4,5,6,7,8,9] should return the array [1,2,3,8,9,4,7,6,5].
             */
            PrintArray(Spiral(singleDimensionArray, IndexManager.RotationDirection.Clockwise, IndexManager.StartPosition.TopLeft));

            /*
             * With Anti-Clockwise rotation and bottomleft starting position,
             * the given single-dimensional array [1,2,3,4,5,6,7,8,9] should return the array [7,6,5,8,9,4,1,2,3].
             */
            PrintArray(Spiral(singleDimensionArray, IndexManager.RotationDirection.AntiClockwise, IndexManager.StartPosition.BottomLeft));

            /*
             * With Clockwise rotation and topleft starting position,
             * the given two dimensional array [[1,2,3], should return the array [[1,2,3],
             *                                  [4,5,6],                          [8,9,4],
             *                                  [7,8,9]]                          [7,6,5]].
             */
            PrintArray(Spiral(multiDimensionalArray, IndexManager.RotationDirection.Clockwise, IndexManager.StartPosition.TopLeft));

            /* 
             * With Anti-Clockwise rotation and bottomright starting position,
             * the given two dimensional array [[1,2,3], should return the array [[5,4,3],
             *                                  [4,5,6],                          [6,9,2],
             *                                  [7,8,9]]                          [7,8,1]].
             */
            PrintArray(Spiral(multiDimensionalArray, IndexManager.RotationDirection.AntiClockwise, IndexManager.StartPosition.BottomRight));

            /*
             * With Clockwise rotation, topleft starting position and is inverted,
             * the given single-dimensional array [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16]
             * should return the array [16,15,14,13,5,4,3,12,6,1,2,11,7,8,9,10]
             */
            PrintArray(Spiral(largeSingleDimensionArray, IndexManager.RotationDirection.Clockwise, IndexManager.StartPosition.TopLeft, true));

            /*
             * With Clockwise rotation and topleft starting position and is inverted,
             * the given two dimensional array [[1,2,3], should return the array [[9,8,7],
             *                                  [4,5,6],                          [2,1,6],
             *                                  [7,8,9]]                          [3,4,5]].
             */
            PrintArray(Spiral(multiDimensionalArray, IndexManager.RotationDirection.Clockwise, IndexManager.StartPosition.TopLeft, true));
        }
    }
}
