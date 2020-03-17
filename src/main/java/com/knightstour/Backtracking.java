package com.knightstour;

import com.knightstour.model.Chessboard;
import com.knightstour.model.Moves;

import java.util.List;

public class Backtracking extends KnightsTourAlgorithmImpl {

    public Backtracking(Chessboard chessboard) {
        super(chessboard, Backtracking.class.toString());
    }

    public boolean solveKT() {

        if (solveKTRecursion(getChessboard().getBoard(), 1, getChessboard().getKnightX(), getChessboard().getKnightY())) {
            printSolution(getChessboard());
        } else {
            System.out.println("Solution for the given problem does not exist");
        }

        return true;
    }

    private boolean solveKTRecursion(int[][] board, int iteration, int knightX, int knightY) {

        //log.info(Integer.toString(iteration));

        if (isFinished(iteration, board)) {
            return true;
        }

        List<Moves> viableMoves = generateLegalMoves(board, knightX, knightY);

        for (Moves move : viableMoves) {
            int nextX = knightX + move.getX();
            int nextY = knightY + move.getY();

            board[nextX][nextY] = iteration + 1;

            if (solveKTRecursion(board, iteration + 1, nextX, nextY)) {
                return true;
            } else {
                board[nextX][nextY] = 0;
            }

        }

        return false;
    }

}
