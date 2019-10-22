import java.util.List;

public class Backtracking extends KnightsTourAlgorithm {

    public boolean solveKT() {
        Chessboard chessboard = new Chessboard(8, 8);

        if (solveKTRecursion(chessboard, 1)) {
            printSolution(chessboard);
        } else {
            System.out.println("Solution for the given problem does not exist");
        }

        return true;
    }

    public boolean solveKTRecursion(Chessboard chessboard, int iteration) {

        if (isFinished(iteration, chessboard)) {
            return true;
        }

        List<Moves> viableMoves = generateViableMoves(chessboard);

        for (Moves m : viableMoves) {
            int nextX = chessboard.getkX() + m.getX();
            int nextY = chessboard.getkY() + m.getY();

            chessboard.move(m, iteration + 1);

            if (solveKTRecursion(chessboard, iteration + 1)) {
                return true;
            } else {
                chessboard.resetValue(nextX, nextY);
            }

        }

        return false;
    }

}
