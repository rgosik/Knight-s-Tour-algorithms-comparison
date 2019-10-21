public abstract class KnightsTourAlgorithm {

    private final Chessboard chessboard;
    private int iteration;

    public KnightsTourAlgorithm(Chessboard chessboard){
        this.chessboard = chessboard;
        iteration = 1;
    }

    public Chessboard getChessboard() {
        return chessboard;
    }

    public int getIteration() {
        return iteration;
    }
}
