import java.util.ArrayList;
import java.util.List;

public abstract class KnightsTourAlgorithm {

    private final Chessboard chessboard;
    private int iteration;
    private List<Moves> viableMoves;

    public KnightsTourAlgorithm(Chessboard chessboard){
        this.chessboard = chessboard;
        iteration = 1;
        viableMoves = new ArrayList<>();
    }

    public void calculateViableMoves(){
        for (Moves move : Moves.values()){
            if(validateMove(move)){
                viableMoves.add(move);
            }
        }
    }

    public boolean isFinished(){
        return iteration == chessboard.getBoard().length * chessboard.getBoard()[0].length;
    }

    public boolean validateMove(Moves move){
        return chessboard.getkX() + move.getX() >= 0 && chessboard.getkY() + move.getY() >= 0;
    }

    public List getViableMoves() {
        return viableMoves;
    }

    public Chessboard getChessboard() {
        return chessboard;
    }

    public int getIteration() {
        return iteration;
    }
}
