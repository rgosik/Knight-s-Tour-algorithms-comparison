package com.knightstour;

import com.knightstour.model.Chessboard;

public class Main {

    public static void main(String[] args) {

        Chessboard backTrackingChessboard = new Chessboard(8, 8);

        Backtracking backtracking = new Backtracking(backTrackingChessboard.copy());
        backtracking.solveKT();
    }
}
