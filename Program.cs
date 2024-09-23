namespace SpiralArray
{
    public class SpiralArray
    {
        static int[] Spiral(int[] array)
        {
            int arraySize = array.Length;
            double testSpiral = Math.Sqrt(arraySize);
            int spiralSize = (int)testSpiral;

            //Check if array can form a square with equal sides
            if (testSpiral != spiralSize)
            {
                throw new ArgumentException("Invalid array size");
            }

            //Temp return statement
            return array;
        }

        static void Main(string[] args)
        {
            /*
             * Given the single-dimensional array [1,2,3,4,5,6,7,8,9] the returned array should be [1,2,3,8,9,4,7,6,5].
             */
            int[] singleDimensionArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Spiral(singleDimensionArray);

            /*
             * Given the two dimensional array [[1,2,3], the returned array should be  [[1,2,3],
             *                                  [4,5,6],                                [8,9,4],
             *                                  [7,8,9]]                                [7,6,5]
             */
        }
    }
}
