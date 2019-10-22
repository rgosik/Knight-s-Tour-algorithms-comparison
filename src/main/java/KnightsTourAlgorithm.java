import java.util.ArrayList;
import java.util.List;

public abstract class KnightsTourAlgorithm {

    public List<Moves> generateViableMoves(Chessboard chessboard){
        List<Moves> viableMoves = new ArrayList<>();

        for (Moves move : Moves.values()){
            if (validateMove(move, chessboard)){
                viableMoves.add(move);
            }
        }
        return viableMoves;
    }

    private boolean validateMove(Moves m, Chessboard chessboard){
        int newX = chessboard.getkX() + m.getX();
        int newY = chessboard.getkY() + m.getY() ;

        return (newX >= 0 && newX < chessboard.getxSize() && (newY >= 0 && newY < chessboard.getySize()) && chessboard.getBoard()[newX][newY] == 0);
    }

    public boolean isFinished(int iteration, Chessboard chessboard){
        return iteration == chessboard.getxSize() * chessboard.getySize() ;
    }

    public void printSolution(Chessboard chessboard){

        int board[][] = chessboard.getBoard();

        for(int x = 0; x < board.length; x++){
            for(int y = 0; y < board[0].length; y++){
                System.out.print(board[x][y] + "  ");
            }
            System.out.println();
        }
    }
}
