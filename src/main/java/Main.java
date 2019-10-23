public class Main {

    public static void main(String[] args) {
        Chessboard backTrackingChessboard = new Chessboard(8, 8);

        Backtracking back = new Backtracking(Chessboard.copy(backTrackingChessboard));
        back.solveKT();
    }
}
