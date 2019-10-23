public class Main {

    public static void main(String[] args) {
        Chessboard backTrackingChessboard = new Chessboard(5, 7);

        Backtracking back1 = new Backtracking(Chessboard.copy(backTrackingChessboard));
        back1.solveKT();

        Backtracking back2 = new Backtracking(Chessboard.copy(backTrackingChessboard));
        back2.solveKT();
    }
}
