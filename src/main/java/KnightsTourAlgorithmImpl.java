import model.Chessboard;
import model.Moves;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

public abstract class KnightsTourAlgorithmImpl {

    private Chessboard chessboard;

    public KnightsTourAlgorithmImpl(Chessboard chessboard) {
        this.chessboard = chessboard;
    }

    public Set<Moves> generateLegalMoves(Chessboard chessboard) {
        Set<Moves> viableMoves = new HashSet<>();

        for (Moves move : Moves.values()) {
            if (validateMove(move, chessboard)) {
                viableMoves.add(move);
            }
        }
        return viableMoves;
    }

    public List<Moves> generateLegalMoves(int[][] board, int knightX, int knightY) {
        List<Moves> viableMoves = new ArrayList<>();

        for (Moves move : Moves.values()) {
            if (validateMove(move, board, knightX, knightY)) {
                viableMoves.add(move);
            }
        }
        return viableMoves;
    }

    private boolean validateMove(Moves m, Chessboard chessboard) {
        int newX = chessboard.getKnightX() + m.getX();
        int newY = chessboard.getKnightY() + m.getY();

        return (newX >= 0 && newX < chessboard.getXSize() && (newY >= 0 && newY < chessboard.getYSize()) && chessboard.getBoard()[newX][newY] == 0);
    }

    private boolean validateMove(Moves m, int[][] board, int knightX, int knightY) {
        int newX = knightX + m.getX();
        int newY = knightY + m.getY();

        if ((newX >= 0 && newX < board.length) && (newY >= 0 && newY < board[0].length)) {
            return board[newX][newY] == 0;
        }

        return false;
    }

    public boolean isFinished(int iteration, Chessboard chessboard) {
        return iteration == chessboard.getXSize() * chessboard.getYSize();
    }

    public boolean isFinished(int iteration, int[][] board) {
        return iteration == board.length * board[0].length;
    }


    public void printSolution(Chessboard chessboard) {

        int[][] board = chessboard.getBoard();

        for (int[] x : board) {
            for (int y : x) {
                System.out.printf("%4d", y);
            }
            System.out.println();
        }
        System.out.println();
    }

    public Chessboard getChessboard() {
        return chessboard;
    }
}
