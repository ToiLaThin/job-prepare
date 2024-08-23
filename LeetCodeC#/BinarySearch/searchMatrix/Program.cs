// You are given an m x n integer matrix matrix with the following two properties:
// Each row is sorted in non-decreasing order. (tang dan)
// The first integer of each row is greater than the last integer of the previous row.
// Given an integer target, return true if target is in matrix or false otherwise.

// You must write a solution in O(log(m * n)) time complexity.

//return true / false if target is in matrix

//binary search

bool searchMatrix(int[][] matrix, int target) {
    //matrix rows are sorted asc, first row ele > last row ele

    //bin search on Y, then bin search on X

    int top = 0;
    int bottom = matrix.Length - 1;
    int lenRow = matrix[0].Length;
    int midRow = -1;
    while (top <= bottom) {
        midRow = top + (bottom - top) / 2;
        if (target < matrix[midRow][0]) {
            bottom = midRow - 1;
        }
        else if (target > matrix[midRow][lenRow - 1]) {
            top = midRow + 1;
        }
        else {
            //found row
            break;
        }
    }

    //safe check
    if (top > bottom || midRow == -1) {
        return false;
    }

    //bin search on X, on found row
    int left = 0;
    int right = lenRow - 1;
    int midCol;
    while (left <= right) {
        midCol = left + (right - left) / 2;
        if (target < matrix[midRow][midCol]) {
            right = midCol - 1;
        }
        else if (target > matrix[midRow][midCol]) {
            left = midRow + 1;
        }
        else {
            //found target
            return true;
        }
    }

    return false;
}

int[][] matrix = new int[3][];
//case 1
matrix[0] = new int[] {1,3,5,7};
matrix[1] = new int[] {10,11,16,20};
matrix[2] = new int[] {23,30,34,60};

int target = 13;
System.Console.WriteLine(searchMatrix(matrix, target));